using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SerialTerminal.SerialTab {
    class SerialTab {
        public delegate void SetComButtDelegate(bool open, string comPortName);
        public static event SetComButtDelegate SetCommButt;

        public delegate void CtsTriggeredDelegate(bool holding);
        public static event CtsTriggeredDelegate CtsTriggered;

        public delegate void DsrTriggeredDelegate(bool holding);
        public static event DsrTriggeredDelegate DsrTriggered;

        //serial port related definitions
        private System.IO.Ports.SerialPort sp = new SerialPort();
        //private object lockableObject = new object();
        //private bool closing = false;

        //other definitions
        private ComboBox comPortDropDown;

        private string Serial_LogFileName = "";
        private System.IO.StreamWriter logFile = null;
        private BlockingCollection<byte> queuedRxBytes = new BlockingCollection<byte>();
        private List<byte> receivedBytes = new List<byte>();
        private Thread rxThread = null;
        private Thread rxDataHandleThread = null;
        private Thread openPortThread = null;
        private RichTextBox logTB = null;
        public StringBuilder logBuffer = new StringBuilder();
        private Color logBufLastColor = Color.Black;
        private bool pauseLogUpdates = false;
        private bool timeStamp = false;
        private bool serialTB_Update = false;
        private bool dtrEnabled = false;
        private bool rtsEnabled = false;
        private bool portOpen = false;

        public class ButCloseArgs : EventArgs {
                public enum ButCloseSource {
                    BUTTON_CLOSE,
                    RX_EVENT,
                }

            public ButCloseSource Status { get; set; }
            public ButCloseArgs(bool button) {
                if (button) Status = ButCloseSource.BUTTON_CLOSE;
                else Status = ButCloseSource.RX_EVENT;
            }
        }


        private SemaphoreSlim sbSemaphore = new SemaphoreSlim(1);
		public SerialTab(ComboBox serial_ComDropDown, RichTextBox _logTB) {
			comPortDropDown = serial_ComDropDown;
			this.logTB = _logTB;
			sp.WriteTimeout = 1000;

			if (Config.Data.Serial_LogDirectory == null ||
				(!Directory.Exists(Config.Data.Serial_LogDirectory) && !Config.Data.Serial_LogDirectory.Equals(""))) {
				PreprocessAppend("Error: Log folder no longer exists, changed to default", Color.Red, false);

				Config.Data.Serial_LogDirectory = "";
			}

			rxDataHandleThread = new Thread(new ThreadStart(() => DataHandle_Threaded()));
			rxDataHandleThread.IsBackground = true;
			rxDataHandleThread.Start();

			//start timer for updating serial port log tb
			timer.Elapsed += new ElapsedEventHandler(Timer_UpdateLog);
			timer.Interval = 50;    //100ms timer
			timer.AutoReset = true;
			timer.Start();

            sp.PinChanged += Sp_PinChanged;
        }

		//update text box log 
		private System.Timers.Timer timer = new System.Timers.Timer();
		private async void Timer_UpdateLog(object source, ElapsedEventArgs e) {
			if (serialTB_Update && !pauseLogUpdates && logBuffer.Length > 0) {
				//block up to 1s
				await sbSemaphore.WaitAsync();
				serialTB_Update = false;
				try {
					logTB.Invoke((MethodInvoker)(delegate () {
						//logTB.Rtf = logBuffer.ToString() + "}";
						logTB.Rtf = logBuffer.ToString();
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

		//if pause is checked, log and buffer continue to update but the screen doesn't
		public void Pause(bool paused) {
			if (paused)
				pauseLogUpdates = true;
			else
				pauseLogUpdates = false;
		}


        //if pause is checked, log and buffer continue to update but the screen doesn't
        public void TimeStamp(bool en_time_stamp) {
            this.timeStamp = en_time_stamp;
        }

        
        public void serial_ComDropDown_Event(object sender, EventArgs e) {
			comPortDropDown.Items.Clear();

			try {
				ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");

				foreach (ManagementObject queryObj in searcher.Get()) {
					if ((queryObj["Caption"] != null) && (queryObj["Caption"].ToString().Contains("(COM"))) {
						comPortDropDown.Items.Add(String.Format("{0}", queryObj["Caption"]));
					}
				}
			}
			catch (ManagementException err) {
				MessageBox.Show(err.Message);
			}

			if (comPortDropDown.Items.Count == 0)
			{
                PreprocessAppend("No available comports found\n", Color.Red, true);
                return;
			}

			try {
				comPortDropDown.DropDownWidth = Util.DropDownWidth(comPortDropDown);
			}
			catch (Exception e1) {
				PreprocessAppend("DropDown width error: " + e1.InnerException.ToString() + "\n", Color.Red, true);
			}
		}

		//used for open directory or open file in right-click context menu
		public string GetLogFileName() {
			return Serial_LogFileName;
		}

		public bool IsOpen() {
			return sp.IsOpen;
		}

		void DataReceived_Threaded() {
			while (true) {
				try {
					int b = -1;

					b = sp.ReadByte();

					if (b >= 0 && b <= 0xFF) {
						queuedRxBytes.Add((byte)b);
					}
				}
				catch (Exception) {
                    //port closed due to some err? let ui know
                    buttonCloseComms_Click(this, new ButCloseArgs(false));
                    return;
				}
			}
		}

		private void DataHandle_Threaded() {
			while (true) {
				byte hex_byte = 0;

				//temporary. might end up doing smart highlighting on messages coming through
				try {
					hex_byte = queuedRxBytes.Take();
				}
				catch (Exception) {
					continue;
				}

				//color = Color.Gray;
				if ((Config.Data.Serial_DisplayLevel == GLOBAL.HEX_LEVEL_NONE) || (Config.Data.Serial_DisplayLevel == GLOBAL.HEX_LEVEL_NORMAL)) {
					if ((hex_byte == '\n') || (hex_byte == '\t') || ((hex_byte >= 0x20) && (hex_byte <= 0x7E))) {
						string tmpString = new string((char)hex_byte, 1);
						PreprocessAppend(tmpString, Color.Black, false);
                        if (hex_byte == '\n' && this.timeStamp) {
                            PreprocessAppend(DateTime.Now.ToString() + ": ", Color.Black, false);
                        }
					}
					else if ((Config.Data.Serial_DisplayLevel == GLOBAL.HEX_LEVEL_NORMAL) && (hex_byte != '\r')) {
						PreprocessAppend("{" + Util.ByteToHexBitFiddle(hex_byte) + "}", Color.Gray, false);
					}
				}
				else if ((Config.Data.Serial_DisplayLevel == GLOBAL.HEX_LEVEL_ALL) || (Config.Data.Serial_DisplayLevel == GLOBAL.HEX_LEVEL_ALL_EXCEPT_NL)) {
					if ((Config.Data.Serial_DisplayLevel == GLOBAL.HEX_LEVEL_ALL_EXCEPT_NL) && ((hex_byte == '\n') || (hex_byte == '\r'))) {
						if (hex_byte == '\n') {
							string tmpString = new string((char)hex_byte, 1);
							PreprocessAppend(tmpString, Color.Black, false);
						}
					}
					else {
						PreprocessAppend("{" + Util.ByteToHexBitFiddle(hex_byte) + "}", Color.Gray, false);
					}
				}

				receivedBytes.Clear();
			}
		}

		public void InitLogFile() {
			if (logFile == null) {
				int num = 1;
				Serial_LogFileName = "STerminal-Serial-" + DateTime.Now.ToString("yyyy-MM-dd");
				string serialLogExtension = ".log";

				while (true) {
					try {
						logFile = new System.IO.StreamWriter(Config.Data.Serial_LogDirectory + Serial_LogFileName + serialLogExtension, true);
						Serial_LogFileName += serialLogExtension;
						break;
					}
					catch {
						serialLogExtension = "_" + num.ToString() + ".log";
						num++;
					}
				}

				logFile.Write("\r\n============================ " + DateTime.Now.ToString() + " ============================\r\n"); //write the current date to the file. change this with your date or something.
				logFile.Flush();
			}
		}


		public void PreprocessAppend(Util.CmdResponse resp) {
			PreprocessAppend(resp.str, resp.color, resp.nl_check);
		}

		public async void PreprocessAppend(string str, Color txtColor, bool newLineCheck) {
			InitLogFile();

			logFile.Write(str);
			logFile.Flush();

			serialTB_Update = true;
			await sbSemaphore.WaitAsync();
			Util.UpdateLog(logBuffer, str, txtColor, ref logBufLastColor);
			sbSemaphore.Release();
		}
		//not currently used
		//         private void serialPort1_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
		//         {
		//             if (e.EventType == System.IO.Ports.SerialPinChange.Break)
		//             {
		//                 AppendTextBox(serialTextBox, "PinChange.Break\r\n", Color.Red);
		//             }
		//             else if (e.EventType == System.IO.Ports.SerialPinChange.CDChanged)
		//             {
		//                 AppendTextBox(serialTextBox, "PinChange.CDChanged\r\n", Color.Red);
		//             }
		//             else if (e.EventType == System.IO.Ports.SerialPinChange.CtsChanged)
		//             {
		//                 AppendTextBox(serialTextBox, "PinChange.CtsChanged\r\n", Color.Red);
		//             }
		//             else if (e.EventType == System.IO.Ports.SerialPinChange.DsrChanged)
		//             {
		//                 AppendTextBox(serialTextBox, "PinChange.DsrChanged\r\n", Color.Red);
		//             }
		//             else if (e.EventType == System.IO.Ports.SerialPinChange.Ring)
		//             {
		//                 AppendTextBox(serialTextBox, "PinChange.Ring\r\n", Color.Red);
		//             }
		//         }


		public void buttonOpenComms_Click(object sender, EventArgs e, string com_port, string baud_rate, string data_bits, Parity parity, StopBits stop_bits) {
			try {
				InitLogFile();
				Config.Data.ComPort = com_port;

				string com_port_tmp = com_port.ToLower();
                Regex rgx = new Regex(@"^.*\((com\d+)\)$");
                Regex rgxAlt = new Regex(@"^(com\d+)$");
                Match mtch = rgx.Match(com_port_tmp);
                Match mtchAlt = rgxAlt.Match(com_port_tmp);

				if (mtch.Success) {
                    sp.PortName = mtch.Groups[1].Value;
                }
				else if (mtchAlt.Success)
                {
                    sp.PortName = mtchAlt.Groups[1].Value;
                }
                else {
                    PreprocessAppend($"Cannot Open: '{Config.Data.ComPort}'. Bad com port name\r\n", Color.Red, true);
                    return;
                }

                

				int baud;
				if (!int.TryParse(baud_rate, out baud)) {
					PreprocessAppend("Cannot Open: " + Config.Data.ComPort + ". Bad baud rate\r\n", Color.Red, true);
					return;
				}

				int db;
				if (!int.TryParse(data_bits, out db) || !(db == 7 || db == 8)) {
					PreprocessAppend("Cannot Open: " + Config.Data.ComPort + ". Bad data bit setting\r\n", Color.Red, true);
					return;
				}

				sp.BaudRate = baud;
				sp.DataBits = db;
				sp.Parity = parity;
				sp.StopBits = stop_bits;
				sp.DtrEnable = this.dtrEnabled;
				sp.RtsEnable = this.rtsEnabled;

				//serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceived_Event);
                this.openPortThread = new Thread(new ThreadStart(() => {
                    try {
                        sp.Open();
                        SetCommButt(true, com_port);

                        rxThread = new Thread(new ThreadStart(DataReceived_Threaded));
                        rxThread.IsBackground = true;
                        rxThread.Start();

                        //SerialComPortStatus = GLOBAL.COM_OPEN;
                        PreprocessAppend($"Comport Opened '{Config.Data.ComPort}'\r\n", Color.Green, true);

                        this.portOpen = true;
                    }
                    catch (Exception err) {
                        if (err is IOException && err.Message.ToString().StartsWith("The parameter is incorrect."))
                        {
                            PreprocessAppend($"Cannot Open '{Config.Data.ComPort}' port - parameter error. Check Stop and parity bits.\r\n", Color.Red, true);
                        }
                        else
                        {
                            PreprocessAppend($"Cannot Open '{Config.Data.ComPort}' port not available\r\n", Color.Red, true);
                        }
                    }
                    openPortThread = null;  //finished!
                }));
                this.openPortThread.Start();
			}
            catch (Exception) {
                if (stop_bits == StopBits.None)
                {
                    PreprocessAppend($"Cannot Open '{Config.Data.ComPort}' stop bits == 0 not supported\r\n", Color.Red, true);
                }
                else
                {
                    PreprocessAppend($"Cannot Open '{Config.Data.ComPort}' unknown error\r\n", Color.Red, true);
                }
            }
        }

        private void Sp_PinChanged(object sender, SerialPinChangedEventArgs e) {
            switch(e.EventType) {
                case SerialPinChange.CtsChanged:
                    if (CtsTriggered != null) {
                        CtsTriggered(sp.CtsHolding);
                    }
                    break;
                case SerialPinChange.DsrChanged:
                    if (DsrTriggered != null) {
                        DsrTriggered(sp.DsrHolding);
                    }
                    break;
                default:
                    break;
            }
        }

        public void buttonCloseComms_Click(object sender, ButCloseArgs e) {
            if (!this.portOpen) {
                return;
            }

            this.portOpen = false;

            try {
                if (this.openPortThread != null) {
                    this.openPortThread.Abort();
                }

                if (sp.IsOpen) {
                    sp.Close();
                }
            }
            catch (Exception err) {
				PreprocessAppend("Closing err - likely already closed\n", Color.Red, true);
            }

            SetCommButt(false, "");

            if (e.Status == ButCloseArgs.ButCloseSource.BUTTON_CLOSE)
                PreprocessAppend("Comport Closed\r\n", Color.Red, true);
            else
                PreprocessAppend("Comport Closed - Did the device disconnect?\r\n", Color.Red, true);
        }
		/// <summary>
		/// /////////////////////////////////////////////////////////////////////////////////
		/// </summary>1
		//process button click or hotkey
		private class cSendCommand {
			public string str;
			public bool hex;
			public bool line_feed;
			public cSendCommand(string str, bool hex, bool line_feed) {
				this.str = str;
				this.hex = hex;
				this.line_feed = line_feed;
			}
		}

		public void bootloaderProgram_Click(object sender, EventArgs e) {

		}

		public void rtsCheckBox_CheckedChanged(object sender, EventArgs e, bool cb_checked) {
			this.rtsEnabled = cb_checked;
			if (sp != null && sp.IsOpen)
				sp.RtsEnable = cb_checked;
		}

		public void dtrCheckBox_CheckedChanged(object sender, EventArgs e, bool cb_checked) {
			this.dtrEnabled = cb_checked;
			try {
				if (sp != null && sp.IsOpen)
					sp.DtrEnable = cb_checked;
			}
			catch (System.IO.IOException) {
				PreprocessAppend("Comport IO Err\r\n", Color.Orange, true);
			}
		}

		#region Main Buttons
		public void InitButtons(SplitContainer container) {
			//serial form panel 1
			foreach (var ctrl in container.Panel1.Controls) {
				if (ctrl.GetType() == typeof(Button)) {
					var btn = ctrl as Button;
					btn.Click += (s, EventArgs) => { serialTab_SendDataButtonClicked(s, EventArgs, container); };
				}
			}

			//serial form panel 2
			foreach (var ctrl in container.Panel2.Controls) {
				if (ctrl.GetType() == typeof(Button)) {
					var btn = ctrl as Button;
					btn.Click += (s, EventArgs) => { serialTab_SendDataButtonClicked(s, EventArgs, container); };
				}
			}
		}


		public void SendCommand(string str, bool hex, bool line_feed) {
			IProgress<Util.CmdResponse> resp = new Progress<Util.CmdResponse>((o) => PreprocessAppend(o));
			try {
				Util.SendCommand(resp, sp.BaseStream, str, hex, line_feed);
			}
			catch (Exception) {
				resp.Report(new Util.CmdResponse("Comport not opened\r\n", Color.Red, true));
			}
		}

		public void serialTab_SendDataButtonClicked(object sender, EventArgs e, SplitContainer container) {
			//MessageBox.Show((sender as Button).Name);
			var txtName = (sender as Button).Name.Replace("tabSerial_butSend", "tabSerial_tbSend");
			var hex_chkBox = txtName.Replace("tabSerial_tbSend", "tabSerial_cbHexSend");
			var lf_chkBox = txtName.Replace("tabSerial_tbSend", "tabSerial_cbLFSend");

			IProgress<Util.CmdResponse> resp = new Progress<Util.CmdResponse>((o) => PreprocessAppend(o));

			try {
				if (container.Panel1.Controls[txtName] != null) {
					Util.SendCommand(resp, sp.BaseStream, (container.Panel1.Controls[txtName] as TextBox).Text, (container.Panel1.Controls[hex_chkBox] as CheckBox).Checked, (container.Panel1.Controls[lf_chkBox] as CheckBox).Checked);
				}
				else if (container.Panel2.Controls[txtName] != null) {
					Util.SendCommand(resp, sp.BaseStream, (container.Panel2.Controls[txtName] as TextBox).Text, (container.Panel2.Controls[hex_chkBox] as CheckBox).Checked, (container.Panel2.Controls[lf_chkBox] as CheckBox).Checked);
				}
			}
			catch (Exception) {
				resp.Report(new Util.CmdResponse("Comport not opened\r\n", Color.Red, true));
			}
		}
		#endregion
	}
}
