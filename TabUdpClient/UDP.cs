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

namespace SerialTerminal.TCPTab {
    class UDPClient {
        private TcpClient client;
        public delegate void SetComButtDelegate(bool open);
        public static event SetComButtDelegate SetCommButt;

        private BlockingCollection<int> queuedRxBytes = new BlockingCollection<int>();
        private string Tcp_LogFileName = "";
        private System.IO.StreamWriter logFile;
        private RichTextBox logTB = null;
        public StringBuilder logBuffer = new StringBuilder();
        private Color logBufLastColor = Color.Black;
        private bool tcpTB_Update = false;
        private NetworkStream clientStream = null;
        private System.Timers.Timer timer = new System.Timers.Timer();
        private Thread rxThread = null;
        private SemaphoreSlim sbSemaphore = new SemaphoreSlim(1);

        public UDPClient(RichTextBox _tbLogtbLog) {
            logTB = _tbLogtbLog;
        }

        void StartLogging() {
            if (Tcp_LogFileName != "")
                return;

            if (Config.Data.Serial_LogDirectory == null ||
                (!Directory.Exists(Config.Data.Serial_LogDirectory) && !Config.Data.Serial_LogDirectory.Equals(""))) {
                Write("Error: Log folder no longer exists, changed to default", Color.Red, false);

                Config.Data.Serial_LogDirectory = "";
            }

            int num = 1;
            Tcp_LogFileName = "STerminal-TCP-" + DateTime.Now.ToString("yyyy-MM-dd");
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

            //start timer for updating serial port log tb
            timer.Elapsed += new ElapsedEventHandler(Timer_UpdateLog);
            timer.Interval = 50;    //100ms timer
            timer.AutoReset = true;
            timer.Start();

            rxThread = new Thread(new ThreadStart(() => DataHandle_Threaded()));
            rxThread.IsBackground = true;
            rxThread.Start();
        }

        void DataReceived_Threaded() {
            while (true) {
                try {
                    int b = clientStream.ReadByte();

                    if ((b >= 0 && b <= 0xFF) || b == -1) {
                        queuedRxBytes.Add(b);

                        if (b == -1) {
                            //remotely closed
                            return;
                        }
                    }
                }
                catch (Exception) {
                    //PreprocessAppend("TCP Connection closed?", Color.Red);
                    Close(null);
                    return;
                }
            }
        }

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

        public async void Open(object sender, EventArgs e, string ipAddress, string port) {
            client = new TcpClient();
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
                await client.ConnectAsync(ipAddress, port_num);
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

            if (client.Connected) {
                PreprocessAppend("Connected!\r\n", Color.Green);
                clientStream = client.GetStream();

                rxThread = new Thread(new ThreadStart(DataReceived_Threaded));
                rxThread.IsBackground = true;
                rxThread.Start();
            }
            else {
                SetCommButt(false);
            }
        }

        public void Close(string msg) {
            SetCommButt(false);

            clientStream = null;
            //client.Dispose();
            if (client != null) {
                lock (client)
                    client.Close();
            }

            if (msg == null) {
                PreprocessAppend("TCP Connection Closed.\r\n", Color.Red);
            }
        }

        public void Write_Click(object sender, EventArgs e, string text, Color txtColor) {
            Write(text, txtColor, true);
        }

        private void Write(string str, Color txtColor, bool sendCmd) {
            if (sendCmd) {
                if (client.Connected) {
                    //sp.Write(str);
                }
                else {
                    PreprocessAppend("Error, com port not opened", Color.Red);
                    return;
                }
            }
            else if (client == null || Tcp_LogFileName.Equals("")) {
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

            tcpTB_Update = true;
            await sbSemaphore.WaitAsync();
            Util.UpdateLog(logBuffer, str, txtColor, ref logBufLastColor);
            sbSemaphore.Release();
        }

        public void SendCommand(string str, bool hex, bool line_feed) {
            IProgress<Util.CmdResponse> resp = new Progress<Util.CmdResponse>((o) => PreprocessAppend(o));
            try {
                Util.SendCommand(resp, client.GetStream(), str, hex, line_feed);
            }
            catch (Exception) {
                resp.Report(new Util.CmdResponse("TCP connection not opened\r\n", Color.Red, true));
            }
        }

        #region Buttons
        public void InitButtons(SplitContainer container) {
            //serial form panel 1
            foreach (var ctrl in container.Panel1.Controls) {
                if (ctrl.GetType() == typeof(Button)) {
                    var btn = ctrl as Button;
                    btn.Click += (s, EventArgs) => { tabTcp_SendDataButtonClicked(s, EventArgs, container); };
                }
            }

            //serial form panel 2
            foreach (var ctrl in container.Panel2.Controls) {
                if (ctrl.GetType() == typeof(Button)) {
                    var btn = ctrl as Button;
                    btn.Click += (s, EventArgs) => { tabTcp_SendDataButtonClicked(s, EventArgs, container); };
                }
            }
        }


        public void tabTcp_SendDataButtonClicked(object sender, EventArgs e, SplitContainer container) {
            if (client == null) {
                return;
            }

            //MessageBox.Show((sender as Button).Name);
            var txtName = (sender as Button).Name.Replace("tabTcp_butSend", "tabTcp_tbSend");
            var hex_chkBox = txtName.Replace("tabTcp_tbSend", "tabTcp_cbHexSend");
            var lf_chkBox = txtName.Replace("tabTcp_tbSend", "tabTcp_cbLFSend");

            IProgress<Util.CmdResponse> resp = new Progress<Util.CmdResponse>((o) => PreprocessAppend(o));

            NetworkStream stream = null;
            try {
                stream = client.GetStream();
            }
            catch (System.InvalidOperationException) {
                //resp.Report(new Util.CmdResponse("TCP Connection collapsed. Likely server stopped.", Color.Red, true));
                Close("TCP Connection collapsed. Likely server crashed/timedout or internet dropped.");
                return;
            }

            if (container.Panel1.Controls[txtName] != null) {
                Util.SendCommand(resp, stream, (container.Panel1.Controls[txtName] as TextBox).Text, (container.Panel1.Controls[hex_chkBox] as CheckBox).Checked, (container.Panel1.Controls[lf_chkBox] as CheckBox).Checked);
            }
            else if (container.Panel2.Controls[txtName] != null) {
                Util.SendCommand(resp, stream, (container.Panel2.Controls[txtName] as TextBox).Text, (container.Panel2.Controls[hex_chkBox] as CheckBox).Checked, (container.Panel2.Controls[lf_chkBox] as CheckBox).Checked);
            }
        }
        #endregion
    }
}
