using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SerialTerminal.ProgTab
{
    class Programmer
    {
        private byte[] nextLine = new byte[1024];
        private ChipConfig chipConfig = new ChipConfig();

        public delegate void AppendMainTB_Delegate(string data, Color color);
        public static event AppendMainTB_Delegate AppendLog_TB;
        public delegate void SetMainTB_Delegate(string data, Color color);
        public static event SetMainTB_Delegate SetLog_TB;

        public delegate void StartButton_Delegate(string text, bool enable);
        public static event StartButton_Delegate StartProg_Button;

        public delegate void StopButton_Delegate(bool enable);
        public static event StopButton_Delegate StopProg_Button;

        public delegate void RestartTimer_Delegate();
        public static event RestartTimer_Delegate RestartTimer;

        public delegate void ClearTB_Delegate();
        public static event ClearTB_Delegate ClearTB_Event;

        private Stopwatch stopWatch;
        public System.Windows.Forms.Timer serialTimer;
        private Process proc;
        //[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern int memcmp(byte[] b1, byte[] b2, long count);

        public Programmer()
        {
            string result = UpdateFileName(SerialTerminal.Config.Data.Prog_Firmware_SPI);

            //if (SetHex100_TB != null)
            //{
            //    SetHex100_TB(result);
            //}

            //prog_FirmType_DD
            stopWatch = new Stopwatch();
            serialTimer = new System.Windows.Forms.Timer();

            serialTimer.Interval = 20000;   //20s for debugging
            serialTimer.Tick += new EventHandler(serialTimer_Tick);
        }

        void serialTimer_Tick(object sender, EventArgs e)
        {

        }

        static public string UpdateFileName(string fileloc)
        {
            string result = "";
            if (fileloc != null && !fileloc.Equals(""))
            {
                char[] lastIndexChars = { '\\', '/' };
                result = "..." + fileloc.Substring(fileloc.LastIndexOfAny(lastIndexChars) + 1);
            }

            return result;
        }

        public void browse100_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "hex,ct|*.hex;*.ct";
            //Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|" + "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                SerialTerminal.Config.Data.Prog_Firmware_SPI = fileDialog.FileName;

                string result = UpdateFileName(SerialTerminal.Config.Data.Prog_Firmware_SPI);

                //if (SetHex100_TB != null)
                //{
                //    SetHex100_TB(result);
                //}
            }
        }

        private void myProcess_Exited(object sender, System.EventArgs e)
        {
            //end of process...
            AppendTB("\r\nFinished Programming\r\n", Color.Green);
            proc.Dispose();
        }

        private void ProgrammerStart(string firmwareType, string fileName)
        {
            //-p CT200i_ZigBee -f "C:\Users\Ryan\Documents\Embedded_Projects\CT200i\ZigbeeTrunk\Release\CT_ZigBee_4_07_C.hex"
            //Process proc = new Process();
            string arguments = "--type " + firmwareType + " --firmpath \"" + fileName + "\" --ignorepause";

            if (File.Exists("ISP Programmer.exe"))
            {
                proc = new Process();
                proc.StartInfo.FileName = "ISP Programmer.exe";
                proc.StartInfo.Arguments = arguments;
                //proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                proc.StartInfo.CreateNoWindow = true;
                proc.EnableRaisingEvents = true;
                proc.Exited += new EventHandler(myProcess_Exited);
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();


                proc.OutputDataReceived += (sender, args) => Redirect(args.Data, Color.Black);
                proc.BeginOutputReadLine();
            }
            else
            {
                AppendTB("Error: Programmer app doesn't exist\r\n", Color.Red);
            }
        }

        public void StartProg_100_Click(object sender, EventArgs e)
        {
            //clear TB before we start
            ClearTB();

            StartProg_100();
        }

        private void StartProg_100()
        {
            AppendTB("Programming the CT100i Chip\n", Color.Green);

            //check to ensure firmware file actually exists
            if (!File.Exists(SerialTerminal.Config.Data.Prog_Firmware_SPI))
            {
                AppendTB("Error: File doesn't exist\r\n", Color.Red);
            }

            //reset variables
            stopWatch.Start();
            serialTimer.Start();
            ProgrammerStart(chipConfig.DeviceList.Find(x => x.Contains("100")), SerialTerminal.Config.Data.Prog_Firmware_SPI);
        }

        public void stop_Button_Click(object sender, EventArgs e)
        {

        }


        private void UpdateButtonState()
        {
            if (StartProg_Button != null)
            {
                StartProg_Button("Start Programming", true);
            }

            if (StopProg_Button != null)
            {
                StopProg_Button(false);
            }

            if (StartProg_Button != null)
            {
                StartProg_Button("Programming...", false);
            }

            if (StopProg_Button != null)
            {
                StopProg_Button(true);
            }
        }

        private void AppendTB(string txt, Color color)
        {
            if (AppendLog_TB != null)
            {
                AppendLog_TB(txt, color);
            }
        }

        private void Redirect(string txt, Color color)
        {
            if (SetLog_TB != null)
            {
                if (txt != null && txt.Length > 0)
                {
                    SetLog_TB(txt, color);
                }
            }
        }

        public void ClearTB()
        {
            if (ClearTB_Event != null)
            {
                ClearTB_Event();
            }
        }

        public void ClearTB_Click(object sender, EventArgs e)
        {
            ClearTB();
        }
    }
}
