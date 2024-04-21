using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialInterface
{
    partial class SerialForm
    {
        private void button1_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[] { 164, 45 };
            // string test = Encoding.GetEncoding(1252).GetString(buffer, 0, 2);

            string data = "[S0|040000|S-" + txtStringToSend.Text.Trim().Replace(";", "") + "|]";

            int checkSum = GetCheckSum(data, data.Length);

            string finalString = string.Format(data + "${0:X2}$04", checkSum);
            txtConvertedString.Text = finalString;
            Clipboard.SetText(finalString);
        }

        private void crc_convertButton2_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[] { 164, 45 };
            // string test = Encoding.GetEncoding(1252).GetString(buffer, 0, 2);

            string data = "[S0|040000|S-" + txtStringToSend2.Text.Trim().Replace(";", "") + "|]";

            int checkSum = GetCheckSum(txtStringToSend2.Text, txtStringToSend2.Text.Length);

            string finalString = string.Format(txtStringToSend2.Text + "${0:X2}$04", checkSum);
            txtConvertedString2.Text = finalString;
            Clipboard.SetText(finalString);
        }

        static private int GetCheckSum(string data, int len)
        {
            int checkSum = 0;
            char[] chData = data.ToCharArray();

            for (int i = 0; i < len; i++)
            {
                checkSum += chData[i];
            }
            checkSum = (~checkSum) + 1;
            checkSum = checkSum & 0xFF;

            return checkSum;
        }



        private void imeiButton_Click(object sender, EventArgs e)
        {
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < imeiInputTextBox.Text.Length; i++)
            {
                int num = imeiInputTextBox.Text[i] - '0';
                if ((num < 10) && (num >= 0))
                {
                    if (i % 2 > 0)
                    {
                        int tmp = num * 2;
                        sum2 += tmp % 10 + tmp / 10;
                    }
                    else
                    {
                        sum1 += num;
                    }
                }
            }
            sum1 = 10 - (sum1 + sum2) % 10;

            if (sum1 == 10)
            {
                sum1 = 0;
            }

            imeiOutputTextBox.Text = imeiInputTextBox.Text+sum1.ToString();
            Clipboard.SetText(imeiOutputTextBox.Text);
        }

    }
}
