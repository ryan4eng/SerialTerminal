using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SerialTerminal.TabTCPServer {
	class TCPServer {
		private TcpListener server;
		public delegate void SetComButtDelegate(bool open);
		public static event SetComButtDelegate SetCommButt;
		Dictionary<string, TcpClient> connectionList = new Dictionary<string, TcpClient>();
		private BlockingCollection<int> queuedRxBytes = new BlockingCollection<int>();
		private string Tcp_LogFileName = "";
		private System.IO.StreamWriter logFile;
		private RichTextBox logTB = null;
		public StringBuilder logBuffer = new StringBuilder();
		private Color logBufLastColor = Color.Black;
		private bool tcpTB_Update = false;
		private System.Timers.Timer timer = new System.Timers.Timer();
		private Thread rxThread = null;
		private SemaphoreSlim sbSemaphore = new SemaphoreSlim(1);
		ListBox lbClientList;

		public TCPServer(ListBox clientList, RichTextBox _tbLogtbLog) {
			this.lbClientList = clientList;
			logTB = _tbLogtbLog;
			if (Config.Data.Serial_LogDirectory == null ||
				(!Directory.Exists(Config.Data.Serial_LogDirectory) && !Config.Data.Serial_LogDirectory.Equals(""))) {
				Write("Error: Log folder no longer exists, changed to default", Color.Red, false);

				Config.Data.Serial_LogDirectory = "";
			}

			//start timer for updating serial port log tb
			timer.Elapsed += new ElapsedEventHandler(Timer_UpdateLog);
			timer.Interval = 50;    //100ms timer
			timer.AutoReset = true;
			timer.Start();

			rxThread = new Thread(new ThreadStart(() => DataHandle_Threaded()));
			rxThread.IsBackground = true;
			rxThread.Start();
		}

		private void DataHandle_Threaded() {
			while (true) {
				byte hex_byte = 0;

				//temporary. might end up doing smart highlighting on messages coming through
				try {
					int b = queuedRxBytes.Take();
					if (b == -1) {
						Close();
						continue;
					}
					else
						hex_byte = (byte)b;
				}
				catch (Exception) {
					continue;
				}

				//color = Color.Gray;
				if ((Config.Data.Serial_DisplayLevel == GLOBAL.HEX_LEVEL_NONE) || (Config.Data.Serial_DisplayLevel == GLOBAL.HEX_LEVEL_NORMAL)) {
					if ((hex_byte == '\n') || (hex_byte == '\t') || ((hex_byte >= 0x20) && (hex_byte <= 0x7E))) {
						string tmpString = new string((char)hex_byte, 1);
						PreprocessAppend(tmpString, Color.Black);
					}
					else if ((Config.Data.Serial_DisplayLevel == GLOBAL.HEX_LEVEL_NORMAL) && (hex_byte != '\r')) {
						PreprocessAppend("{" + Util.ByteToHexBitFiddle(hex_byte) + "}", Color.Gray);
					}
				}
				else if ((Config.Data.Serial_DisplayLevel == GLOBAL.HEX_LEVEL_ALL) || (Config.Data.Serial_DisplayLevel == GLOBAL.HEX_LEVEL_ALL_EXCEPT_NL)) {
					if ((Config.Data.Serial_DisplayLevel == GLOBAL.HEX_LEVEL_ALL_EXCEPT_NL) && ((hex_byte == '\n') || (hex_byte == '\r'))) {
						if (hex_byte == '\n') {
							string tmpString = new string((char)hex_byte, 1);
							PreprocessAppend(tmpString, Color.Black);
						}
					}
					else {
						PreprocessAppend("{" + Util.ByteToHexBitFiddle(hex_byte) + "}", Color.Gray);
					}
				}

				//used only for processing incoming data
				//process.ProcessData(receivedBytes);
				//receivedBytes.Clear();
			}
		}

		private async void Timer_UpdateLog(object source, ElapsedEventArgs e) {
			if (tcpTB_Update && logBuffer.Length > 0) {
				try {
					//block up to 1s
					await sbSemaphore.WaitAsync();
					tcpTB_Update = false;
					logTB.Invoke((MethodInvoker)(delegate () {

						logTB.Rtf = logBuffer.ToString() + "}";
						Util.ScrollToBottom(logTB);
					}));
				}
				catch (Exception) {
					sbSemaphore.Release();
					return;
				}
				sbSemaphore.Release();
			}
		}


		//used for open directory or open file in right-click context menu
		public string GetLogFileName() {
			return Tcp_LogFileName;
		}

		private void ManageConnections() {
			//open new connection
			try {
				server.Start();
				PreprocessAppend("Listening...\r\n", Color.Green);
				while (true) {
					TcpClient client = server.AcceptTcpClient();
					string connection = client.Client.RemoteEndPoint.ToString();
					Thread t = new Thread(() => Connection_Threaded(connection, client));
					t.Start();

					this.connectionList[connection] = client;
					
					if (this.lbClientList.InvokeRequired) {
						this.lbClientList.Invoke((MethodInvoker)(delegate () {
							this.lbClientList.Items.Add(connection);
						}));
					}
					
					PreprocessAppend("New client connected\r\n", Color.Blue);
				}
			}
			catch (Exception ex) {
				if (!(ex is SocketException)) {
					PreprocessAppend("Couldn't Connect: Unknown error\r\n", Color.Red);
				}
				SetCommButt(false);
				return;
			}
		}

		private void Connection_Threaded(string connectionName, TcpClient client) {
			System.IO.StreamWriter macLog = null;

			string path = "";
			bool writeHeader = false;
			System.Timers.Timer t = new System.Timers.Timer();
			t.Interval = 10*1000;

			//t.Elapsed += (obj, sender) => {
			//	t.Stop();
			//	PreprocessAppend("Client timeout " + connectionName + "\r\n", Color.Blue);
			//	client.Close();
			//};
			//t.Start();

			try {
				StringBuilder sb = new StringBuilder();
				while (true) {
					int b = client.GetStream().ReadByte();
					//reset socket timer
					t.Stop();
					t.Start();

					if (!client.Connected || b == -1) {
						PreprocessAppend("Client disconnected " + connectionName +"\r\n", Color.Blue);
						break;
					}
					else {
						if (macLog != null) {
							macLog.Write((char)b);
						}
						else if (sb != null) {
							char c = (char)b;
							if (b >= 32) {
								sb.Append(c);
							}
							else if (b == 0x0a || b == 0x0d) {
								if (Config.Data.Serial_LogDirectory != null) {
									path = Config.Data.Serial_LogDirectory;
								}

								path += sb.ToString().Replace(':', '-') + ".csv";
								
								if (!File.Exists(path)) {
									writeHeader = true;
								}
								macLog = new StreamWriter(path, true);
								if (writeHeader) {
									macLog.Write("Epoch,WearLvlID,Humidity,Temperature (C),Latitude,Longitude,Battery Voltage,Charging Voltage,Flag nFault,Flag nCharge," +
										"S1 Count,S1 1.0,S1 2.5,S1 10.0,S2 Count,S2 1.0,S2 2.5,S2 10.0\n");
								}
								sb.Clear();
								sb = null;
							}
						}
						queuedRxBytes.Add(b);
					}
				}
			}
			catch (Exception) {
				PreprocessAppend("Closed connection " + connectionName + "\r\n", Color.Blue);
			}

			t.Stop();

			if (macLog != null) {
				macLog.Close();
			}

			if (this.lbClientList.InvokeRequired) {
				this.lbClientList.Invoke((MethodInvoker)(delegate () {
					//this.clientList.Items.Add(connection);
					connectionList.Remove(connectionName);
					this.lbClientList.Items.Remove(connectionName);
				}));
			}
		}

		private void T_Tick(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		public void Open(object sender, EventArgs e, string port) {
			int intPort;
			if (!int.TryParse(port, out intPort)) {
				return;
			}
			
			server = new TcpListener(new IPEndPoint(IPAddress.Parse("0.0.0.0"), intPort));

			int num = 1;
			Tcp_LogFileName = "STerminal-TCPServer-" + DateTime.Now.ToString("yyyy-MM-dd");
			string serialLogExtension = ".log";

			while (true) {
				try {
					logFile = new System.IO.StreamWriter(Config.Data.Serial_LogDirectory + Tcp_LogFileName + serialLogExtension, true);
					Tcp_LogFileName += serialLogExtension;
					break;
				}
				catch {
					serialLogExtension = "_" + num.ToString() + ".log";
					num++;
				}
			}
			Thread t = new Thread(new ThreadStart(ManageConnections));
			t.IsBackground = true;
			t.Name = "TCP Server accept connections";
			t.Start();

			SetCommButt(true);
		}

		public void Close() {
			SetCommButt(false);

			server.Stop();
			foreach (KeyValuePair<string, TcpClient> item in connectionList) {
				item.Value.Close();
			}
			PreprocessAppend("TCP Server Closed.\r\n", Color.Green);
		}

		public void Write_Click(object sender, EventArgs e, string text, Color txtColor) {
			Write(text, txtColor, true);
		}

		public void Disconnect(object lbObject) {
			if (lbObject != null && lbObject is string) {
				TcpClient t = connectionList[((string)lbObject)];
				if (t != null) {
					t.Close();
				}
			}
		}

		private void Write(string str, Color txtColor, bool sendCmd) {
			//if (sendCmd) {
			//	if (server.Connected) {
			//		//sp.Write(str);
			//	}
			//	else {
			//		PreprocessAppend("Error, com port not opened", Color.Red);
			//		return;
			//	}
			//}
			//else if (server == null || Tcp_LogFileName.Equals("")) {
			//	System.Windows.Forms.MessageBox.Show("Bug!\r\n");
			//	return;
			//}

			//PreprocessAppend(str, txtColor);
		}


		public void PreprocessAppend(Util.CmdResponse resp) {
			PreprocessAppend(resp.str, resp.color, resp.nl_check);
		}

		private void PreprocessAppend(string str, Color txtColor, bool newLineCheck) {
			PreprocessAppend(str, txtColor);
		}

		private async void PreprocessAppend(string str, Color txtColor) {
			logFile.Write(str);
			logFile.Flush();

			tcpTB_Update = true;
			await sbSemaphore.WaitAsync();
			Util.UpdateLog(logBuffer, str, txtColor, ref logBufLastColor);
			sbSemaphore.Release();
		}

		public void SendCommand(string str, bool hex, bool line_feed) {
			IProgress<Util.CmdResponse> resp = new Progress<Util.CmdResponse>((o) => PreprocessAppend(o));
			if (server == null || this.lbClientList.Items.Count == 0) {
				return;
			}
			else if (this.lbClientList.SelectedItem == null) {
				resp.Report(new Util.CmdResponse("Client not selected\r\n", Color.Red, true));
			}
			else {
				TcpClient client = this.connectionList[(string)this.lbClientList.SelectedItem];
				if (client == null) {
					resp.Report(new Util.CmdResponse("Client selection err? Bug?\r\n", Color.Red, true));
					return;
				}

				try {
					Util.SendCommand(resp, client.GetStream(), str, hex, line_feed);
				}
				catch (Exception) {
					resp.Report(new Util.CmdResponse("TCP connection not opened\r\n", Color.Red, true));
				}
			}
		}

		#region Buttons
		public void InitButtons(SplitContainer container) {
			//serial form panel 1
			foreach (var ctrl in container.Panel1.Controls) {
				if (ctrl.GetType() == typeof(Button)) {
					var btn = ctrl as Button;
					btn.Click += (s, EventArgs) => { tabTcpSvr_SendDataButtonClicked(s, EventArgs, container); };
				}
			}

			//serial form panel 2
			foreach (var ctrl in container.Panel2.Controls) {
				if (ctrl.GetType() == typeof(Button)) {
					var btn = ctrl as Button;
					btn.Click += (s, EventArgs) => { tabTcpSvr_SendDataButtonClicked(s, EventArgs, container); };
				}
			}
		}


		public void tabTcpSvr_SendDataButtonClicked(object sender, EventArgs e, SplitContainer container) {
			if (server == null || this.lbClientList.Items.Count == 0 || this.lbClientList.SelectedItem == null) {
				return;
			}
			TcpClient client = this.connectionList[(string)this.lbClientList.SelectedItem];
			if (client == null)
				return;

			//MessageBox.Show((sender as Button).Name);
			var txtName = (sender as Button).Name.Replace("tabTcpSvr_butSend", "tabTcpSvr_tbSend");
			var hex_chkBox = txtName.Replace("tabTcpSvr_tbSend", "tabTcpSvr_cbHexSend");
			var lf_chkBox = txtName.Replace("tabTcpSvr_tbSend", "tabTcpSvr_cbLFSend");

			IProgress<Util.CmdResponse> resp = new Progress<Util.CmdResponse>((o) => PreprocessAppend(o));

			if (container.Panel1.Controls[txtName] != null) {
				//SendCommand((container.Panel1.Controls[txtName] as TextBox).Text, (container.Panel1.Controls[hex_chkBox] as CheckBox).Checked, (container.Panel1.Controls[lf_chkBox] as CheckBox).Checked);
				Util.SendCommand(resp, client.GetStream(), (container.Panel1.Controls[txtName] as TextBox).Text, (container.Panel1.Controls[hex_chkBox] as CheckBox).Checked, (container.Panel1.Controls[lf_chkBox] as CheckBox).Checked);
				//SendCommand((container.Panel1.Controls[txtName] as TextBox).Text, (container.Panel1.Controls[hex_chkBox] as CheckBox).Checked, false);
			}
			else if (container.Panel2.Controls[txtName] != null) {
				//SendCommand((container.Panel2.Controls[txtName] as TextBox).Text, (container.Panel2.Controls[hex_chkBox] as CheckBox).Checked, (container.Panel2.Controls[lf_chkBox] as CheckBox).Checked);
				//SendCommand((container.Panel2.Controls[txtName] as TextBox).Text, (container.Panel2.Controls[hex_chkBox] as CheckBox).Checked, false);
				Util.SendCommand(resp, client.GetStream(), (container.Panel2.Controls[txtName] as TextBox).Text, (container.Panel2.Controls[hex_chkBox] as CheckBox).Checked, (container.Panel2.Controls[lf_chkBox] as CheckBox).Checked);
			}
		}
		#endregion
	}
}
