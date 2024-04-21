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

namespace SerialTerminal.TabUdpClient {
    class UDPClient {
        private UdpClient client = null;
        public delegate void SetComButtDelegate(bool open);
        public static event SetComButtDelegate SetCommButt;

        private BlockingCollection<int> queuedRxBytes = new BlockingCollection<int>();
        private string LogFileName = "";
        private System.IO.StreamWriter logFile;
        private RichTextBox logTB = null;
        public StringBuilder logBuffer = new StringBuilder();
        private Color logBufLastColor = Color.Black;
        private bool TB_Update = false;
        private System.Timers.Timer timer = new System.Timers.Timer();
        private Thread rxThread = null;
        private SemaphoreSlim sbSemaphore = new SemaphoreSlim(1);
        bool open = false;  //required - unlike comport/tcp no knowledge if this is open

        public UDPClient(RichTextBox _tbLogtbLog) {
            logTB = _tbLogtbLog;
        }

        void StartLogging() {
            if (LogFileName != "")
                return;

            if (Config.Data.Serial_LogDirectory == null ||
                (!Directory.Exists(Config.Data.Serial_LogDirectory) && !Config.Data.Serial_LogDirectory.Equals(""))) {
                Write("Error: Log folder no longer exists, changed to default", Color.Red, false);

                Config.Data.Serial_LogDirectory = "";
            }

            int num = 1;
            LogFileName = "STerminal-UDP-Client-" + DateTime.Now.ToString("yyyy-MM-dd");
            string serialLogExtension = ".log";

            while (true) {
                try {
                    logFile = new System.IO.StreamWriter(Config.Data.Serial_LogDirectory + LogFileName + serialLogExtension, true);
                    LogFileName += serialLogExtension;
                    break;
                }
                catch {
                    serialLogExtension = "_" + num.ToString() + ".log";
                    num++;
                }
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

        //void DataReceived_Threaded() {
        //    while (true) {
        //        try {
        //            int b = clientStream.ReadByte();

        //            if ((b >= 0 && b <= 0xFF) || b == -1) {
        //                queuedRxBytes.Add(b);

        //                if (b == -1) {
        //                    //remotely closed
        //                    return;
        //                }
        //            }
        //        }
        //        catch (Exception) {
        //            //PreprocessAppend("UDP Connection closed?", Color.Red);
        //            Close(null);
        //            return;
        //        }
        //    }
        //}

        private void DataHandle_Threaded() {
            while (true) {
                byte hex_byte = 0;

                //temporary. might end up doing smart highlighting on messages coming through
                try {
                    int b = queuedRxBytes.Take();
                    if (b == -1) {
                        Close(null);
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
            if (TB_Update && logBuffer.Length > 0) {
                try {
                    //block up to 1s
                    await sbSemaphore.WaitAsync();
                    TB_Update = false;
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
            return LogFileName;
        }

        public void Open(object sender, EventArgs e, string ipAddress, string port) {
            client = new UdpClient();
            //open new connection
            StartLogging();

            PreprocessAppend("Connecting...\r\n", Color.Blue);
            int port_num;
            bool result = int.TryParse(port, out port_num);
            if (!result || port_num < 0 || port_num > 0xFFFF) {
                PreprocessAppend("Bad Port number\r\n", Color.Red);
                return;
            }
            SetCommButt(true);

            try {
                client.Connect(ipAddress, port_num);
            }
            catch (Exception ex) {
                if (ex is SocketException) {
                    PreprocessAppend("Couldn't Connect: Bad host name\r\n", Color.Red);
                }
                else {
                    PreprocessAppend("Couldn't Connect: Unknown error\r\n", Color.Red);
                }
                SetCommButt(false);
                return;
            }

            PreprocessAppend("Connection likely established...!\r\n", Color.Green);
            //clientStream = client.rea
            this.open = true;

            Task.Run(async () => {
                while (this.open) {
                    try {
                        UdpReceiveResult rxResult = await client.ReceiveAsync();

                        foreach (var b in rxResult.Buffer) {
                            if ((b >= 0 && b <= 0xFF)) {
                                queuedRxBytes.Add(b);
                            }
                        }
                    }
                    catch (Exception) {
                        //something closed? never really sure...just ignore me =]
                        break;
                    }
                }
            });

            //rxThread = new Thread(new ThreadStart(DataReceived_Threaded));
            //rxThread.IsBackground = true;
            //rxThread.Start();
        }

        public void Close(string msg) {
            SetCommButt(false);
            this.open = false;

            //client.Dispose();
            if (client != null) {
                lock (client)
                    client.Close();
            }

            if (msg == null) {
                PreprocessAppend("UDP Connection Closed.\r\n", Color.Red);
            }
            client = null;
        }

        public void Write_Click(object sender, EventArgs e, string text, Color txtColor) {
            Write(text, txtColor, true);
        }

        private void Write(string str, Color txtColor, bool sendCmd) {
            if (sendCmd) {
                if (this.open) {
                    byte[] bytes = ASCIIEncoding.ASCII.GetBytes(str);
                    this.client.Send(bytes, bytes.Length);
                }
                else {
                    PreprocessAppend("Error, com port not opened", Color.Red);
                    return;
                }
            }
            else if (client == null || LogFileName.Equals("")) {
                System.Windows.Forms.MessageBox.Show("Bug!\r\n");
                return;
            }

            PreprocessAppend(str, txtColor);
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

            TB_Update = true;
            await sbSemaphore.WaitAsync();
            Util.UpdateLog(logBuffer, str, txtColor, ref logBufLastColor);
            sbSemaphore.Release();
        }

        public void SendCommand(string str, bool hex, bool line_feed) {
            IProgress<Util.CmdResponse> resp = new Progress<Util.CmdResponse>((o) => PreprocessAppend(o));
            try {
                MemoryStream stream = new MemoryStream();
                Util.SendCommand(resp, stream, str, hex, line_feed);
                byte[] bytes = stream.ToArray();
                client.Send(bytes, bytes.Length);
            }
            catch (Exception) {
                resp.Report(new Util.CmdResponse("UDP connection not opened\r\n", Color.Red, true));
            }
        }

        #region Buttons
        public void InitButtons(SplitContainer container) {
            //serial form panel 1
            foreach (var ctrl in container.Panel1.Controls) {
                if (ctrl.GetType() == typeof(Button)) {
                    var btn = ctrl as Button;
                    btn.Click += (s, EventArgs) => { tabUdpClient_SendDataButtonClicked(s, EventArgs, container); };
                }
            }

            //serial form panel 2
            foreach (var ctrl in container.Panel2.Controls) {
                if (ctrl.GetType() == typeof(Button)) {
                    var btn = ctrl as Button;
                    btn.Click += (s, EventArgs) => { tabUdpClient_SendDataButtonClicked(s, EventArgs, container); };
                }
            }
        }


        public void tabUdpClient_SendDataButtonClicked(object sender, EventArgs e, SplitContainer container) {
            if (client == null) {
                return;
            }

            //MessageBox.Show((sender as Button).Name);
            var txtName = (sender as Button).Name.Replace("tabUdpClient_butSend", "tabUdpClient_tbSend");
            var hex_chkBox = txtName.Replace("tabUdpClient_tbSend", "tabUdpClient_cbHexSend");
            var lf_chkBox = txtName.Replace("tabUdpClient_tbSend", "tabUdpClient_cbLFSend");

            IProgress<Util.CmdResponse> resp = new Progress<Util.CmdResponse>((o) => PreprocessAppend(o));


            MemoryStream stream = new MemoryStream();

            if (container.Panel1.Controls[txtName] != null) {
                Util.SendCommand(resp, stream, (container.Panel1.Controls[txtName] as TextBox).Text, (container.Panel1.Controls[hex_chkBox] as CheckBox).Checked, (container.Panel1.Controls[lf_chkBox] as CheckBox).Checked);
            }
            else if (container.Panel2.Controls[txtName] != null) {
                Util.SendCommand(resp, stream, (container.Panel2.Controls[txtName] as TextBox).Text, (container.Panel2.Controls[hex_chkBox] as CheckBox).Checked, (container.Panel2.Controls[lf_chkBox] as CheckBox).Checked);
            }

            byte[] bytes = stream.ToArray();
            client.Send(bytes, bytes.Length);
        }
        #endregion
    }
}
