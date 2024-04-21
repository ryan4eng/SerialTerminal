using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialInterface
{
    public partial class SerialForm
    {
        //static string fileLocation = "C:/Users/Ryan/Documents/carbonTRACK/Arm_Projects/Character/Character/Debug/Character_7.hex";
        System.IO.StreamReader hexFile;

        bool hexFileIsOpen = false;

        private void buttonSend1_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend1, checkBoxHex1);
        }

        private void buttonSend2_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend2, checkBoxHex2);
        }

        private void buttonSend3_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend3, checkBoxHex3);
        }

        private void buttonSend4_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend4, checkBoxHex4);
        }

        private void buttonSend5_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend5, checkBoxHex5);
        }

        private void buttonSend6_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend6, checkBoxHex6);
        }

        private void buttonSend7_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend7, checkBoxHex7);
        }

        private void buttonSend8_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend8, checkBoxHex8);
        }

        private void buttonSend9_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend9, checkBoxHex9);
        }

        private void buttonSend10_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend10, checkBoxHex10);
        }

        private void buttonSend11_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend11, checkBoxHex11);
        }

        private void buttonSend12_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend12, checkBoxHex12);
        }

        private void buttonSend13_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend13, checkBoxHex13);
        }

        private void buttonSend14_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend14, checkBoxHex14);
        }

        private void buttonSend15_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend15, checkBoxHex15);
        }

        private void buttonSend16_Click(object sender, EventArgs e)
        {
            Process_Button_Click(textSend16, checkBoxHex16);
        }

        private void buttonOpenComms_Click(object sender, EventArgs e)
        {
            SetComPortStatus(COM_TOGGLE, sender, e);
        }


        private void clearTextBox_Click(object sender, EventArgs e)
        {
            serialTextBox.Clear();
        }
        private void bootloaderStepProgram_Click(object sender, EventArgs e)
        {
            if (hexFileIsOpen)
            {
                hexFile.Close();
            }

            if (AdvancedSettingsEnabled)
            {
                if (TestFirmwareHexLocation != null && !TestFirmwareHexLocation.Equals("") && File.Exists(TestFirmwareHexLocation))
                {
                    hexFile = new System.IO.StreamReader(TestFirmwareHexLocation);
                    AppendTextBox(serialTextBox, TestFirmwareHexLocation + " opened :)\n", Color.Green);
                    hexFileIsOpen = true;

                    BootloaderProgramming = true;
                    serialPort1.Write(":S;");

                    AppendTextBox(serialTextBox, ":S;", Color.DarkGreen);
                }
                else
                {
                    AppendTextBox(serialTextBox, ": " + TestFirmwareHexLocation + " doesn't exist or can't open :'(", Color.Red);
                }
            }



            //CTProgrammer.exe -p COM18 -r true -h "CarbonTrack\TrunkV5\Debug\CarbonTrackVxx.hex"

            //SetComPortStatus(COM_CLOSE, sender, e);
            //Process proc = new Process();
            //proc.StartInfo.FileName = "C:\\Users\\Ryan\\Documents\\carbonTRACK\\Avr Projects\\CarbonTrack\\NEW GSM Module\\Load.bat";
            //proc.StartInfo.FileName = "C:\\Users\\Ryan\\Documents\\carbonTRACK\\Avr Projects\\CTProgrammer.exe";
            //String str = "-p COM18 -h \"C:\\Users\\Ryan\\Documents\\carbonTRACK\\Avr Projects\\CarbonTrack\\NEW GSM Module\\Debug\\CarbonTrackV5_2_1.hex\"" + " -r true";
            //proc.StartInfo.Arguments = (str);
            //proc.Start();
            //SetComPortStatus(COM_OPEN, sender, e);
        }

        //        /k "C:\Users\Ryan\Documents\carbonTRACK\Avr Projects\CTProgrammer.exe" -p COM18
        private void programCT100iButton_Click(object sender, EventArgs e)
        {
            // SetComPortStatus(COM_CLOSE, sender, e);
            //Process.Start("C:\\Users\\Ryan\\Documents\\carbonTRACK\\Avr Projects\\CT_Load.bat");
        }


        /*****************************************************************************************************************************
        *   Right Click Menu Items
        *****************************************************************************************************************************/
        private void rightClickClear_Click(object sender, EventArgs e)
        {
            serialTextBox.Clear();
        }

        private void rightClick_NoSpecial_Click(object sender, EventArgs e)
        {
            HexAppendLevel = HEX_LEVEL_NONE;
        }

        private void rightClick_Normal_Click(object sender, EventArgs e)
        {
            HexAppendLevel = HEX_LEVEL_NORMAL;
        }


        private void rightClick_AllButNL_Click(object sender, EventArgs e)
        {
            HexAppendLevel = HEX_LEVEL_ALL_EXCEPT_NL;
        }

        private void rightClick_HEX_Click(object sender, EventArgs e)
        {
            HexAppendLevel = HEX_LEVEL_ALL;
        }
    }
}
