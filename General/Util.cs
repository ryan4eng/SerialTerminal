using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialTerminal {
    static class Util {
        static public string ByteToHexBitFiddle(byte rawByte) {
            char[] c = new char[2];
            int b;

            b = rawByte >> 4;
            c[0] = (char)(55 + b + (((b - 10) >> 31) & -7));
            b = rawByte & 0xF;
            c[1] = (char)(55 + b + (((b - 10) >> 31) & -7));

            return new String(c);
        }

        static public int DropDownWidth(ComboBox myCombo) {
            int maxWidth = 0, temp = 0;
            foreach (var obj in myCombo.Items) {
                temp = TextRenderer.MeasureText(obj.ToString(), myCombo.Font).Width;
                if (temp > maxWidth) {
                    maxWidth = temp;
                }
            }
            return maxWidth;
        }

        static public int GetCheckSum(string data, int len) {
            int checkSum = 0;
            char[] chData = data.ToCharArray();

            for (int i = 0; i < len; i++) {
                checkSum += chData[i];
            }
            checkSum = (~checkSum) + 1;
            checkSum = checkSum & 0xFF;

            return checkSum;
        }

        public static string DecimalToArbitrarySystem(long decimalNumber, int radix) {
            const int BitsInLong = 64;
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (radix < 2 || radix > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " + Digits.Length.ToString());

            if (decimalNumber == 0)
                return "0";

            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(decimalNumber);
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0) {
                int remainder = (int)(currentNumber % radix);
                charArray[index--] = Digits[remainder];
                currentNumber = currentNumber / radix;
            }

            string result = new String(charArray, index + 1, BitsInLong - index - 1);
            if (decimalNumber < 0) {
                result = "-" + result;
            }

            return result;
        }

        public static long Base36ToDecimal(string input) {
            input = input.ToLower();
            const string CharList = "0123456789abcdefghijklmnopqrstuvwxyz";

            var reversed = input.ToLower().Reverse();
            long result = 0;
            int pos = 0;
            foreach (char c in reversed) {
                result += CharList.IndexOf(c) * (long)Math.Pow(36, pos);
                pos++;
            }
            return result;
        }

        public static void AppendRTB(RichTextBox rtb, string data, Color txt_colour) {
            if (data == null) {
                return;
            }

            int start = rtb.TextLength;

            rtb.AppendText(data);

            int end = rtb.TextLength;

            // Textbox may transform chars, so (end-start) != text.Length
            rtb.Select(start, end - start);
            rtb.SelectionColor = txt_colour;

            //reset color to defaults
            rtb.SelectionLength = 0;
            rtb.SelectionColor = rtb.ForeColor;

            //ensure text buffer stays below 15000 characters
            checkTextBoxLength(rtb);

            //move caret to bottom of page
            ScrollToBottom(rtb);
        }

        public static void UpdateLog(StringBuilder sb, string data, Color txt_colour, ref Color last_colour) {
            string header = @"{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Lucida Console;}}{\colortbl; \red155\green0\blue211; \red102\green102\blue102; \red0\green128\blue0; \red255\green0\blue0; \red0\green77\blue187;}\viewkind4\uc1\lined\sa200\sl276\slmult1\f0\fs16\lang9\cf0 ";

            if (data == null || data.Length == 0) {
                return;
            }

            bool buffer_empty = false;

            if (sb.Length > 15000) {
                //clear up tb
                sb.Remove(0, 10000);
                if (sb.ToString().StartsWith("{") || sb.ToString().StartsWith("}")) {
                    sb.Insert(0, '\\');
                }

                sb.Insert(0, header);
            }
            else if (sb.Length == 0) {
                buffer_empty = true;
                //set up 0
                sb.Clear();
                sb.Append(header);
                last_colour = Color.Black;
            }

            if (txt_colour != last_colour || data.Length == 0) {
                if (txt_colour == Color.Gray) {
                    sb.Append(@"\cf2 ");
                    last_colour = Color.Gray;
                }
                else if (txt_colour == Color.Red) {
                    sb.Append(@"\cf4 ");
                    last_colour = Color.Red;
                }
                else if (txt_colour == Color.Green) {
                    //port open and closed, on here check for \line. if it is not the last message, add new line
                    string tmp = sb.ToString();
                    if (!buffer_empty && !tmp.EndsWith(@"\line ")) {
                        sb.Append(@"\line ");
                    }

                    sb.Append(@"\cf3 ");
                    last_colour = Color.Green;
                }
                else if (txt_colour == Color.Purple) {
                    sb.Append(@"\cf1 ");
                    last_colour = Color.Purple;
                }
                else if (txt_colour == Color.Blue) {
                    sb.Append(@"\cf5 ");
                    last_colour = Color.Blue;
                }
                else {
                    sb.Append(@"\cf0 ");
                    last_colour = Color.Black;
                }
            }

            sb.Append(data.Replace(@"\", @"\\").Replace("{", @"\{").Replace("}", @"\}").Replace("\n", @"\line "));
        }

        private static void checkTextBoxLength(RichTextBox box) {
            //ensure text buffer in text box gets too large
            if (box.Text.Length > 15000) {
                box.ReadOnly = false;
                box.SelectionStart = 0;
                box.SelectionLength = box.TextLength - 10000;
                box.SelectedText = "";
                box.ReadOnly = true;
            }
        }

        //for scrolling
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private const int WM_VSCROLL = 277;
        private const int SB_PAGEBOTTOM = 7;
        public static void ScrollToBottom(RichTextBox rtb) {
            rtb.Select(rtb.TextLength, 0);
            rtb.ScrollToCaret();
            SendMessage(rtb.Handle, WM_VSCROLL, (IntPtr)SB_PAGEBOTTOM, IntPtr.Zero);
        }

        public static void SetTextbox(RichTextBox tb, string data, Color txtColor) {
            tb.Text = data;

            // Textbox may transform chars, so (end-start) != text.Length
            tb.Select(0, data.Length);
            tb.SelectionColor = txtColor;
            tb.SelectionAlignment = HorizontalAlignment.Center;
        }

        public static string ReplaceFirst(string text, string search, string replace) {
            int pos = text.IndexOf(search);
            if (pos < 0) {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        public static bool isHexChar(char c) {
            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F')) {
                return true;
            }
            return false;
        }

        public class CmdResponse {
            public string str;
            public Color color;
            public bool nl_check;

            public CmdResponse(string str, Color color, bool nl_check) {
                this.str = str;
                this.color = color;
                this.nl_check = nl_check;
            }
        }

        public static async void SendCommand(IProgress<CmdResponse> progress, Stream stream, string str, bool hex, bool line_feed) {
            if (stream == null || !stream.CanWrite) {
                progress.Report(new CmdResponse("Comport not opened\r\n", Color.Red, true));
                return;
            }

            if (hex) {
                string hexString = str.Replace(" ", "");
                int byteLength = hexString.Length / 2;

                if (hexString.Length % 2 != 0) {
                    progress.Report(new CmdResponse("Bad Hex Length\r\n", Color.Red, true));
                    return;
                }

                StringBuilder terminal_sb = new StringBuilder();
                MemoryStream ms = new MemoryStream();

                //byte[] byteArray = new byte[byteLength];
                for (int i = 0; i < hexString.Length; i += 2) {
                    string hs = hexString.Substring(i, 2);
                    byte b;
                    bool result = Byte.TryParse(hs, NumberStyles.HexNumber, null, out b);

                    if (!result) {
                        progress.Report(new CmdResponse("Bad Hex Value\r\n", Color.Red, true));
                        return;
                    }

                    ms.WriteByte(b);
                    terminal_sb.Append('{' + hs + '}');
                }

                if (line_feed) {
                    ms.WriteByte(0xa);  //add line feed character
                    terminal_sb.Append("{0A}");
                }

                progress.Report(new CmdResponse(terminal_sb.ToString(), Color.Purple, false));
                byte[] b_buff = ms.ToArray();
                try {
                    await stream.WriteAsync(b_buff, 0, b_buff.Length);
                }
                catch (Exception) {
                    progress.Report(new CmdResponse("Error: Couldn't write to port. Does it require DTR/CTS?\n", Color.Red, true));
                }
            }
            else {
                //match specifically for "<cr>" or "<lf>" and only ignore them as special characters if they're "<<cr>>" or "<<lf>>"
                Regex rgx = new Regex("(?<!<)<(<<)*(?!<)(lf|cr)(?<!>)>(>>)*(?!>)");
                MatchCollection mtches = rgx.Matches(str);
                if (mtches.Count > 0) {
                    StringBuilder sb1 = new StringBuilder(str);
                    for (int i = mtches.Count - 1; i >= 0; i--) {
                        Match m = mtches[i];
                        sb1.Remove(m.Index, m.Length);
                        string tmp = m.Value.Replace("<<", "<").Replace(">>", ">").Replace("<cr>", "\r").Replace("<lf>", "\n");
                        sb1.Insert(m.Index, tmp);
                    }
                    str = sb1.ToString();
                }

                //rgx = new Regex(@"(?<!\{)\{(\{\{)*(?!\{)[\da-fA-F\s]+(?<!\})\}(\}\})*(?!\})");
                //mtches = rgx.Matches(str);
                //string terminal_str = str;
                //MemoryStream msOut = new MemoryStream();
                //if (mtches.Count > 0) {
                //    StringBuilder sb = new StringBuilder(str);
                //    StringBuilder terminal_sb = new StringBuilder(str);
                //    //Start at the end so the indexes are maintained as the buffer changes...
                //    for (int i = mtches.Count - 1; i >= 0; i--) {
                //        Match m = mtches[i];
                //        sb.Remove(m.Index, m.Length);
                //        terminal_sb.Remove(m.Index, m.Length);
                //        int terminal_index = m.Index;
                //        /////////////////////////////////////
                //        // replace brackets
                //        string tmp = m.Value.ToUpper().Replace(" ", "");
                //        int count_open = 0;
                //        int count_closed = 0;
                //        for (int j = 0; j < tmp.Length; j++) {
                //            if (tmp[j] == '{') {
                //                count_open++;
                //            }
                //            else if (tmp[j] == '}') {
                //                count_closed++;
                //            }
                //        }
                //        count_open = count_open / 2;
                //        count_closed = count_closed / 2;

                //        MemoryStream ms = new MemoryStream();
                //        for (int j = 0; j < tmp.Length && tmp[j] != '}'; j += 2) {
                //            while (tmp[j] == '{')
                //                j++;

                //            string hs = tmp.Substring(j, 2);
                //            terminal_sb.Insert(terminal_index, "{" + hs + "}");
                //            terminal_index += 4;

                //            byte b;
                //            bool result = Byte.TryParse(hs, NumberStyles.HexNumber, null, out b);

                //            if (!result) {
                //                progress.Report(new CmdResponse("Bad Hex Value\r\n", Color.Red, true));
                //                return;
                //            }

                //            ms.WriteByte(b);
                //        }
                //        sb.Insert(m.Index, new String('{', count_open) + Encoding.ASCII.GetString(ms.ToArray()) + new String('}', count_closed));
                //        str = sb.ToString();
                //        terminal_sb.Insert(m.Index, new String('{', count_open));
                //        terminal_sb.Insert(terminal_index, new String('}', count_closed));
                //        terminal_str = terminal_sb.ToString();
                //    }
                //}

                //try {
                //	progress.Report(new CmdResponse(terminal_str, Color.Purple, false));
                //	byte[] bs = Encoding.ASCII.GetBytes(str);
                //	await stream.WriteAsync(bs, 0, bs.Length);

                //	if (line_feed) {
                //		byte[] lf = { (byte)'\n' };
                //		await stream.WriteAsync(lf, 0, 1);
                //		progress.Report(new CmdResponse("\n", Color.Purple, false));
                //	}
                //}
                //catch (Exception) {
                //	progress.Report(new CmdResponse("Error: Couldn't write to port. Does it require DTR/CTS?\n", Color.Red, true));
                //}

                ///////////////////////////////////////////
                // New attempt - use memory stream instead.
                List<byte> bls = new List<byte>();
                bls.AddRange(ASCIIEncoding.ASCII.GetBytes(str));
                StringBuilder terminal_sb = new StringBuilder(str);
                rgx = new Regex(@"(?<!\{)\{(\{\{)*(?!\{)[\da-fA-F\s]+(?<!\})\}(\}\})*(?!\})");
                mtches = rgx.Matches(str);
                if (mtches.Count > 0) {
                    //Start at the end so the indexes are maintained as the buffer changes...
                    for (int i = mtches.Count - 1; i >= 0; i--) {
                        Match m = mtches[i];
                        bls.RemoveRange(m.Index, m.Length);
                        terminal_sb.Remove(m.Index, m.Length);
                        int terminal_index = m.Index;
                        /////////////////////////////////////
                        // replace brackets
                        string tmp = m.Value.ToUpper().Replace(" ", "");
                        int count_open = 0;
                        int count_closed = 0;
                        for (int j = 0; j < tmp.Length; j++) {
                            if (tmp[j] == '{') {
                                count_open++;
                            }
                            else if (tmp[j] == '}') {
                                count_closed++;
                            }
                        }
                        count_open = count_open / 2;
                        count_closed = count_closed / 2;

                        MemoryStream ms = new MemoryStream();
                        for (int j = 0; j < tmp.Length && tmp[j] != '}'; j += 2) {
                            while (tmp[j] == '{')
                                j++;

                            string hs = tmp.Substring(j, 2);
                            terminal_sb.Insert(terminal_index, "{" + hs + "}");
                            terminal_index += 4;

                            byte b;
                            bool result = Byte.TryParse(hs, NumberStyles.HexNumber, null, out b);

                            if (!result) {
                                progress.Report(new CmdResponse("Bad Hex Value\r\n", Color.Red, true));
                                return;
                            }

                            ms.WriteByte(b);
                        }

                        //do in reverse, will keep the indexes
                        bls.InsertRange(m.Index, ASCIIEncoding.ASCII.GetBytes(new String('}', count_closed)));
                        bls.InsertRange(m.Index, ms.ToArray());
                        bls.InsertRange(m.Index, ASCIIEncoding.ASCII.GetBytes(new String('{', count_open)));
                        //sb.Insert(m.Index, new String('{', count_open) + Encoding.ASCII.GetString(ms.ToArray()) + new String('}', count_closed));

                        //terminal_sb.Insert(m.Index, new String('}', count_closed));
                        //string str1 = BitConverter.ToString(ms.ToArray());
                        //terminal_sb.Insert(m.Index, str1);
                        //terminal_sb.Insert(m.Index, new String('{', count_open));
                    }
                }

                try {
                    if (line_feed) {
                        bls.Add((byte)'\n');
                        //ms_out.WriteByte((byte)'\n');
                        terminal_sb.Append('\n');
                    }

                    progress.Report(new CmdResponse(terminal_sb.ToString(), Color.Purple, false));
                    byte[] bs = bls.ToArray();
                    await stream.WriteAsync(bs, 0, bs.Length);
                }
                catch (Exception) {
                    progress.Report(new CmdResponse("Error: Couldn't write to port. Does it require DTR/CTS?\n", Color.Red, true));
                }
            }
        }
    }
}
