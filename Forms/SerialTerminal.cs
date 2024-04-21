using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Timers;
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.2.2.2")]
[assembly: AssemblyFileVersion("1.2.2.2")]



namespace SerialTerminal.Main {
    public partial class MainForm : Form {
        //////////////////////////////////////////////////////////////
        //  intialise auxiliary classes
        //SerialInterface.Serial.Processing serialProcessing;

        private SerialTab.SerialTab cSerial;
        private TCPTab.TCPClient cTcp;
        private TabTCPServer.TCPServer cTcpSvr;
        private TabUdpClient.UDPClient cUdpClient;
        private UtilTab.Util cUtil;
        private ProgTab.Programmer cProg;

        private string Version_Number;

        public MainForm() {
            InitializeComponent();
        }

        #region TRY ME GAWD DAMNIT
        /* https://social.msdn.microsoft.com/Forums/en-US/ce8ce1a3-64ed-4f26-b9ad-e2ff1d3be0a5/serial-port-hangs-whilst-closing?forum=Vsexpressvcs
		 nobugz wrote:
		Try this:

		Code Snippet
		private: 
		System::Void Form1_FormClosing(System::Object^ sender, System::Windows::Forms::FormClosingEventArgs^ e) {
		if (serialPort1->IsOpen) {
		e->Cancel = true;
		Thread^ CloseDown = gcnew Thread(gcnew ThreadStart(this, &Form1::CloseSerialOnExit));
		CloseDown->Start();
		}
		}
		void CloseSerialOnExit() {
		try {
		serialPort1->Close();
		this->Invoke(gcnew MethodInvoker(this, &Form1::NowClose));
		}
		catch (Exception^ ex) {
		MessageBox::Show(ex->Message);
		}
		}
		void NowClose() {
		this->Close();
		}
		*/
        #endregion

        private void SerialTerminal_Load(object sender, EventArgs e) {
            #region Deserialise XML
            //Load confirguration settings
            if ((Config.DeserializeFromXML() == 0) && (Config.Data != null)) {
                tabSerial_ddBaudRate.SelectedIndex = tabSerial_ddBaudRate.FindString(Config.Data.BaudRate.ToString());
                tabSerial_ddComPort.Text = Config.Data.ComPort.ToString();
                tabSerial_ddDataBits.SelectedIndex = tabSerial_ddDataBits.FindString(Config.Data.DataBits.ToString());
                tabSerial_ddParity.SelectedIndex = tabSerial_ddParity.FindString(Config.Data.Parity.ToString());
                tabSerial_ddStopBits.SelectedIndex = tabSerial_ddStopBits.FindString(Config.Data.StopBits.ToString());

                for (int i = 0; i < 16; i++) {
                    if (Config.Data.SerialTextBox?.Length > 0)
                        this.Controls.Find("tabSerial_tbSend" + (i + 1), true)[0].Text = Config.Data.SerialTextBox[i];

                    if (Config.Data.SerialHexCB?.Length > 0)
                        ((CheckBox)this.Controls.Find("tabSerial_cbHexSend" + (i + 1), true)[0]).Checked = Config.Data.SerialHexCB[i];

                    if (Config.Data.SerialLFCB?.Length > 0)
                        ((CheckBox)this.Controls.Find("tabSerial_cbLFSend" + (i + 1), true)[0]).Checked = Config.Data.SerialLFCB[i];
                }

                /////////////////
                // TCP Client config
                tabTcpClient_tbIPAddr.Text = Config.Data.TcpClientIPAddr;
                if (Config.Data.TcpClientPort?.Length <= tabTcpClient_tbPort.MaxLength)
                    tabTcpClient_tbPort.Text = Config.Data.TcpClientPort;

                for (int i = 0; i < 16; i++) {
                    if (Config.Data.TcpClientTextBox?.Length > 0)
                        this.Controls.Find("tabTcp_tbSend" + (i + 1), true)[0].Text = Config.Data.TcpClientTextBox[i];

                    if (Config.Data.TcpClientHexCB?.Length > 0)
                        ((CheckBox)this.Controls.Find("tabTcp_cbHexSend" + (i + 1), true)[0]).Checked = Config.Data.TcpClientHexCB[i];

                    if (Config.Data.TcpClientLFCB?.Length > 0)
                        ((CheckBox)this.Controls.Find("tabTcp_cbLFSend" + (i + 1), true)[0]).Checked = Config.Data.TcpClientLFCB[i];
                }

                /////////////////
                // TCP Server config
                if (Config.Data.TcpSvrPort?.Length <= tabTcpSvr_tbPort.MaxLength)
                    tabTcpSvr_tbPort.Text = Config.Data.TcpSvrPort;

                for (int i = 0; i < 16; i++) {
                    if (Config.Data.TcpSvrTextBox?.Length > 0)
                        this.Controls.Find("tabTcp_tbSend" + (i + 1), true)[0].Text = Config.Data.TcpSvrTextBox[i];

                    if (Config.Data.TcpSvrHexCB?.Length > 0)
                        ((CheckBox)this.Controls.Find("tabTcp_cbHexSend" + (i + 1), true)[0]).Checked = Config.Data.TcpSvrHexCB[i];

                    if (Config.Data.TcpSvrLFCB?.Length > 0)
                        ((CheckBox)this.Controls.Find("tabTcp_cbLFSend" + (i + 1), true)[0]).Checked = Config.Data.TcpSvrLFCB[i];
                }
            }
            else {
                //force defaults
                Config.Data.Serial_DisplayLevel = GLOBAL.HEX_LEVEL_NORMAL;
                Config.Data.TcpClient_DisplayLevel = GLOBAL.HEX_LEVEL_NORMAL;
                Config.Data.TcpSvr_DisplayLevel = GLOBAL.HEX_LEVEL_NORMAL;
            }
            #endregion
            ///////////////////////////////////////////////////////
            // Serial Tab
            #region SERIAL
            //check to ensure default values exist
            if (tabSerial_ddComPort.Text == "") {
                tabSerial_ddComPort.Text = "COM1";
                Config.Data.ComPort = "COM1";
            }

            if (tabSerial_ddBaudRate.SelectedIndex == -1) {
                tabSerial_ddBaudRate.SelectedIndex = tabSerial_ddBaudRate.FindString("115200");
                Config.Data.BaudRate = "115200";
            }

            if (tabSerial_ddDataBits.SelectedIndex == -1) {
                tabSerial_ddDataBits.SelectedIndex = tabSerial_ddDataBits.FindString("8");
                Config.Data.DataBits = "8";
            }

            if (tabSerial_ddParity.SelectedIndex == -1) {
                tabSerial_ddParity.SelectedIndex = tabSerial_ddParity.FindString(System.IO.Ports.Parity.None.ToString());
                Config.Data.Parity = System.IO.Ports.Parity.None.ToString();
            }

            if (tabSerial_ddStopBits.SelectedIndex == -1) {
                tabSerial_ddStopBits.SelectedIndex = tabSerial_ddStopBits.FindString("1");
                Config.Data.StopBits = System.IO.Ports.StopBits.One.ToString();
            }

            if (Config.Data.Serial_LogDirectory == null)
                Config.Data.Serial_LogDirectory = "";

            cSerial = new SerialTab.SerialTab(tabSerial_ddComPort, tabSerial_tbLog);
            cSerial.InitButtons(this.tabSerial_splitContainer1);
            tabSerial_ddComPort.DropDown += new System.EventHandler(cSerial.serial_ComDropDown_Event);

            tabSerial_butSerialProg.Click += (s, EventArgs) => { cSerial.bootloaderProgram_Click(s, EventArgs); };
            tabSerial_butOpen.Click += (s, EventArgs) => { cSerial.buttonOpenComms_Click(s, EventArgs, tabSerial_ddComPort.Text, tabSerial_ddBaudRate.Text, tabSerial_ddDataBits.Text, (System.IO.Ports.Parity)tabSerial_ddParity.SelectedIndex, (System.IO.Ports.StopBits)tabSerial_ddStopBits.SelectedIndex); };
            tabSerial_butClose.Click += (s, EventArgs) => { cSerial.buttonCloseComms_Click(s, new SerialTab.SerialTab.ButCloseArgs(true)); };
            tabSerial_cbRTS.CheckedChanged += (s, EventArgs) => { cSerial.rtsCheckBox_CheckedChanged(s, EventArgs, tabSerial_cbRTS.Checked); };
            tabSerial_cbDTR.CheckedChanged += (s, EventArgs) => { cSerial.dtrCheckBox_CheckedChanged(s, EventArgs, tabSerial_cbDTR.Checked); };
            tabSerial_cbPause.CheckedChanged += (s, EventArgs) => { cSerial.Pause(tabSerial_cbPause.Checked); };
            tabSerial_cbTimeStamp.CheckedChanged += (s, EventArgs) => { cSerial.TimeStamp(tabSerial_cbTimeStamp.Checked); };

            if (Config.Data.Serial_DisplayLevel == GLOBAL.HEX_LEVEL_NONE) {
                tabSerial_rightClick_NoSpecial.Checked = true;
            }
            else if (Config.Data.Serial_DisplayLevel == GLOBAL.HEX_LEVEL_ALL_EXCEPT_NL) {
                tabSerial_rightClick_AllButNL.Checked = true;
            }
            else if (Config.Data.Serial_DisplayLevel == GLOBAL.HEX_LEVEL_ALL) {
                tabSerial_rightClick_AllHEX.Checked = true;
            }
            else {
                tabSerial_rightClick_Normal.Checked = true;
                Config.Data.Serial_DisplayLevel = GLOBAL.HEX_LEVEL_NORMAL;  //force default if anything happens
            }

            SerialTab.SerialTab.SetCommButt += delegate (bool open, string comPortName) {
                this.Invoke((MethodInvoker)(delegate () {
                    if (open) {
                        tabSerial_butOpen.Enabled = false;
                        tabSerial_butClose.Enabled = true;
                        //search for "serial" tab in tabcontrol
                        foreach (TabPage tab in tabControl.TabPages) {
                            if (tab.Name == "tabSerial") {
                                tab.Text = "Serial - " + comPortName;
                                break;
                            }
                        }
                    }
                    else {
                        tabSerial_butOpen.Enabled = true;
                        tabSerial_butClose.Enabled = false;

                        //search for "serial" tab in tabcontrol
                        foreach (TabPage tab in tabControl.TabPages) {
                            if (tab.Name == "tabSerial") {
                                tab.Text = "Serial";
                                break;
                            }
                        }
                    }
                    ProcessAdvancedSettings();
                }));
            };

            //default:
            this.tabSerial_panCTS.BackColor = Color.White;
            SerialTab.SerialTab.CtsTriggered += delegate (bool holding) {
                this.Invoke((MethodInvoker)(delegate () {
                    if (holding)
                        this.tabSerial_panCTS.BackColor = Color.Green;
                    else
                        this.tabSerial_panCTS.BackColor = Color.White;
                }));
            };

            //default:
            this.tabSerial_panDSR.BackColor = Color.White;
            SerialTab.SerialTab.DsrTriggered += delegate (bool holding) {
                this.Invoke((MethodInvoker)(delegate () {
                    if (holding)
                        this.tabSerial_panDSR.BackColor = Color.Green;
                    else
                        this.tabSerial_panDSR.BackColor = Color.White;
                }));
            };



            #endregion

            //////////////////////////////////////
            // TCP Tab
            #region TCP Client
            cTcp = new TCPTab.TCPClient(tabTcpClient_tbLog);

            if (Config.Data.TcpClient_DisplayLevel == GLOBAL.HEX_LEVEL_NONE) {
                tabTcpClient_RightClick_TxtDisp_None.Checked = true;
            }
            else if (Config.Data.TcpClient_DisplayLevel == GLOBAL.HEX_LEVEL_ALL_EXCEPT_NL) {
                tabTcpClient_RightClick_TxtDisp_AllHexExceptNL.Checked = true;
            }
            else if (Config.Data.TcpClient_DisplayLevel == GLOBAL.HEX_LEVEL_ALL) {
                tabTcpClient_RightClick_TxtDisp_AllHex.Checked = true;
            }
            else {
                tabTcpClient_RightClick_TxtDisp_Normal.Checked = true;
                Config.Data.TcpClient_DisplayLevel = GLOBAL.HEX_LEVEL_NORMAL;  //force default if anything happens
            }

            cTcp.InitButtons(this.tabTcp_splitContainer);
            tabTcp_butOpen.Click += (s, EventArgs) => { cTcp.Open(s, EventArgs, tabTcpClient_tbIPAddr.Text, tabTcpClient_tbPort.Text); };
            tabTcp_butClose.Click += (s, EventArgs) => { cTcp.Close(null); };

            //TCPTab.TCP.AppendTCP += delegate (string data, Color txtColor, bool newLineCheck) {
            //	this.BeginInvoke((MethodInvoker)(delegate () {
            //		if (newLineCheck && (tabSerial_tbLog.Text != "") && (tabSerial_tbLog.Text[tabSerial_tbLog.TextLength - 1] != '\r') && (tabSerial_tbLog.Text[tabSerial_tbLog.TextLength - 1] != '\n')) {
            //			data = "\n" + data;
            //		}

            //		Util.AppendRTB(tabTcp_tbLog, data, txtColor);
            //	}));
            //};

            TCPTab.TCPClient.SetCommButt += delegate (bool open) {
                this.BeginInvoke((MethodInvoker)(delegate () {
                    tabTcp_butOpen.Enabled = !open;
                    tabTcp_butClose.Enabled = open;
                }));
            };
            #endregion

            //////////////////////////////////////
            // TCP Server
            #region TCP Server
            cTcpSvr = new TabTCPServer.TCPServer(this.tabTcpSvr_lbClientList, tabTcpSvr_tbLog);
            if (Config.Data.TcpSvr_DisplayLevel == GLOBAL.HEX_LEVEL_NONE) {
                tabTcpSvr_RightClick_TxtDisp_None.Checked = true;
            }
            else if (Config.Data.TcpSvr_DisplayLevel == GLOBAL.HEX_LEVEL_ALL_EXCEPT_NL) {
                tabTcpSvr_RightClick_TxtDisp_AllHexExceptNL.Checked = true;
            }
            else if (Config.Data.TcpSvr_DisplayLevel == GLOBAL.HEX_LEVEL_ALL) {
                tabTcpSvr_RightClick_TxtDisp_AllHex.Checked = true;
            }
            else {
                tabTcpSvr_RightClick_TxtDisp_Normal.Checked = true;
                Config.Data.TcpSvr_DisplayLevel = GLOBAL.HEX_LEVEL_NORMAL;  //force default if anything happens
            }

            cTcpSvr.InitButtons(this.tabTcpSvr_splitContainer);

            tabTcpSvr_butOpen.Click += (s, EventArgs) => { cTcpSvr.Open(s, EventArgs, tabTcpSvr_tbPort.Text); };
            tabTcpSvr_butClose.Click += (s, EventArgs) => { cTcpSvr.Close(); };
            //tabTcpSvr_butClear.Click += (s, EventArgs) => { tabTcpSvr_tbLog.Clear(); };	//predefined
            tabTcpSvr_RightClick_Clear.Click += (s, EventArgs) => { tabTcpSvr_tbLog.Clear(); };
            tabTcpSvr_butDisconnect.Click += (s, EventArgs) => { cTcpSvr.Disconnect(tabTcpSvr_lbClientList.SelectedItem); };

            TabTCPServer.TCPServer.SetCommButt += delegate (bool open) {
                this.BeginInvoke((MethodInvoker)(delegate () {
                    tabTcpSvr_butOpen.Enabled = !open;
                    tabTcpSvr_butClose.Enabled = open;
                    tabTcpSvr_tbPort.Enabled = !open;
                }));
            };
            #endregion

            //////////////////////////////////////
            // UDP Client
            #region UDP Client
            cUdpClient = new TabUdpClient.UDPClient(tabUdpClient_tbLog);

            if (Config.Data.UdpClient_DisplayLevel == GLOBAL.HEX_LEVEL_NONE) {
                tabUdpClient_RightClick_TxtDisp_None.Checked = true;
            }
            else if (Config.Data.UdpClient_DisplayLevel == GLOBAL.HEX_LEVEL_ALL_EXCEPT_NL) {
                tabUdpClient_RightClick_TxtDisp_AllHexExceptNL.Checked = true;
            }
            else if (Config.Data.UdpClient_DisplayLevel == GLOBAL.HEX_LEVEL_ALL) {
                tabUdpClient_RightClick_TxtDisp_AllHex.Checked = true;
            }
            else {
                tabUdpClient_RightClick_TxtDisp_Normal.Checked = true;
                Config.Data.UdpClient_DisplayLevel = GLOBAL.HEX_LEVEL_NORMAL;  //force default if anything happens
            }

            cUdpClient.InitButtons(this.tabUdpClient_splitContainer);
            tabUdpClient_butOpen.Click += (s, EventArgs) => { cUdpClient.Open(s, EventArgs, tabUdpClient_tbIPAddr.Text, tabUdpClient_tbPort.Text); };
            tabUdpClient_butClose.Click += (s, EventArgs) => { cUdpClient.Close(null); };

            //TabUdpClient.UDPClient.AppendTCP += delegate (string data, Color txtColor, bool newLineCheck) {
            //	this.BeginInvoke((MethodInvoker)(delegate () {
            //		if (newLineCheck && (tabSerial_tbLog.Text != "") && (tabSerial_tbLog.Text[tabSerial_tbLog.TextLength - 1] != '\r') && (tabSerial_tbLog.Text[tabSerial_tbLog.TextLength - 1] != '\n')) {
            //			data = "\n" + data;
            //		}

            //		Util.AppendRTB(tabTcp_tbLog, data, txtColor);
            //	}));
            //};

            TabUdpClient.UDPClient.SetCommButt += delegate (bool open) {
                this.BeginInvoke((MethodInvoker)(delegate () {
                    tabUdpClient_butOpen.Enabled = !open;
                    tabUdpClient_butClose.Enabled = open;
                }));
            };
            #endregion

            ///////////////////////////////////////////////////////
            // Programmer Tab
            #region PROGRAMMER
            cProg = new ProgTab.Programmer();
            this.tabProg_tbSpiFile.Text = ProgTab.Programmer.UpdateFileName(Config.Data.Prog_Firmware_SPI);

            this.tabProg_butSpiBrowse.Click += (s, EventArgs) => { cProg.browse100_Click(s, EventArgs); };

            this.tabProg_butSpiStart.Click += (s, EventArgs) => { cProg.StartProg_100_Click(s, EventArgs); };

            this.tabProg_butSpiStop.Click += (s, EventArgs) => { cProg.stop_Button_Click(s, EventArgs); };
            this.tabProg_ButClearLog.Click += (s, EventArgs) => { cProg.ClearTB_Click(s, EventArgs); };

            // delegates
            ProgTab.Programmer.ClearTB_Event += delegate () { this.Invoke((MethodInvoker)(delegate () { prog_Log_TB.Clear(); })); };
            //ProgTab.Programmer.SetHex100_TB += delegate (string data) { this.Invoke((MethodInvoker)(delegate () { tabProg_tbSpiFile.Text = data; })); };
            ProgTab.Programmer.AppendLog_TB += delegate (string data, Color txtColor) {
                this.Invoke((MethodInvoker)(delegate () { Util.AppendRTB(prog_Log_TB, data, txtColor); }));
            };
            ProgTab.Programmer.SetLog_TB += delegate (string data, Color txtColor) {
                this.Invoke((MethodInvoker)(delegate () {
                    //check if app was force quit
                    //silly work around to try and get it on the same line!
                    if (data[0] == '-' || data[0] == '#') {
                        int start = prog_Log_TB.Text.LastIndexOf('\n') + 1;
                        int end = prog_Log_TB.TextLength;
                        prog_Log_TB.SelectionStart = start;
                        prog_Log_TB.Text = prog_Log_TB.Text.Substring(0, start) + data;

                        prog_Log_TB.Select(start, end - start);
                        prog_Log_TB.SelectionColor = txtColor;

                        //reset color to defaults
                        prog_Log_TB.SelectionLength = 0;
                        prog_Log_TB.SelectionColor = tabSerial_tbLog.ForeColor;
                    }
                    else {
                        if (prog_Log_TB.Text.Length > 0) {
                            prog_Log_TB.AppendText("\n");
                        }

                        Util.AppendRTB(prog_Log_TB, data + "\n", txtColor);
                    }
                }));
            };

            ProgTab.Programmer.StopProg_Button += delegate (bool enable) { this.Invoke((MethodInvoker)(delegate () { tabProg_butSpiStop.Enabled = enable; })); };

            ProgTab.Programmer.StartProg_Button += delegate (string text, bool enable) {
                this.Invoke((MethodInvoker)(delegate () {
                    this.tabProg_butSpiStart.Text = text;
                    this.tabProg_butSpiStart.Enabled = enable;
                }));
            };

            ProgTab.Programmer.RestartTimer += delegate () {
                this.BeginInvoke((MethodInvoker)(delegate () {
                    cProg.serialTimer.Stop();
                    cProg.serialTimer.Start();
                }));
            };
            #endregion

            //////////////////////////////////////
            // Utilities Tab
            #region Utilities
            cUtil = new UtilTab.Util();
            tabUtil_IMEIConv_But.Click += (s, EventArgs) => { cUtil.GetImeiCrc_Click(s, EventArgs, crc_IMEIToSend_TB.Text); };
            tabUtil_butSimGetInfo.Click += (s, EventArgs) => { cUtil.CheckSimNum(tabUtil_tbSimInput.Text); };
            tabUtil_butCrcAscii.Click += (s, EventArgs) => { cUtil.CalcAsciiCrc(tabUtil_tbCrcAsciiEntry.Text, tabUtil_tbCrcAsciiAnswer); };
            tabUtil_butCrcHexAscii.Click += (s, EventArgs) => { cUtil.CalcHexAsciiCrc(tabUtil_tbCrcHexAsciiEntry.Text, tabUtil_tbCrcHexAsciiAnswer); };

            SerialTerminal.UtilTab.Util.SetIMEI_TB += delegate (string data) { this.BeginInvoke((MethodInvoker)(delegate () { crc_IMEIConv_TB.Text = data; })); };
            SerialTerminal.UtilTab.Util.SimNum_Info += delegate (string data) { this.BeginInvoke((MethodInvoker)(delegate () { tabUtil_tbSimOutput.Text = data; })); };
            #endregion

            /////////////////////////////////////
            // Misc settings
            #region Misc
            //do me last after all the tabs have been processed
            ProcessAdvancedSettings();

            System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Version_Number = String.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            this.Text += " v" + Version_Number;

            //required for modifier keys? Or generally to use hotkeys in application?
            this.KeyPreview = true;
            #endregion
        }

        #region Form Closing - Save Data
        private void SerialTerminal_FormClosing(object sender, FormClosingEventArgs e) {
            Config.Data.ComPort = tabSerial_ddComPort.Text;
            Config.Data.BaudRate = tabSerial_ddBaudRate.Text;
            Config.Data.DataBits = tabSerial_ddDataBits.Text;
            Config.Data.Parity = tabSerial_ddParity.Text;
            Config.Data.StopBits = tabSerial_ddStopBits.Text;

            //serial tab tb's
            Config.Data.SerialTextBox = new string[16];
            Config.Data.SerialHexCB = new bool[16];
            Config.Data.SerialLFCB = new bool[16];

            for (int i = 0; i < 16; i++) {
                Config.Data.SerialTextBox[i] = this.Controls.Find("tabSerial_tbSend" + (i + 1), true)[0].Text;
                Config.Data.SerialHexCB[i] = ((CheckBox)this.Controls.Find("tabSerial_cbHexSend" + (i + 1), true)[0]).Checked;
                Config.Data.SerialLFCB[i] = ((CheckBox)this.Controls.Find("tabSerial_cbLFSend" + (i + 1), true)[0]).Checked;
            }

            ////////////////////////
            //TCP Tab
            Config.Data.TcpClientIPAddr = tabTcpClient_tbIPAddr.Text;
            Config.Data.TcpClientPort = tabTcpClient_tbPort.Text;

            Config.Data.TcpClientTextBox = new string[16];
            Config.Data.TcpClientLFCB = new bool[16];
            Config.Data.TcpClientHexCB = new bool[16];

            for (int i = 0; i < 16; i++) {
                Config.Data.TcpClientTextBox[i] = this.Controls.Find("tabTcp_tbSend" + (i + 1), true)[0].Text;
                Config.Data.TcpClientHexCB[i] = ((CheckBox)this.Controls.Find("tabTcp_cbHexSend" + (i + 1), true)[0]).Checked;
                Config.Data.TcpClientLFCB[i] = ((CheckBox)this.Controls.Find("tabTcp_cbLFSend" + (i + 1), true)[0]).Checked;
            }

            ////////////////////////
            //TCP Server Tab
            Config.Data.TcpSvrPort = tabTcpSvr_tbPort.Text;

            Config.Data.TcpSvrTextBox = new string[16];
            Config.Data.TcpSvrLFCB = new bool[16];
            Config.Data.TcpSvrHexCB = new bool[16];

            for (int i = 0; i < 16; i++) {
                Config.Data.TcpSvrTextBox[i] = this.Controls.Find("tabTcp_tbSend" + (i + 1), true)[0].Text;
                Config.Data.TcpSvrHexCB[i] = ((CheckBox)this.Controls.Find("tabTcp_cbHexSend" + (i + 1), true)[0]).Checked;
                Config.Data.TcpSvrLFCB[i] = ((CheckBox)this.Controls.Find("tabTcp_cbLFSend" + (i + 1), true)[0]).Checked;
            }

            Config.SerializeToXML();
        }
        #endregion

        #region Right-Click Context Menu
        /*****************************************************************************************************************************
        *   Right Click Menu Items
        *****************************************************************************************************************************/
        private void logTextBox_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var tab = tabControl.SelectedTab;
                if (tab == tabSerial)
                    tabSerial_rightClickContextMain.Show(Cursor.Position);
                else if (tab == tabTcpClient)
                    tabTcpClient_contextMenuStrip.Show(Cursor.Position);
                else if (tab == tabTcpServer) {
                    tabTcpSvr_contextMenuStrip.Show(Cursor.Position);
                }
                else if (tab == tabUdpClient) {
                    tabUdpClient_contextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void rightClickClear_Click(object sender, EventArgs e) {
            var tab = tabControl.SelectedTab;
            if (tab == tabSerial) {
                tabSerial_tbLog.Clear();
                cSerial.logBuffer.Clear();
            }
            else if (tab == tabTcpClient) {
                cTcp.logBuffer.Clear();
                tabTcpClient_tbLog.Clear();
            }
            else if (tab == tabTcpServer) {
                cTcpSvr.logBuffer.Clear();
                tabTcpSvr_tbLog.Clear();
            }
            else if (tab == tabUdpClient) {
                cUdpClient.logBuffer.Clear();
                tabUdpClient_tbLog.Clear();
            }
        }

        private void rightClick_NoSpecial_Click(object sender, EventArgs e) {
            var tab = tabControl.SelectedTab;
            if (tab == tabSerial) {
                Config.Data.Serial_DisplayLevel = GLOBAL.HEX_LEVEL_NONE;
                tabSerial_rightClick_NoSpecial.Checked = true;
                tabSerial_rightClick_Normal.Checked = false;
                tabSerial_rightClick_AllButNL.Checked = false;
                tabSerial_rightClick_AllHEX.Checked = false;
            }
            else if (tab == tabTcpClient) {
                Config.Data.TcpClient_DisplayLevel = GLOBAL.HEX_LEVEL_NONE;
                tabTcpClient_RightClick_TxtDisp_None.Checked = true;
                tabTcpClient_RightClick_TxtDisp_Normal.Checked = false;
                tabTcpClient_RightClick_TxtDisp_AllHexExceptNL.Checked = false;
                tabTcpClient_RightClick_TxtDisp_AllHex.Checked = false;
            }
            else if (tab == tabTcpServer) {
                Config.Data.TcpSvr_DisplayLevel = GLOBAL.HEX_LEVEL_NONE;
                tabTcpClient_RightClick_TxtDisp_None.Checked = true;
                tabTcpClient_RightClick_TxtDisp_Normal.Checked = false;
                tabTcpClient_RightClick_TxtDisp_AllHexExceptNL.Checked = false;
                tabTcpClient_RightClick_TxtDisp_AllHex.Checked = false;
            }
            else if (tab == tabUdpClient) {
                Config.Data.TcpSvr_DisplayLevel = GLOBAL.HEX_LEVEL_NONE;
                tabUdpClient_RightClick_TxtDisp_None.Checked = true;
                tabUdpClient_RightClick_TxtDisp_Normal.Checked = false;
                tabUdpClient_RightClick_TxtDisp_AllHexExceptNL.Checked = false;
                tabUdpClient_RightClick_TxtDisp_AllHex.Checked = false;
            }
        }

        private void rightClick_Normal_Click(object sender, EventArgs e) {
            var tab = tabControl.SelectedTab;
            if (tab == tabSerial) {
                Config.Data.Serial_DisplayLevel = GLOBAL.HEX_LEVEL_NORMAL;
                tabSerial_rightClick_NoSpecial.Checked = false;
                tabSerial_rightClick_Normal.Checked = true;
                tabSerial_rightClick_AllButNL.Checked = false;
                tabSerial_rightClick_AllHEX.Checked = false;
            }
            else if (tab == tabTcpClient) {
                Config.Data.TcpClient_DisplayLevel = GLOBAL.HEX_LEVEL_NORMAL;
                tabTcpClient_RightClick_TxtDisp_None.Checked = false;
                tabTcpClient_RightClick_TxtDisp_Normal.Checked = true;
                tabTcpClient_RightClick_TxtDisp_AllHexExceptNL.Checked = false;
                tabTcpClient_RightClick_TxtDisp_AllHex.Checked = false;
            }
            else if (tab == tabTcpServer) {
                Config.Data.TcpSvr_DisplayLevel = GLOBAL.HEX_LEVEL_NORMAL;
                tabTcpSvr_RightClick_TxtDisp_None.Checked = false;
                tabTcpSvr_RightClick_TxtDisp_Normal.Checked = true;
                tabTcpSvr_RightClick_TxtDisp_AllHexExceptNL.Checked = false;
                tabTcpSvr_RightClick_TxtDisp_AllHex.Checked = false;
            }
            else if (tab == tabUdpClient) {
                Config.Data.TcpSvr_DisplayLevel = GLOBAL.HEX_LEVEL_NORMAL;
                tabUdpClient_RightClick_TxtDisp_None.Checked = false;
                tabUdpClient_RightClick_TxtDisp_Normal.Checked = true;
                tabUdpClient_RightClick_TxtDisp_AllHexExceptNL.Checked = false;
                tabUdpClient_RightClick_TxtDisp_AllHex.Checked = false;
            }
        }

        private void rightClick_AllButNL_Click(object sender, EventArgs e) {
            var tab = tabControl.SelectedTab;
            if (tab == tabSerial) {
                Config.Data.Serial_DisplayLevel = GLOBAL.HEX_LEVEL_ALL_EXCEPT_NL;
                tabSerial_rightClick_NoSpecial.Checked = false;
                tabSerial_rightClick_Normal.Checked = false;
                tabSerial_rightClick_AllButNL.Checked = true;
                tabSerial_rightClick_AllHEX.Checked = false;
            }
            else if (tab == tabTcpClient) {
                Config.Data.TcpClient_DisplayLevel = GLOBAL.HEX_LEVEL_ALL_EXCEPT_NL;
                tabTcpClient_RightClick_TxtDisp_None.Checked = false;
                tabTcpClient_RightClick_TxtDisp_Normal.Checked = false;
                tabTcpClient_RightClick_TxtDisp_AllHexExceptNL.Checked = true;
                tabTcpClient_RightClick_TxtDisp_AllHex.Checked = false;
            }
            else if (tab == tabTcpServer) {
                Config.Data.TcpSvr_DisplayLevel = GLOBAL.HEX_LEVEL_ALL_EXCEPT_NL;
                tabTcpSvr_RightClick_TxtDisp_None.Checked = false;
                tabTcpSvr_RightClick_TxtDisp_Normal.Checked = false;
                tabTcpSvr_RightClick_TxtDisp_AllHexExceptNL.Checked = true;
                tabTcpSvr_RightClick_TxtDisp_AllHex.Checked = false;
            }
            else if (tab == tabUdpClient) {
                Config.Data.TcpSvr_DisplayLevel = GLOBAL.HEX_LEVEL_ALL_EXCEPT_NL;
                tabUdpClient_RightClick_TxtDisp_None.Checked = false;
                tabUdpClient_RightClick_TxtDisp_Normal.Checked = false;
                tabUdpClient_RightClick_TxtDisp_AllHexExceptNL.Checked = true;
                tabUdpClient_RightClick_TxtDisp_AllHex.Checked = false;
            }
        }

        private void rightClick_HEX_Click(object sender, EventArgs e) {
            var tab = tabControl.SelectedTab;
            if (tab == tabSerial) {
                Config.Data.Serial_DisplayLevel = GLOBAL.HEX_LEVEL_ALL;
                tabSerial_rightClick_NoSpecial.Checked = false;
                tabSerial_rightClick_Normal.Checked = false;
                tabSerial_rightClick_AllButNL.Checked = false;
                tabSerial_rightClick_AllHEX.Checked = true;
            }
            else if (tab == tabTcpClient) {
                Config.Data.TcpClient_DisplayLevel = GLOBAL.HEX_LEVEL_ALL;
                tabTcpClient_RightClick_TxtDisp_None.Checked = false;
                tabTcpClient_RightClick_TxtDisp_Normal.Checked = false;
                tabTcpClient_RightClick_TxtDisp_AllHexExceptNL.Checked = false;
                tabTcpClient_RightClick_TxtDisp_AllHex.Checked = true;
            }
            else if (tab == tabTcpServer) {
                Config.Data.TcpSvr_DisplayLevel = GLOBAL.HEX_LEVEL_ALL;
                tabTcpSvr_RightClick_TxtDisp_None.Checked = false;
                tabTcpSvr_RightClick_TxtDisp_Normal.Checked = false;
                tabTcpSvr_RightClick_TxtDisp_AllHexExceptNL.Checked = false;
                tabTcpSvr_RightClick_TxtDisp_AllHex.Checked = true;
            }
            else if (tab == tabUdpClient) {
                Config.Data.TcpSvr_DisplayLevel = GLOBAL.HEX_LEVEL_ALL;
                tabUdpClient_RightClick_TxtDisp_None.Checked = false;
                tabUdpClient_RightClick_TxtDisp_Normal.Checked = false;
                tabUdpClient_RightClick_TxtDisp_AllHexExceptNL.Checked = false;
                tabUdpClient_RightClick_TxtDisp_AllHex.Checked = true;
            }
        }

        private void openLogContaingDirToolStripMenuItem_Click(object sender, EventArgs e) {
            string dir = Config.Data.Serial_LogDirectory;

            if (dir.Equals("")) {
                dir = Directory.GetCurrentDirectory();
            }
            string file = dir;

            var tab = tabControl.SelectedTab;
            if (tab == tabSerial) {
                file += "\\" + cSerial.GetLogFileName();
            }
            else if (tab == tabTcpClient) {
                file += "\\" + cTcp.GetLogFileName();
            }
            else if (tab == tabTcpServer) {
                file += "\\" + cTcp.GetLogFileName();
            }
            else if (tab == tabUdpClient) {
                file += "\\" + cUdpClient.GetLogFileName();
            }

            if (File.Exists(file)) //safety
            {
                // combine the arguments together
                // it doesn't matter if there is a space after ','
                string argument = "/select,\"" + file + "\"";

                Process.Start("explorer.exe", argument);
            }
            else {
                Process.Start(dir);
            }
        }

        private void openLogFileToolStripMenuItem_Click(object sender, EventArgs e) {
            string file = Config.Data.Serial_LogDirectory;

            if (file.Equals("")) {
                file = Directory.GetCurrentDirectory();
            }

            var tab = tabControl.SelectedTab;
            if (tab == tabSerial) {
                file += "\\" + cSerial.GetLogFileName();
            }
            else if (tab == tabTcpClient) {
                file += "\\" + cTcp.GetLogFileName();
            }
            else if (tab == tabTcpServer) {
                file += "\\" + cTcpSvr.GetLogFileName();
            }
            else if (tab == tabUdpClient) {
                file += "\\" + cUdpClient.GetLogFileName();
            }

            if (File.Exists(file)) {
                Process proc = new Process();
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                proc.StartInfo.Arguments = "\"" + file + "\"";

                if (File.Exists("C:\\Program Files (x86)\\Notepad++\\notepad++.exe")) {
                    proc.StartInfo.FileName = "C:\\Program Files (x86)\\Notepad++\\notepad++.exe";
                    proc.Start();
                }
                else if (File.Exists("C:\\Program Files\\Notepad++\\notepad++.exe")) {
                    proc.StartInfo.FileName = "C:\\Program Files\\Notepad++\\notepad++.exe";
                    proc.Start();
                }
            }
        }
        #endregion

        //Minimising and Maximising stuff
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
            //this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        //com toggle will not disable the bootloaderStepProgrammerButton
        public void ProcessAdvancedSettings() {
            if (Config.Data.AdvancedSettings) {
                if (cSerial.IsOpen()) {
                    tabSerial_ddComPort.Enabled = false;

                    tabSerial_ddBaudRate.Enabled = false;
                    tabSerial_ddDataBits.Enabled = false;
                    tabSerial_ddParity.Enabled = false;
                    tabSerial_ddStopBits.Enabled = false;

                    tabSerial_butSerialProg.Enabled = true;
                }
                else {
                    tabSerial_ddComPort.Enabled = true;

                    tabSerial_ddBaudRate.Enabled = true;
                    tabSerial_ddDataBits.Enabled = true;
                    tabSerial_ddParity.Enabled = true;
                    tabSerial_ddStopBits.Enabled = true;

                    tabSerial_butSerialProg.Enabled = false;
                }
            }
            else {
                if (cSerial.IsOpen()) {
                    tabSerial_ddComPort.Enabled = false;
                    tabSerial_ddBaudRate.Enabled = false;
                }
                else {
                    tabSerial_ddComPort.Enabled = true;
                    tabSerial_ddBaudRate.Enabled = true;
                }

                //independent of state
                tabSerial_ddDataBits.Enabled = false;
                tabSerial_ddParity.Enabled = false;
                tabSerial_ddStopBits.Enabled = false;

                tabSerial_butSerialProg.Enabled = false;
            }
        }

        #region Menu Strip
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Serial Terminal\r\nVersion: " + Version_Number + "\n\nMade by Ryan Fleming\n" + DateTime.Now.ToString("yyyy-MM-dd"), "About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            Options opt = new Options();
            opt.Default_OptionsLogText = Config.Data.Serial_LogDirectory;
            opt.Default_AdvancedSettingsEnabled = Config.Data.AdvancedSettings;
            opt.FirmwarePath = Config.Data.SerialFlashHexLocation;
            opt.serialProgBinary = Config.Data.SerialProg_BinaryFormat;


            if (opt.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                if (Directory.Exists(opt.optionsLogTextBox.Text)) {
                    if (opt.optionsLogTextBox.Text.EndsWith("\\"))
                        Config.Data.Serial_LogDirectory = opt.optionsLogTextBox.Text;
                    else
                        Config.Data.Serial_LogDirectory = opt.optionsLogTextBox.Text + "\\";

                }
                else if (opt.optionsLogTextBox.Text.Equals("")) {
                    Config.Data.Serial_LogDirectory = opt.optionsLogTextBox.Text;
                }
                else {
                    MessageBox.Show("Log directory doesn't exist.");
                }

                Config.Data.AdvancedSettings = opt.advancedSettingsTickBox.Checked;
                ProcessAdvancedSettings();

                Config.Data.SerialProg_BinaryFormat = opt.serialProgBinary;

                Config.Data.SerialFlashHexLocation = opt.FirmwarePath;
            }
            opt.Close();
        }
        #endregion


        #region Hot Keys
        private void tabControl_KeyDown(object sender, KeyEventArgs e) {
            //bad hot key combo
            if ((e.KeyCode != Keys.Return) &&
                ((e.KeyCode < Keys.F1) || (e.KeyCode > Keys.F8))) {
                return;
            }

            //tabTcp_cbSend9
            string cbHex_name = "_cbHexSend";
            string cbLF_name = "_cbLFSend";
            string txt_name = "_tbSend";
            string but_name = "_butSend";
            bool serial_tab_selected = false;
            bool tcp_client_tab_selected = false;
            bool tcp_server_tab_selected = false;
            bool udp_client_tab_selected = false;

            var tab = tabControl.SelectedTab;
            if (tab.Name == tabSerial.Name) {
                cbHex_name = "tabSerial" + cbHex_name;
                cbLF_name = "tabSerial" + cbLF_name;
                txt_name = "tabSerial" + txt_name;
                but_name = "tabSerial" + but_name;
                serial_tab_selected = true;
            }
            else if (tab.Name == tabTcpClient.Name) {
                cbHex_name = "tabTcp" + cbHex_name;
                cbLF_name = "tabTcp" + cbLF_name;
                txt_name = "tabTcp" + txt_name;
                but_name = "tabTcp" + but_name;
                tcp_client_tab_selected = true;
            }
            else if (tab.Name == tabTcpServer.Name) {
                cbHex_name = "tabTcpSvr" + cbHex_name;
                cbLF_name = "tabTcpSvr" + cbLF_name;
                txt_name = "tabTcpSvr" + txt_name;
                but_name = "tabTcpSvr" + but_name;
                tcp_server_tab_selected = true;
            }
            else if (tab.Name == tabUdpClient.Name) {
                cbHex_name = "tabUdpClient" + cbHex_name;
                cbLF_name = "tabUdpClient" + cbLF_name;
                txt_name = "tabUdpClient" + txt_name;
                but_name = "tabUdpClient" + but_name;
                udp_client_tab_selected = true;
            }
            else {
                return;
            }

            bool hex = false;
            bool line_feed = false;
            string text = "";
            bool found = false;

            //ensures when user closes with alt+F4 that no final commands are sent through
            if (e.Modifiers != Keys.Alt) {
                int offset = 0;
                if (e.Modifiers == Keys.Shift) {
                    offset = 8;
                }

                for (int i = 1; i <= 8; i++) {
                    //enumerate over F1 to F8
                    if (e.KeyCode == (Keys)((int)Keys.F1 + i - 1)) {
                        text = this.Controls.Find(txt_name + (i + offset), true)[0].Text;
                        var cb_hex = (CheckBox)this.Controls.Find(cbHex_name + (i + offset), true)[0];
                        var cb_lf = (CheckBox)this.Controls.Find(cbLF_name + (i + offset), true)[0];

                        if (cb_hex.Checked)
                            hex = true;

                        if (cb_lf.Checked)
                            line_feed = true;
                        found = true;
                        break;
                    }
                }

                // return key functionality
                if (!found && e.KeyCode == Keys.Return) {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    for (int i = 1; i <= 16; i++) {
                        var tb_control = this.Controls.Find(txt_name + i, true)[0];
                        var but_control = (Button)this.Controls.Find(but_name + i, true)[0];
                        var hex_cb_control = (CheckBox)this.Controls.Find(cbHex_name + i, true)[0];
                        var lf_cb_control = (CheckBox)this.Controls.Find(cbLF_name + i, true)[0];

                        if (tb_control.Focused) {
                            found = true;
                            text = tb_control.Text;
                            if (hex_cb_control.Checked)
                                hex = true;
                            if (lf_cb_control.Checked)
                                line_feed = true;
                            break;
                        }
                        else if (but_control.Focused) {
                            found = true;
                            text = tb_control.Text;
                            if (hex_cb_control.Checked)
                                hex = true;
                            if (lf_cb_control.Checked)
                                line_feed = true;
                            break;
                        }
                        else if (hex_cb_control.Focused) {
                            if (hex_cb_control.Checked)
                                hex_cb_control.Checked = false;
                            else
                                hex_cb_control.Checked = true;
                            break;
                        }
                        else if (lf_cb_control.Focused) {
                            if (lf_cb_control.Checked)
                                lf_cb_control.Checked = false;
                            else
                                lf_cb_control.Checked = true;
                            break;
                        }
                    }
                }
            }

            if (found) {
                if (serial_tab_selected) {
                    cSerial.SendCommand(text, hex, line_feed);
                }
                else if (tcp_client_tab_selected) {
                    cTcp.SendCommand(text, hex, line_feed);
                }
                else if (tcp_server_tab_selected) {
                    cTcpSvr.SendCommand(text, hex, line_feed);
                }
                else if (udp_client_tab_selected) {
                    cUdpClient.SendCommand(text, hex, line_feed);
                }
            }
        }
        #endregion
    }
}