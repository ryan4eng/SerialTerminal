namespace SerialInterface
{
    partial class SerialForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialForm));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.BaudRateDropDown = new System.Windows.Forms.ComboBox();
            this.buttonOpenComms = new System.Windows.Forms.Button();
            this.clearTextBox = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ComPortDropDown = new System.Windows.Forms.ComboBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSerial = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label25 = new System.Windows.Forms.Label();
            this.checkBoxHex8 = new System.Windows.Forms.CheckBox();
            this.checkBoxHex7 = new System.Windows.Forms.CheckBox();
            this.checkBoxHex6 = new System.Windows.Forms.CheckBox();
            this.checkBoxHex5 = new System.Windows.Forms.CheckBox();
            this.checkBoxHex4 = new System.Windows.Forms.CheckBox();
            this.checkBoxHex3 = new System.Windows.Forms.CheckBox();
            this.checkBoxHex2 = new System.Windows.Forms.CheckBox();
            this.checkBoxHex1 = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textSend1 = new System.Windows.Forms.TextBox();
            this.textSend6 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonSend7 = new System.Windows.Forms.Button();
            this.buttonSend1 = new System.Windows.Forms.Button();
            this.buttonSend6 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.textSend7 = new System.Windows.Forms.TextBox();
            this.buttonSend2 = new System.Windows.Forms.Button();
            this.textSend5 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonSend8 = new System.Windows.Forms.Button();
            this.textSend2 = new System.Windows.Forms.TextBox();
            this.buttonSend5 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.textSend8 = new System.Windows.Forms.TextBox();
            this.buttonSend3 = new System.Windows.Forms.Button();
            this.textSend4 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.textSend3 = new System.Windows.Forms.TextBox();
            this.buttonSend4 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.checkBoxHex16 = new System.Windows.Forms.CheckBox();
            this.textSend9 = new System.Windows.Forms.TextBox();
            this.checkBoxHex15 = new System.Windows.Forms.CheckBox();
            this.buttonSend9 = new System.Windows.Forms.Button();
            this.checkBoxHex14 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxHex13 = new System.Windows.Forms.CheckBox();
            this.buttonSend10 = new System.Windows.Forms.Button();
            this.checkBoxHex12 = new System.Windows.Forms.CheckBox();
            this.textSend16 = new System.Windows.Forms.TextBox();
            this.checkBoxHex11 = new System.Windows.Forms.CheckBox();
            this.textSend10 = new System.Windows.Forms.TextBox();
            this.checkBoxHex10 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxHex9 = new System.Windows.Forms.CheckBox();
            this.buttonSend11 = new System.Windows.Forms.Button();
            this.buttonSend16 = new System.Windows.Forms.Button();
            this.textSend11 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textSend15 = new System.Windows.Forms.TextBox();
            this.buttonSend12 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textSend12 = new System.Windows.Forms.TextBox();
            this.buttonSend15 = new System.Windows.Forms.Button();
            this.buttonSend13 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textSend14 = new System.Windows.Forms.TextBox();
            this.textSend13 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonSend14 = new System.Windows.Forms.Button();
            this.StopBitsComboBox = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.ParityComboBox = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.DataBitsComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.programCT100iButton = new System.Windows.Forms.Button();
            this.bootloaderStepProgramButton = new System.Windows.Forms.Button();
            this.serialTextBox = new System.Windows.Forms.RichTextBox();
            this.tabTCP = new System.Windows.Forms.TabPage();
            this.sendTCPButton1 = new System.Windows.Forms.Button();
            this.textTCP1 = new System.Windows.Forms.TextBox();
            this.tcpOpen = new System.Windows.Forms.Button();
            this.TCPlog = new System.Windows.Forms.RichTextBox();
            this.CRCTab = new System.Windows.Forms.TabPage();
            this.label22 = new System.Windows.Forms.Label();
            this.imeiButton = new System.Windows.Forms.Button();
            this.imeiOutputTextBox = new System.Windows.Forms.TextBox();
            this.imeiInputTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.crc_convertButton2 = new System.Windows.Forms.Button();
            this.txtConvertedString2 = new System.Windows.Forms.TextBox();
            this.txtStringToSend2 = new System.Windows.Forms.TextBox();
            this.crcDescriptorLabel = new System.Windows.Forms.Label();
            this.crc_convertButton = new System.Windows.Forms.Button();
            this.txtConvertedString = new System.Windows.Forms.TextBox();
            this.txtStringToSend = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.rightClickContextMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rightClickClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rightClick_DisplayText = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClick_NoSpecial = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClick_Normal = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClick_HEX = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClick_AllButNL = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabSerial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabTCP.SuspendLayout();
            this.CRCTab.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.rightClickContextMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 57600;
            this.serialPort1.PortName = "COM9";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // BaudRateDropDown
            // 
            this.BaudRateDropDown.AllowDrop = true;
            this.BaudRateDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BaudRateDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudRateDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BaudRateDropDown.FormattingEnabled = true;
            this.BaudRateDropDown.Items.AddRange(new object[] {
            "600",
            "1200",
            "2400",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "76800",
            "115200",
            "250000"});
            this.BaudRateDropDown.Location = new System.Drawing.Point(68, 310);
            this.BaudRateDropDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BaudRateDropDown.Name = "BaudRateDropDown";
            this.BaudRateDropDown.Size = new System.Drawing.Size(84, 22);
            this.BaudRateDropDown.TabIndex = 3;
            // 
            // buttonOpenComms
            // 
            this.buttonOpenComms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpenComms.Location = new System.Drawing.Point(2, 245);
            this.buttonOpenComms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonOpenComms.Name = "buttonOpenComms";
            this.buttonOpenComms.Size = new System.Drawing.Size(72, 24);
            this.buttonOpenComms.TabIndex = 11;
            this.buttonOpenComms.Text = "Open";
            this.buttonOpenComms.UseVisualStyleBackColor = true;
            this.buttonOpenComms.Click += new System.EventHandler(this.buttonOpenComms_Click);
            // 
            // clearTextBox
            // 
            this.clearTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearTextBox.Location = new System.Drawing.Point(80, 245);
            this.clearTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clearTextBox.Name = "clearTextBox";
            this.clearTextBox.Size = new System.Drawing.Size(72, 24);
            this.clearTextBox.TabIndex = 12;
            this.clearTextBox.Text = "Clear";
            this.clearTextBox.UseVisualStyleBackColor = true;
            this.clearTextBox.Click += new System.EventHandler(this.clearTextBox_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "Baud Rate";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "Com Port";
            // 
            // ComPortDropDown
            // 
            this.ComPortDropDown.AllowDrop = true;
            this.ComPortDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ComPortDropDown.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ComPortDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComPortDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComPortDropDown.FormattingEnabled = true;
            this.ComPortDropDown.IntegralHeight = false;
            this.ComPortDropDown.ItemHeight = 14;
            this.ComPortDropDown.Items.AddRange(new object[] {
            "Com 1",
            "Com 2",
            "Com 3",
            "Com 4",
            "Com 5",
            "Com 6",
            "Com 7",
            "Com 8",
            "Com 9",
            "Com 10",
            "Com 11",
            "Com 12",
            "Com 13",
            "Com 14",
            "Com 15",
            "Com 16",
            "Com 17",
            "Com 18",
            "Com 19",
            "Com 20",
            "Com 21",
            "Com 22",
            "Com 23",
            "Com 24",
            "Com 25",
            "Com 26",
            "Com 27",
            "Com 28",
            "Com 29",
            "Com 30",
            "Com 31",
            "Com 32",
            "Com 33",
            "Com 34",
            "Com 35",
            "Com 36",
            "Com 37",
            "Com 38",
            "Com 39",
            "Com 40",
            "Com 41",
            "Com 42",
            "Com 43",
            "Com 44",
            "Com 45",
            "Com 46",
            "Com 47",
            "Com 48",
            "Com 49",
            "Com 50",
            "Com 51",
            "Com 52",
            "Com 53",
            "Com 54",
            "Com 55",
            "Com 56",
            "Com 57",
            "Com 58",
            "Com 59",
            "Com 60",
            "Com 61",
            "Com 62",
            "Com 63",
            "Com 64",
            "Com 65",
            "Com 66",
            "Com 67",
            "Com 68",
            "Com 69",
            "Com 70",
            "Com 71",
            "Com 72",
            "Com 73",
            "Com 74",
            "Com 75",
            "Com 76",
            "Com 77",
            "Com 78",
            "Com 79",
            "Com 80",
            "Com 81",
            "Com 82",
            "Com 83",
            "Com 84",
            "Com 85",
            "Com 86",
            "Com 87",
            "Com 88",
            "Com 89",
            "Com 90",
            "Com 91",
            "Com 92",
            "Com 93",
            "Com 94",
            "Com 95",
            "Com 96",
            "Com 97",
            "Com 98",
            "Com 99",
            "Com 100"});
            this.ComPortDropDown.Location = new System.Drawing.Point(68, 281);
            this.ComPortDropDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComPortDropDown.Name = "ComPortDropDown";
            this.ComPortDropDown.Size = new System.Drawing.Size(84, 22);
            this.ComPortDropDown.TabIndex = 15;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Serial Interface";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabSerial);
            this.tabControl.Controls.Add(this.tabTCP);
            this.tabControl.Controls.Add(this.CRCTab);
            this.tabControl.Location = new System.Drawing.Point(0, 23);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(905, 524);
            this.tabControl.TabIndex = 41;
            // 
            // tabSerial
            // 
            this.tabSerial.BackColor = System.Drawing.SystemColors.Control;
            this.tabSerial.Controls.Add(this.splitContainer1);
            this.tabSerial.Controls.Add(this.StopBitsComboBox);
            this.tabSerial.Controls.Add(this.label24);
            this.tabSerial.Controls.Add(this.ParityComboBox);
            this.tabSerial.Controls.Add(this.label23);
            this.tabSerial.Controls.Add(this.DataBitsComboBox);
            this.tabSerial.Controls.Add(this.label11);
            this.tabSerial.Controls.Add(this.programCT100iButton);
            this.tabSerial.Controls.Add(this.bootloaderStepProgramButton);
            this.tabSerial.Controls.Add(this.serialTextBox);
            this.tabSerial.Controls.Add(this.BaudRateDropDown);
            this.tabSerial.Controls.Add(this.buttonOpenComms);
            this.tabSerial.Controls.Add(this.clearTextBox);
            this.tabSerial.Controls.Add(this.label1);
            this.tabSerial.Controls.Add(this.ComPortDropDown);
            this.tabSerial.Controls.Add(this.label2);
            this.tabSerial.Location = new System.Drawing.Point(4, 23);
            this.tabSerial.Name = "tabSerial";
            this.tabSerial.Padding = new System.Windows.Forms.Padding(3);
            this.tabSerial.Size = new System.Drawing.Size(897, 497);
            this.tabSerial.TabIndex = 0;
            this.tabSerial.Text = "Serial";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(166, 244);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label25);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxHex8);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxHex7);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxHex6);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxHex5);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxHex4);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxHex3);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxHex2);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxHex1);
            this.splitContainer1.Panel1.Controls.Add(this.label14);
            this.splitContainer1.Panel1.Controls.Add(this.textSend1);
            this.splitContainer1.Panel1.Controls.Add(this.textSend6);
            this.splitContainer1.Panel1.Controls.Add(this.label15);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSend7);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSend1);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSend6);
            this.splitContainer1.Panel1.Controls.Add(this.label16);
            this.splitContainer1.Panel1.Controls.Add(this.textSend7);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSend2);
            this.splitContainer1.Panel1.Controls.Add(this.textSend5);
            this.splitContainer1.Panel1.Controls.Add(this.label17);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSend8);
            this.splitContainer1.Panel1.Controls.Add(this.textSend2);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSend5);
            this.splitContainer1.Panel1.Controls.Add(this.label18);
            this.splitContainer1.Panel1.Controls.Add(this.textSend8);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSend3);
            this.splitContainer1.Panel1.Controls.Add(this.textSend4);
            this.splitContainer1.Panel1.Controls.Add(this.label19);
            this.splitContainer1.Panel1.Controls.Add(this.label21);
            this.splitContainer1.Panel1.Controls.Add(this.textSend3);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSend4);
            this.splitContainer1.Panel1.Controls.Add(this.label20);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label26);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxHex16);
            this.splitContainer1.Panel2.Controls.Add(this.textSend9);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxHex15);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSend9);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxHex14);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxHex13);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSend10);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxHex12);
            this.splitContainer1.Panel2.Controls.Add(this.textSend16);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxHex11);
            this.splitContainer1.Panel2.Controls.Add(this.textSend10);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxHex10);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxHex9);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSend11);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSend16);
            this.splitContainer1.Panel2.Controls.Add(this.textSend11);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label13);
            this.splitContainer1.Panel2.Controls.Add(this.textSend15);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSend12);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.textSend12);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSend15);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSend13);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.textSend14);
            this.splitContainer1.Panel2.Controls.Add(this.textSend13);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSend14);
            this.splitContainer1.Size = new System.Drawing.Size(704, 252);
            this.splitContainer1.SplitterDistance = 352;
            this.splitContainer1.TabIndex = 102;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(267, 3);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(28, 14);
            this.label25.TabIndex = 133;
            this.label25.Text = "HEX";
            // 
            // checkBoxHex8
            // 
            this.checkBoxHex8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex8.AutoSize = true;
            this.checkBoxHex8.Location = new System.Drawing.Point(274, 219);
            this.checkBoxHex8.Name = "checkBoxHex8";
            this.checkBoxHex8.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex8.TabIndex = 132;
            this.checkBoxHex8.UseVisualStyleBackColor = true;
            // 
            // checkBoxHex7
            // 
            this.checkBoxHex7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex7.AutoSize = true;
            this.checkBoxHex7.Location = new System.Drawing.Point(274, 190);
            this.checkBoxHex7.Name = "checkBoxHex7";
            this.checkBoxHex7.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex7.TabIndex = 131;
            this.checkBoxHex7.UseVisualStyleBackColor = true;
            // 
            // checkBoxHex6
            // 
            this.checkBoxHex6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex6.AutoSize = true;
            this.checkBoxHex6.Location = new System.Drawing.Point(274, 162);
            this.checkBoxHex6.Name = "checkBoxHex6";
            this.checkBoxHex6.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex6.TabIndex = 130;
            this.checkBoxHex6.UseVisualStyleBackColor = true;
            // 
            // checkBoxHex5
            // 
            this.checkBoxHex5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex5.AutoSize = true;
            this.checkBoxHex5.Location = new System.Drawing.Point(274, 133);
            this.checkBoxHex5.Name = "checkBoxHex5";
            this.checkBoxHex5.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex5.TabIndex = 129;
            this.checkBoxHex5.UseVisualStyleBackColor = true;
            // 
            // checkBoxHex4
            // 
            this.checkBoxHex4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex4.AutoSize = true;
            this.checkBoxHex4.Location = new System.Drawing.Point(274, 105);
            this.checkBoxHex4.Name = "checkBoxHex4";
            this.checkBoxHex4.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex4.TabIndex = 128;
            this.checkBoxHex4.UseVisualStyleBackColor = true;
            // 
            // checkBoxHex3
            // 
            this.checkBoxHex3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex3.AutoSize = true;
            this.checkBoxHex3.Location = new System.Drawing.Point(274, 76);
            this.checkBoxHex3.Name = "checkBoxHex3";
            this.checkBoxHex3.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex3.TabIndex = 127;
            this.checkBoxHex3.UseVisualStyleBackColor = true;
            // 
            // checkBoxHex2
            // 
            this.checkBoxHex2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex2.AutoSize = true;
            this.checkBoxHex2.Location = new System.Drawing.Point(274, 48);
            this.checkBoxHex2.Name = "checkBoxHex2";
            this.checkBoxHex2.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex2.TabIndex = 126;
            this.checkBoxHex2.UseVisualStyleBackColor = true;
            // 
            // checkBoxHex1
            // 
            this.checkBoxHex1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex1.AutoSize = true;
            this.checkBoxHex1.Location = new System.Drawing.Point(274, 19);
            this.checkBoxHex1.Name = "checkBoxHex1";
            this.checkBoxHex1.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex1.TabIndex = 125;
            this.checkBoxHex1.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 219);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 14);
            this.label14.TabIndex = 124;
            this.label14.Text = "F8";
            // 
            // textSend1
            // 
            this.textSend1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend1.Location = new System.Drawing.Point(36, 15);
            this.textSend1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend1.Name = "textSend1";
            this.textSend1.Size = new System.Drawing.Size(231, 21);
            this.textSend1.TabIndex = 102;
            this.textSend1.Text = "CT-VER;";
            // 
            // textSend6
            // 
            this.textSend6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend6.Location = new System.Drawing.Point(36, 157);
            this.textSend6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend6.Name = "textSend6";
            this.textSend6.Size = new System.Drawing.Size(231, 21);
            this.textSend6.TabIndex = 112;
            this.textSend6.Text = "CT-GSM3;";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 191);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 14);
            this.label15.TabIndex = 123;
            this.label15.Text = "F7";
            // 
            // buttonSend7
            // 
            this.buttonSend7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend7.Location = new System.Drawing.Point(295, 184);
            this.buttonSend7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend7.Name = "buttonSend7";
            this.buttonSend7.Size = new System.Drawing.Size(48, 24);
            this.buttonSend7.TabIndex = 113;
            this.buttonSend7.Text = "Send";
            this.buttonSend7.UseVisualStyleBackColor = true;
            this.buttonSend7.Click += new System.EventHandler(this.buttonSend7_Click);
            // 
            // buttonSend1
            // 
            this.buttonSend1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend1.Location = new System.Drawing.Point(295, 13);
            this.buttonSend1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend1.Name = "buttonSend1";
            this.buttonSend1.Size = new System.Drawing.Size(48, 24);
            this.buttonSend1.TabIndex = 101;
            this.buttonSend1.Text = "Send";
            this.buttonSend1.UseVisualStyleBackColor = true;
            this.buttonSend1.Click += new System.EventHandler(this.buttonSend1_Click);
            // 
            // buttonSend6
            // 
            this.buttonSend6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend6.Location = new System.Drawing.Point(295, 155);
            this.buttonSend6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend6.Name = "buttonSend6";
            this.buttonSend6.Size = new System.Drawing.Size(48, 24);
            this.buttonSend6.TabIndex = 111;
            this.buttonSend6.Text = "Send";
            this.buttonSend6.UseVisualStyleBackColor = true;
            this.buttonSend6.Click += new System.EventHandler(this.buttonSend6_Click);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 161);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(19, 14);
            this.label16.TabIndex = 122;
            this.label16.Text = "F6";
            // 
            // textSend7
            // 
            this.textSend7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend7.Location = new System.Drawing.Point(36, 186);
            this.textSend7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend7.Name = "textSend7";
            this.textSend7.Size = new System.Drawing.Size(231, 21);
            this.textSend7.TabIndex = 114;
            this.textSend7.Text = "CT-POS;";
            // 
            // buttonSend2
            // 
            this.buttonSend2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend2.Location = new System.Drawing.Point(295, 41);
            this.buttonSend2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend2.Name = "buttonSend2";
            this.buttonSend2.Size = new System.Drawing.Size(48, 24);
            this.buttonSend2.TabIndex = 103;
            this.buttonSend2.Text = "Send";
            this.buttonSend2.UseVisualStyleBackColor = true;
            this.buttonSend2.Click += new System.EventHandler(this.buttonSend2_Click);
            // 
            // textSend5
            // 
            this.textSend5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend5.Location = new System.Drawing.Point(36, 128);
            this.textSend5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend5.Name = "textSend5";
            this.textSend5.Size = new System.Drawing.Size(231, 21);
            this.textSend5.TabIndex = 110;
            this.textSend5.Text = "CT-GSM2;";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 133);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 14);
            this.label17.TabIndex = 121;
            this.label17.Text = "F5";
            // 
            // buttonSend8
            // 
            this.buttonSend8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend8.Location = new System.Drawing.Point(295, 213);
            this.buttonSend8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend8.Name = "buttonSend8";
            this.buttonSend8.Size = new System.Drawing.Size(48, 24);
            this.buttonSend8.TabIndex = 115;
            this.buttonSend8.Text = "Send";
            this.buttonSend8.UseVisualStyleBackColor = true;
            this.buttonSend8.Click += new System.EventHandler(this.buttonSend8_Click);
            // 
            // textSend2
            // 
            this.textSend2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend2.Location = new System.Drawing.Point(36, 43);
            this.textSend2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend2.Name = "textSend2";
            this.textSend2.Size = new System.Drawing.Size(231, 21);
            this.textSend2.TabIndex = 104;
            this.textSend2.Text = "CT-SV1;";
            // 
            // buttonSend5
            // 
            this.buttonSend5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend5.Location = new System.Drawing.Point(295, 126);
            this.buttonSend5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend5.Name = "buttonSend5";
            this.buttonSend5.Size = new System.Drawing.Size(48, 24);
            this.buttonSend5.TabIndex = 109;
            this.buttonSend5.Text = "Send";
            this.buttonSend5.UseVisualStyleBackColor = true;
            this.buttonSend5.Click += new System.EventHandler(this.buttonSend5_Click);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 105);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(19, 14);
            this.label18.TabIndex = 120;
            this.label18.Text = "F4";
            // 
            // textSend8
            // 
            this.textSend8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend8.Location = new System.Drawing.Point(36, 215);
            this.textSend8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend8.Name = "textSend8";
            this.textSend8.Size = new System.Drawing.Size(231, 21);
            this.textSend8.TabIndex = 116;
            this.textSend8.Text = "CT-UPD;";
            // 
            // buttonSend3
            // 
            this.buttonSend3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend3.Location = new System.Drawing.Point(295, 69);
            this.buttonSend3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend3.Name = "buttonSend3";
            this.buttonSend3.Size = new System.Drawing.Size(48, 24);
            this.buttonSend3.TabIndex = 105;
            this.buttonSend3.Text = "Send";
            this.buttonSend3.UseVisualStyleBackColor = true;
            this.buttonSend3.Click += new System.EventHandler(this.buttonSend3_Click);
            // 
            // textSend4
            // 
            this.textSend4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend4.Location = new System.Drawing.Point(36, 99);
            this.textSend4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend4.Name = "textSend4";
            this.textSend4.Size = new System.Drawing.Size(231, 21);
            this.textSend4.TabIndex = 108;
            this.textSend4.Text = "CT-GSM1;";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 75);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(19, 14);
            this.label19.TabIndex = 119;
            this.label19.Text = "F3";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(19, 14);
            this.label21.TabIndex = 117;
            this.label21.Text = "F1";
            // 
            // textSend3
            // 
            this.textSend3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend3.Location = new System.Drawing.Point(36, 71);
            this.textSend3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend3.Name = "textSend3";
            this.textSend3.Size = new System.Drawing.Size(231, 21);
            this.textSend3.TabIndex = 106;
            this.textSend3.Text = "CT-RST;";
            // 
            // buttonSend4
            // 
            this.buttonSend4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend4.Location = new System.Drawing.Point(295, 97);
            this.buttonSend4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend4.Name = "buttonSend4";
            this.buttonSend4.Size = new System.Drawing.Size(48, 24);
            this.buttonSend4.TabIndex = 107;
            this.buttonSend4.Text = "Send";
            this.buttonSend4.UseVisualStyleBackColor = true;
            this.buttonSend4.Click += new System.EventHandler(this.buttonSend4_Click);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 47);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(19, 14);
            this.label20.TabIndex = 118;
            this.label20.Text = "F2";
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(268, 3);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(28, 14);
            this.label26.TabIndex = 134;
            this.label26.Text = "HEX";
            // 
            // checkBoxHex16
            // 
            this.checkBoxHex16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex16.AutoSize = true;
            this.checkBoxHex16.Location = new System.Drawing.Point(274, 219);
            this.checkBoxHex16.Name = "checkBoxHex16";
            this.checkBoxHex16.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex16.TabIndex = 140;
            this.checkBoxHex16.UseVisualStyleBackColor = true;
            // 
            // textSend9
            // 
            this.textSend9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend9.Location = new System.Drawing.Point(37, 15);
            this.textSend9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend9.Name = "textSend9";
            this.textSend9.Size = new System.Drawing.Size(231, 21);
            this.textSend9.TabIndex = 58;
            this.textSend9.Text = "CT-ADC;";
            // 
            // checkBoxHex15
            // 
            this.checkBoxHex15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex15.AutoSize = true;
            this.checkBoxHex15.Location = new System.Drawing.Point(274, 190);
            this.checkBoxHex15.Name = "checkBoxHex15";
            this.checkBoxHex15.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex15.TabIndex = 139;
            this.checkBoxHex15.UseVisualStyleBackColor = true;
            // 
            // buttonSend9
            // 
            this.buttonSend9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend9.Location = new System.Drawing.Point(295, 13);
            this.buttonSend9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend9.Name = "buttonSend9";
            this.buttonSend9.Size = new System.Drawing.Size(48, 24);
            this.buttonSend9.TabIndex = 57;
            this.buttonSend9.Text = "Send";
            this.buttonSend9.UseVisualStyleBackColor = true;
            this.buttonSend9.Click += new System.EventHandler(this.buttonSend9_Click);
            // 
            // checkBoxHex14
            // 
            this.checkBoxHex14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex14.AutoSize = true;
            this.checkBoxHex14.Location = new System.Drawing.Point(274, 162);
            this.checkBoxHex14.Name = "checkBoxHex14";
            this.checkBoxHex14.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex14.TabIndex = 138;
            this.checkBoxHex14.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 14);
            this.label3.TabIndex = 76;
            this.label3.Text = "F1";
            // 
            // checkBoxHex13
            // 
            this.checkBoxHex13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex13.AutoSize = true;
            this.checkBoxHex13.Location = new System.Drawing.Point(274, 133);
            this.checkBoxHex13.Name = "checkBoxHex13";
            this.checkBoxHex13.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex13.TabIndex = 137;
            this.checkBoxHex13.UseVisualStyleBackColor = true;
            // 
            // buttonSend10
            // 
            this.buttonSend10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend10.Location = new System.Drawing.Point(295, 41);
            this.buttonSend10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend10.Name = "buttonSend10";
            this.buttonSend10.Size = new System.Drawing.Size(48, 24);
            this.buttonSend10.TabIndex = 59;
            this.buttonSend10.Text = "Send";
            this.buttonSend10.UseVisualStyleBackColor = true;
            this.buttonSend10.Click += new System.EventHandler(this.buttonSend10_Click);
            // 
            // checkBoxHex12
            // 
            this.checkBoxHex12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex12.AutoSize = true;
            this.checkBoxHex12.Location = new System.Drawing.Point(274, 105);
            this.checkBoxHex12.Name = "checkBoxHex12";
            this.checkBoxHex12.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex12.TabIndex = 136;
            this.checkBoxHex12.UseVisualStyleBackColor = true;
            // 
            // textSend16
            // 
            this.textSend16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend16.Location = new System.Drawing.Point(36, 214);
            this.textSend16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend16.Name = "textSend16";
            this.textSend16.Size = new System.Drawing.Size(231, 21);
            this.textSend16.TabIndex = 72;
            this.textSend16.Text = "CT-AT+CSMINS?<cr>;";
            // 
            // checkBoxHex11
            // 
            this.checkBoxHex11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex11.AutoSize = true;
            this.checkBoxHex11.Location = new System.Drawing.Point(274, 76);
            this.checkBoxHex11.Name = "checkBoxHex11";
            this.checkBoxHex11.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex11.TabIndex = 135;
            this.checkBoxHex11.UseVisualStyleBackColor = true;
            // 
            // textSend10
            // 
            this.textSend10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend10.Location = new System.Drawing.Point(37, 43);
            this.textSend10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend10.Name = "textSend10";
            this.textSend10.Size = new System.Drawing.Size(231, 21);
            this.textSend10.TabIndex = 60;
            this.textSend10.Text = "CT-GRST;";
            // 
            // checkBoxHex10
            // 
            this.checkBoxHex10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex10.AutoSize = true;
            this.checkBoxHex10.Location = new System.Drawing.Point(274, 48);
            this.checkBoxHex10.Name = "checkBoxHex10";
            this.checkBoxHex10.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex10.TabIndex = 134;
            this.checkBoxHex10.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 14);
            this.label4.TabIndex = 77;
            this.label4.Text = "F2";
            // 
            // checkBoxHex9
            // 
            this.checkBoxHex9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHex9.AutoSize = true;
            this.checkBoxHex9.Location = new System.Drawing.Point(274, 19);
            this.checkBoxHex9.Name = "checkBoxHex9";
            this.checkBoxHex9.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHex9.TabIndex = 133;
            this.checkBoxHex9.UseVisualStyleBackColor = true;
            // 
            // buttonSend11
            // 
            this.buttonSend11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend11.Location = new System.Drawing.Point(295, 69);
            this.buttonSend11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend11.Name = "buttonSend11";
            this.buttonSend11.Size = new System.Drawing.Size(48, 24);
            this.buttonSend11.TabIndex = 61;
            this.buttonSend11.Text = "Send";
            this.buttonSend11.UseVisualStyleBackColor = true;
            this.buttonSend11.Click += new System.EventHandler(this.buttonSend11_Click);
            // 
            // buttonSend16
            // 
            this.buttonSend16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend16.Location = new System.Drawing.Point(295, 213);
            this.buttonSend16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend16.Name = "buttonSend16";
            this.buttonSend16.Size = new System.Drawing.Size(48, 24);
            this.buttonSend16.TabIndex = 71;
            this.buttonSend16.Text = "Send";
            this.buttonSend16.UseVisualStyleBackColor = true;
            this.buttonSend16.Click += new System.EventHandler(this.buttonSend16_Click);
            // 
            // textSend11
            // 
            this.textSend11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend11.Location = new System.Drawing.Point(37, 71);
            this.textSend11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend11.Name = "textSend11";
            this.textSend11.Size = new System.Drawing.Size(231, 21);
            this.textSend11.TabIndex = 62;
            this.textSend11.Text = "CT-TS1;";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 14);
            this.label5.TabIndex = 78;
            this.label5.Text = "F3";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 14);
            this.label13.TabIndex = 87;
            this.label13.Text = "Shift+";
            // 
            // textSend15
            // 
            this.textSend15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend15.Location = new System.Drawing.Point(37, 186);
            this.textSend15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend15.Name = "textSend15";
            this.textSend15.Size = new System.Drawing.Size(231, 21);
            this.textSend15.TabIndex = 70;
            this.textSend15.Text = "CT-AT+COPS?<cr>;";
            // 
            // buttonSend12
            // 
            this.buttonSend12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend12.Location = new System.Drawing.Point(295, 97);
            this.buttonSend12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend12.Name = "buttonSend12";
            this.buttonSend12.Size = new System.Drawing.Size(48, 24);
            this.buttonSend12.TabIndex = 63;
            this.buttonSend12.Text = "Send";
            this.buttonSend12.UseVisualStyleBackColor = true;
            this.buttonSend12.Click += new System.EventHandler(this.buttonSend12_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 14);
            this.label8.TabIndex = 79;
            this.label8.Text = "F4";
            // 
            // textSend12
            // 
            this.textSend12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend12.Location = new System.Drawing.Point(37, 99);
            this.textSend12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend12.Name = "textSend12";
            this.textSend12.Size = new System.Drawing.Size(231, 21);
            this.textSend12.TabIndex = 64;
            this.textSend12.Text = "CT-TS0;";
            // 
            // buttonSend15
            // 
            this.buttonSend15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend15.Location = new System.Drawing.Point(295, 184);
            this.buttonSend15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend15.Name = "buttonSend15";
            this.buttonSend15.Size = new System.Drawing.Size(48, 24);
            this.buttonSend15.TabIndex = 69;
            this.buttonSend15.Text = "Send";
            this.buttonSend15.UseVisualStyleBackColor = true;
            this.buttonSend15.Click += new System.EventHandler(this.buttonSend15_Click);
            // 
            // buttonSend13
            // 
            this.buttonSend13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend13.Location = new System.Drawing.Point(295, 126);
            this.buttonSend13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend13.Name = "buttonSend13";
            this.buttonSend13.Size = new System.Drawing.Size(48, 24);
            this.buttonSend13.TabIndex = 65;
            this.buttonSend13.Text = "Send";
            this.buttonSend13.UseVisualStyleBackColor = true;
            this.buttonSend13.Click += new System.EventHandler(this.buttonSend13_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 14);
            this.label7.TabIndex = 80;
            this.label7.Text = "F5";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 14);
            this.label9.TabIndex = 83;
            this.label9.Text = "F8";
            // 
            // textSend14
            // 
            this.textSend14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend14.Location = new System.Drawing.Point(37, 157);
            this.textSend14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend14.Name = "textSend14";
            this.textSend14.Size = new System.Drawing.Size(231, 21);
            this.textSend14.TabIndex = 68;
            this.textSend14.Text = "CT-AT+NETCLOSE<cr>;";
            // 
            // textSend13
            // 
            this.textSend13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSend13.Location = new System.Drawing.Point(37, 128);
            this.textSend13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSend13.Name = "textSend13";
            this.textSend13.Size = new System.Drawing.Size(231, 21);
            this.textSend13.TabIndex = 66;
            this.textSend13.Text = "CT-AT+TCPWRITE=8<cr>;";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 14);
            this.label6.TabIndex = 81;
            this.label6.Text = "F6";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 190);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 14);
            this.label10.TabIndex = 82;
            this.label10.Text = "F7";
            // 
            // buttonSend14
            // 
            this.buttonSend14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend14.Location = new System.Drawing.Point(295, 155);
            this.buttonSend14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend14.Name = "buttonSend14";
            this.buttonSend14.Size = new System.Drawing.Size(48, 24);
            this.buttonSend14.TabIndex = 67;
            this.buttonSend14.Text = "Send";
            this.buttonSend14.UseVisualStyleBackColor = true;
            this.buttonSend14.Click += new System.EventHandler(this.buttonSend14_Click);
            // 
            // StopBitsComboBox
            // 
            this.StopBitsComboBox.AllowDrop = true;
            this.StopBitsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StopBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StopBitsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopBitsComboBox.FormattingEnabled = true;
            this.StopBitsComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "1.5",
            "2"});
            this.StopBitsComboBox.Location = new System.Drawing.Point(68, 395);
            this.StopBitsComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StopBitsComboBox.Name = "StopBitsComboBox";
            this.StopBitsComboBox.Size = new System.Drawing.Size(84, 22);
            this.StopBitsComboBox.TabIndex = 98;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(3, 398);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 14);
            this.label24.TabIndex = 99;
            this.label24.Text = "Stop Bits";
            // 
            // ParityComboBox
            // 
            this.ParityComboBox.AllowDrop = true;
            this.ParityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ParityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParityComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ParityComboBox.FormattingEnabled = true;
            this.ParityComboBox.Items.AddRange(new object[] {
            "none",
            "odd",
            "even",
            "mark"});
            this.ParityComboBox.Location = new System.Drawing.Point(68, 366);
            this.ParityComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ParityComboBox.Name = "ParityComboBox";
            this.ParityComboBox.Size = new System.Drawing.Size(84, 22);
            this.ParityComboBox.TabIndex = 96;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(3, 369);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(37, 14);
            this.label23.TabIndex = 97;
            this.label23.Text = "Parity";
            // 
            // DataBitsComboBox
            // 
            this.DataBitsComboBox.AllowDrop = true;
            this.DataBitsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DataBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataBitsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataBitsComboBox.FormattingEnabled = true;
            this.DataBitsComboBox.Items.AddRange(new object[] {
            "7",
            "8"});
            this.DataBitsComboBox.Location = new System.Drawing.Point(68, 338);
            this.DataBitsComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DataBitsComboBox.Name = "DataBitsComboBox";
            this.DataBitsComboBox.Size = new System.Drawing.Size(84, 22);
            this.DataBitsComboBox.TabIndex = 85;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 341);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 14);
            this.label11.TabIndex = 86;
            this.label11.Text = "Data Bits";
            // 
            // programCT100iButton
            // 
            this.programCT100iButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.programCT100iButton.Location = new System.Drawing.Point(6, 428);
            this.programCT100iButton.Name = "programCT100iButton";
            this.programCT100iButton.Size = new System.Drawing.Size(95, 23);
            this.programCT100iButton.TabIndex = 75;
            this.programCT100iButton.Text = "CT100i";
            this.programCT100iButton.UseVisualStyleBackColor = true;
            this.programCT100iButton.Click += new System.EventHandler(this.programCT100iButton_Click);
            // 
            // bootloaderStepProgramButton
            // 
            this.bootloaderStepProgramButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bootloaderStepProgramButton.Location = new System.Drawing.Point(6, 457);
            this.bootloaderStepProgramButton.Name = "bootloaderStepProgramButton";
            this.bootloaderStepProgramButton.Size = new System.Drawing.Size(95, 23);
            this.bootloaderStepProgramButton.TabIndex = 74;
            this.bootloaderStepProgramButton.Text = "Serial Program";
            this.bootloaderStepProgramButton.UseVisualStyleBackColor = true;
            this.bootloaderStepProgramButton.Click += new System.EventHandler(this.bootloaderStepProgram_Click);
            // 
            // serialTextBox
            // 
            this.serialTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serialTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.serialTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialTextBox.Location = new System.Drawing.Point(0, 0);
            this.serialTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.serialTextBox.Name = "serialTextBox";
            this.serialTextBox.ReadOnly = true;
            this.serialTextBox.Size = new System.Drawing.Size(894, 241);
            this.serialTextBox.TabIndex = 73;
            this.serialTextBox.Text = "";
            this.serialTextBox.SizeChanged += new System.EventHandler(this.serialTextBox_SizeChanged);
            this.serialTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.serialTextBox_MouseUp);
            // 
            // tabTCP
            // 
            this.tabTCP.BackColor = System.Drawing.SystemColors.Control;
            this.tabTCP.Controls.Add(this.sendTCPButton1);
            this.tabTCP.Controls.Add(this.textTCP1);
            this.tabTCP.Controls.Add(this.tcpOpen);
            this.tabTCP.Controls.Add(this.TCPlog);
            this.tabTCP.Location = new System.Drawing.Point(4, 23);
            this.tabTCP.Name = "tabTCP";
            this.tabTCP.Padding = new System.Windows.Forms.Padding(3);
            this.tabTCP.Size = new System.Drawing.Size(897, 497);
            this.tabTCP.TabIndex = 2;
            this.tabTCP.Text = "TCP";
            // 
            // sendTCPButton1
            // 
            this.sendTCPButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sendTCPButton1.Location = new System.Drawing.Point(205, 307);
            this.sendTCPButton1.Name = "sendTCPButton1";
            this.sendTCPButton1.Size = new System.Drawing.Size(75, 23);
            this.sendTCPButton1.TabIndex = 3;
            this.sendTCPButton1.Text = "Send";
            this.sendTCPButton1.UseVisualStyleBackColor = true;
            this.sendTCPButton1.Click += new System.EventHandler(this.sendTCPButton1_Click);
            // 
            // textTCP1
            // 
            this.textTCP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textTCP1.Location = new System.Drawing.Point(9, 310);
            this.textTCP1.Name = "textTCP1";
            this.textTCP1.Size = new System.Drawing.Size(189, 21);
            this.textTCP1.TabIndex = 2;
            this.textTCP1.Text = "[S0|040000|S-RD1;|]$AB$04";
            // 
            // tcpOpen
            // 
            this.tcpOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tcpOpen.Location = new System.Drawing.Point(624, 6);
            this.tcpOpen.Name = "tcpOpen";
            this.tcpOpen.Size = new System.Drawing.Size(75, 23);
            this.tcpOpen.TabIndex = 1;
            this.tcpOpen.Text = "Open";
            this.tcpOpen.UseVisualStyleBackColor = true;
            this.tcpOpen.Click += new System.EventHandler(this.tcpOpen_Click);
            // 
            // TCPlog
            // 
            this.TCPlog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TCPlog.Location = new System.Drawing.Point(6, 6);
            this.TCPlog.Name = "TCPlog";
            this.TCPlog.Size = new System.Drawing.Size(612, 270);
            this.TCPlog.TabIndex = 0;
            this.TCPlog.Text = "";
            // 
            // CRCTab
            // 
            this.CRCTab.BackColor = System.Drawing.SystemColors.Control;
            this.CRCTab.Controls.Add(this.label22);
            this.CRCTab.Controls.Add(this.imeiButton);
            this.CRCTab.Controls.Add(this.imeiOutputTextBox);
            this.CRCTab.Controls.Add(this.imeiInputTextBox);
            this.CRCTab.Controls.Add(this.label12);
            this.CRCTab.Controls.Add(this.crc_convertButton2);
            this.CRCTab.Controls.Add(this.txtConvertedString2);
            this.CRCTab.Controls.Add(this.txtStringToSend2);
            this.CRCTab.Controls.Add(this.crcDescriptorLabel);
            this.CRCTab.Controls.Add(this.crc_convertButton);
            this.CRCTab.Controls.Add(this.txtConvertedString);
            this.CRCTab.Controls.Add(this.txtStringToSend);
            this.CRCTab.Location = new System.Drawing.Point(4, 23);
            this.CRCTab.Name = "CRCTab";
            this.CRCTab.Padding = new System.Windows.Forms.Padding(3);
            this.CRCTab.Size = new System.Drawing.Size(897, 497);
            this.CRCTab.TabIndex = 3;
            this.CRCTab.Text = "CRC";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(243, 264);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(174, 14);
            this.label22.TabIndex = 12;
            this.label22.Text = "Enter 14 digit IMEI. Get last digit";
            // 
            // imeiButton
            // 
            this.imeiButton.Location = new System.Drawing.Point(351, 281);
            this.imeiButton.Name = "imeiButton";
            this.imeiButton.Size = new System.Drawing.Size(82, 39);
            this.imeiButton.TabIndex = 11;
            this.imeiButton.Text = "Convert and Copy to Clipboard";
            this.imeiButton.UseVisualStyleBackColor = true;
            this.imeiButton.Click += new System.EventHandler(this.imeiButton_Click);
            // 
            // imeiOutputTextBox
            // 
            this.imeiOutputTextBox.Location = new System.Drawing.Point(246, 309);
            this.imeiOutputTextBox.Name = "imeiOutputTextBox";
            this.imeiOutputTextBox.Size = new System.Drawing.Size(99, 21);
            this.imeiOutputTextBox.TabIndex = 10;
            // 
            // imeiInputTextBox
            // 
            this.imeiInputTextBox.Location = new System.Drawing.Point(246, 281);
            this.imeiInputTextBox.MaxLength = 14;
            this.imeiInputTextBox.Name = "imeiInputTextBox";
            this.imeiInputTextBox.Size = new System.Drawing.Size(99, 21);
            this.imeiInputTextBox.TabIndex = 9;
            this.imeiInputTextBox.Text = "3549200301";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(133, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(197, 14);
            this.label12.TabIndex = 8;
            this.label12.Text = "Enter general string to get checksum";
            // 
            // crc_convertButton2
            // 
            this.crc_convertButton2.Location = new System.Drawing.Point(482, 183);
            this.crc_convertButton2.Name = "crc_convertButton2";
            this.crc_convertButton2.Size = new System.Drawing.Size(82, 39);
            this.crc_convertButton2.TabIndex = 7;
            this.crc_convertButton2.Text = "Convert and Copy to Clipboard";
            this.crc_convertButton2.UseVisualStyleBackColor = true;
            this.crc_convertButton2.Click += new System.EventHandler(this.crc_convertButton2_Click);
            // 
            // txtConvertedString2
            // 
            this.txtConvertedString2.Location = new System.Drawing.Point(136, 201);
            this.txtConvertedString2.Name = "txtConvertedString2";
            this.txtConvertedString2.Size = new System.Drawing.Size(340, 21);
            this.txtConvertedString2.TabIndex = 6;
            // 
            // txtStringToSend2
            // 
            this.txtStringToSend2.Location = new System.Drawing.Point(136, 173);
            this.txtStringToSend2.Name = "txtStringToSend2";
            this.txtStringToSend2.Size = new System.Drawing.Size(340, 21);
            this.txtStringToSend2.TabIndex = 5;
            this.txtStringToSend2.Text = "[U0|";
            // 
            // crcDescriptorLabel
            // 
            this.crcDescriptorLabel.AutoSize = true;
            this.crcDescriptorLabel.Location = new System.Drawing.Point(133, 73);
            this.crcDescriptorLabel.Name = "crcDescriptorLabel";
            this.crcDescriptorLabel.Size = new System.Drawing.Size(297, 14);
            this.crcDescriptorLabel.TabIndex = 4;
            this.crcDescriptorLabel.Text = "Enter the CT- Command you want to convert to remote.";
            // 
            // crc_convertButton
            // 
            this.crc_convertButton.Location = new System.Drawing.Point(482, 100);
            this.crc_convertButton.Name = "crc_convertButton";
            this.crc_convertButton.Size = new System.Drawing.Size(82, 39);
            this.crc_convertButton.TabIndex = 2;
            this.crc_convertButton.Text = "Convert and Copy to Clipboard";
            this.crc_convertButton.UseVisualStyleBackColor = true;
            this.crc_convertButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtConvertedString
            // 
            this.txtConvertedString.Location = new System.Drawing.Point(136, 118);
            this.txtConvertedString.Name = "txtConvertedString";
            this.txtConvertedString.Size = new System.Drawing.Size(340, 21);
            this.txtConvertedString.TabIndex = 1;
            // 
            // txtStringToSend
            // 
            this.txtStringToSend.Location = new System.Drawing.Point(136, 90);
            this.txtStringToSend.Name = "txtStringToSend";
            this.txtStringToSend.Size = new System.Drawing.Size(340, 21);
            this.txtStringToSend.TabIndex = 0;
            this.txtStringToSend.Text = "CT-";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 24);
            this.menuStrip1.TabIndex = 42;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // rightClickContextMain
            // 
            this.rightClickContextMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rightClickClear,
            this.toolStripSeparator1,
            this.rightClick_DisplayText});
            this.rightClickContextMain.Name = "rightClickContextMain";
            this.rightClickContextMain.Size = new System.Drawing.Size(165, 76);
            // 
            // rightClickClear
            // 
            this.rightClickClear.Name = "rightClickClear";
            this.rightClickClear.Size = new System.Drawing.Size(164, 22);
            this.rightClickClear.Text = "Clear";
            this.rightClickClear.Click += new System.EventHandler(this.rightClickClear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // rightClick_DisplayText
            // 
            this.rightClick_DisplayText.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rightClick_NoSpecial,
            this.rightClick_Normal,
            this.rightClick_AllButNL,
            this.rightClick_HEX});
            this.rightClick_DisplayText.Name = "rightClick_DisplayText";
            this.rightClick_DisplayText.Size = new System.Drawing.Size(164, 22);
            this.rightClick_DisplayText.Text = "Text Display Type";
            // 
            // rightClick_NoSpecial
            // 
            this.rightClick_NoSpecial.Name = "rightClick_NoSpecial";
            this.rightClick_NoSpecial.Size = new System.Drawing.Size(200, 22);
            this.rightClick_NoSpecial.Text = "No Special Characters";
            this.rightClick_NoSpecial.Click += new System.EventHandler(this.rightClick_NoSpecial_Click);
            // 
            // rightClick_Normal
            // 
            this.rightClick_Normal.Name = "rightClick_Normal";
            this.rightClick_Normal.Size = new System.Drawing.Size(200, 22);
            this.rightClick_Normal.Text = "Normal";
            this.rightClick_Normal.Click += new System.EventHandler(this.rightClick_Normal_Click);
            // 
            // rightClick_HEX
            // 
            this.rightClick_HEX.Name = "rightClick_HEX";
            this.rightClick_HEX.Size = new System.Drawing.Size(200, 22);
            this.rightClick_HEX.Text = "All HEX";
            this.rightClick_HEX.Click += new System.EventHandler(this.rightClick_HEX_Click);
            // 
            // rightClick_AllButNL
            // 
            this.rightClick_AllButNL.Name = "rightClick_AllButNL";
            this.rightClick_AllButNL.Size = new System.Drawing.Size(200, 22);
            this.rightClick_AllButNL.Text = "All HEX Except \\n and \\r";
            this.rightClick_AllButNL.Click += new System.EventHandler(this.rightClick_AllButNL_Click);
            // 
            // SerialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 544);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SerialForm";
            this.Text = "Serial Interface";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SerialInterface_FormClosing);
            this.Load += new System.EventHandler(this.SerialInterface_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SerialForm_KeyDown);
            this.tabControl.ResumeLayout(false);
            this.tabSerial.ResumeLayout(false);
            this.tabSerial.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabTCP.ResumeLayout(false);
            this.tabTCP.PerformLayout();
            this.CRCTab.ResumeLayout(false);
            this.CRCTab.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.rightClickContextMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox BaudRateDropDown;
        private System.Windows.Forms.Button buttonOpenComms;
        private System.Windows.Forms.Button clearTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComPortDropDown;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSerial;
        private System.Windows.Forms.RichTextBox serialTextBox;
        private System.Windows.Forms.TextBox textSend16;
        private System.Windows.Forms.Button buttonSend16;
        private System.Windows.Forms.TextBox textSend15;
        private System.Windows.Forms.Button buttonSend15;
        private System.Windows.Forms.TextBox textSend14;
        private System.Windows.Forms.Button buttonSend14;
        private System.Windows.Forms.TextBox textSend13;
        private System.Windows.Forms.Button buttonSend13;
        private System.Windows.Forms.TextBox textSend12;
        private System.Windows.Forms.Button buttonSend12;
        private System.Windows.Forms.TextBox textSend11;
        private System.Windows.Forms.Button buttonSend11;
        private System.Windows.Forms.TextBox textSend10;
        private System.Windows.Forms.Button buttonSend10;
        private System.Windows.Forms.TextBox textSend9;
        private System.Windows.Forms.Button buttonSend9;
        private System.Windows.Forms.TabPage tabTCP;
        private System.Windows.Forms.Button tcpOpen;
        private System.Windows.Forms.RichTextBox TCPlog;
        private System.Windows.Forms.Button sendTCPButton1;
        private System.Windows.Forms.TextBox textTCP1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button bootloaderStepProgramButton;
        private System.Windows.Forms.Button programCT100iButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage CRCTab;
        private System.Windows.Forms.Button crc_convertButton;
        private System.Windows.Forms.TextBox txtConvertedString;
        private System.Windows.Forms.TextBox txtStringToSend;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.Label crcDescriptorLabel;
        private System.Windows.Forms.ComboBox DataBitsComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button crc_convertButton2;
        private System.Windows.Forms.TextBox txtConvertedString2;
        private System.Windows.Forms.TextBox txtStringToSend2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button imeiButton;
        private System.Windows.Forms.TextBox imeiOutputTextBox;
        private System.Windows.Forms.TextBox imeiInputTextBox;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.ComboBox StopBitsComboBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox ParityComboBox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textSend1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonSend1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button buttonSend2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textSend2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button buttonSend3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textSend3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button buttonSend4;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textSend4;
        private System.Windows.Forms.TextBox textSend8;
        private System.Windows.Forms.Button buttonSend5;
        private System.Windows.Forms.Button buttonSend8;
        private System.Windows.Forms.TextBox textSend5;
        private System.Windows.Forms.TextBox textSend7;
        private System.Windows.Forms.Button buttonSend6;
        private System.Windows.Forms.Button buttonSend7;
        private System.Windows.Forms.TextBox textSend6;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip rightClickContextMain;
        private System.Windows.Forms.ToolStripMenuItem rightClickClear;
        private System.Windows.Forms.CheckBox checkBoxHex8;
        private System.Windows.Forms.CheckBox checkBoxHex7;
        private System.Windows.Forms.CheckBox checkBoxHex6;
        private System.Windows.Forms.CheckBox checkBoxHex5;
        private System.Windows.Forms.CheckBox checkBoxHex4;
        private System.Windows.Forms.CheckBox checkBoxHex3;
        private System.Windows.Forms.CheckBox checkBoxHex2;
        private System.Windows.Forms.CheckBox checkBoxHex1;
        private System.Windows.Forms.CheckBox checkBoxHex16;
        private System.Windows.Forms.CheckBox checkBoxHex15;
        private System.Windows.Forms.CheckBox checkBoxHex14;
        private System.Windows.Forms.CheckBox checkBoxHex13;
        private System.Windows.Forms.CheckBox checkBoxHex12;
        private System.Windows.Forms.CheckBox checkBoxHex11;
        private System.Windows.Forms.CheckBox checkBoxHex10;
        private System.Windows.Forms.CheckBox checkBoxHex9;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem rightClick_DisplayText;
        private System.Windows.Forms.ToolStripMenuItem rightClick_Normal;
        private System.Windows.Forms.ToolStripMenuItem rightClick_HEX;
        private System.Windows.Forms.ToolStripMenuItem rightClick_NoSpecial;
        private System.Windows.Forms.ToolStripMenuItem rightClick_AllButNL;
    }
}

