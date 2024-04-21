using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
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
[assembly: AssemblyVersion("0.5.0.0")]
[assembly: AssemblyFileVersion("0.5.0.0")]

   

namespace SerialInterface
{
    public partial class SerialForm : Form
    {
        private const int UART_BUFFER_MAX_SIZE = 256;
        public byte[] UARTRx_Buffer;
        public int UARTRx_Index;
        public static String SerialLogDirectory;
        public static String SerialLogFile;
        private static string TestFirmwareHexLocation;
        private static bool BootloaderProgramming = false;
        

        public static bool AdvancedSettingsEnabled = false;

        //0: None
        //1: Special Characters only
        //2: Special and New line
        //3. All Characters

        public static int HexAppendLevel = 1;
        // private TcpClient client;
        // private StreamWriter writer;
        System.IO.StreamWriter writer;
        private string Version_Number;

        public SerialForm()
        {
            InitializeComponent();
            //   AllocConsole();
        }

        // [DllImport("kernel32.dll", SetLastError = true)]
        // [return: MarshalAs(UnmanagedType.Bool)]
        // static extern bool AllocConsole();


        private void SerialInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            XMLInterface xmlObj = new XMLInterface();
            xmlObj.AdvancedSettings = AdvancedSettingsEnabled;
            xmlObj.BaudRate = BaudRateDropDown.SelectedIndex;
            xmlObj.ComPort = ComPortDropDown.SelectedIndex;
            xmlObj.DataBits = DataBitsComboBox.SelectedIndex;
            xmlObj.Parity = ParityComboBox.SelectedIndex;
            xmlObj.StopBits = StopBitsComboBox.SelectedIndex;

            xmlObj.LogLocation = SerialLogDirectory;
            xmlObj.SerialTextBox = new string[16];
            xmlObj.TestFirmwareHexLocation = TestFirmwareHexLocation;

            for (int i = 0; i < 16; i++)
            {
                xmlObj.SerialTextBox[i] = this.Controls.Find(string.Format("textSend{0}", i + 1), true)[0].Text;
            }
            SerializeToXML(xmlObj);

            //safety - close com port
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            if (writer.BaseStream != null)
            {
                writer.Close(); //remember to close the file again.
            }
            writer.Dispose(); //remember to dispose it from the memory.
        }

        private void SerialInterface_Load(object sender, EventArgs e)
        {
            UARTRx_Buffer = new byte[UART_BUFFER_MAX_SIZE];
            UARTRx_Index = 0;

            ComPortDropDown.SelectedIndex = 1;  //defaults to Com2. 1 will ALWAYS be taken
            BaudRateDropDown.SelectedIndex = 8; //should be 57600
            DataBitsComboBox.SelectedIndex = 1; //should be 8 data bits
            ParityComboBox.SelectedIndex = 0;   //should be none?
            StopBitsComboBox.SelectedIndex = 1; //should be one stop bit

            SerialLogDirectory = "";
            SerialLogFile = "Serial-Interface-" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";

            XMLInterface xmlObj = DeserializeFromXML();

            if (xmlObj != null)
            {
                AdvancedSettingsEnabled = xmlObj.AdvancedSettings;
                BaudRateDropDown.SelectedIndex = xmlObj.BaudRate;
                ComPortDropDown.SelectedIndex = xmlObj.ComPort;
                DataBitsComboBox.SelectedIndex = xmlObj.DataBits;
                ParityComboBox.SelectedIndex = xmlObj.Parity;
                StopBitsComboBox.SelectedIndex = xmlObj.StopBits;

                TestFirmwareHexLocation = xmlObj.TestFirmwareHexLocation;

                if (xmlObj.LogLocation != null && !xmlObj.LogLocation.Equals(""))
                {
                    //<LogLocation>Serial_Interface.log</LogLocation>
                    //remove old SerialInterface.log from older configs
                    if (!xmlObj.LogLocation.Equals("SerialInterface.log"))
                        SerialLogDirectory = xmlObj.LogLocation;
                }

                for (int i = 0; i < 16; i++)
                {
                    this.Controls.Find(string.Format("textSend{0}", i + 1), true)[0].Text = xmlObj.SerialTextBox[i];
                }
            }

            System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Version_Number = String.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            this.Text += " v" + Version_Number;

            this.KeyPreview = true;

            writer = new System.IO.StreamWriter(SerialLogDirectory + SerialLogFile, true); //open the file for writing.
            writer.Write("\r\n============================ " + DateTime.Now.ToString() + " ============================\r\n"); //write the current date to the file. change this with your date or something.
            writer.Close();

            ProcessAdvancedSettings(false);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("carbonTRACK Serial Interface\r\nVersion: " + Version_Number + "\n\nMade by Ryan Fleming\n" + DateTime.Now.ToString("yyyy-MM-dd"), "About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options opt = new Options();
            opt.Default_OptionsLogText = SerialLogDirectory;
            opt.Default_AdvancedSettingsEnabled = AdvancedSettingsEnabled;
            opt.FirmwarePath = TestFirmwareHexLocation;

            if (opt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Directory.Exists(opt.optionsLogTextBox.Text))
                {
                    if (opt.optionsLogTextBox.Text.EndsWith("\\"))
                        SerialForm.SerialLogDirectory = opt.optionsLogTextBox.Text;
                    else
                        SerialForm.SerialLogDirectory = opt.optionsLogTextBox.Text + "\\";

                }
                else if (!opt.optionsLogTextBox.Text.Equals(""))
                {
                    MessageBox.Show("Log directory doesn't exist.");
                }

                if (opt.advancedSettingsTickBox.Checked)
                {
                    SerialForm.AdvancedSettingsEnabled = true;
                    ProcessAdvancedSettings(false);
                }
                else
                {
                    BootloaderProgramming = false;
                    SerialForm.AdvancedSettingsEnabled = false;
                    ProcessAdvancedSettings(false);
                }

                TestFirmwareHexLocation = opt.FirmwarePath;
            }
            opt.Close();
        }

        //Minimising and Maximising stuff
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void serialTextBox_SizeChanged(object sender, EventArgs e)
        {
            ScrollToBottom(serialTextBox);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private const int WM_VSCROLL = 277;
        private const int SB_PAGEBOTTOM = 7;

        public static void ScrollToBottom(RichTextBox MyRichTextBox)
        {
            SendMessage(MyRichTextBox.Handle, WM_VSCROLL, (IntPtr)SB_PAGEBOTTOM, IntPtr.Zero);
        }

        private void serialTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rightClickContextMain.Show(Cursor.Position);
            }
        }
    }
}