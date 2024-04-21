using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialTerminal.UtilTab {
	class Util {
		public delegate void IMEITBDelegate(string data);
		public static event IMEITBDelegate SetIMEI_TB;

		public delegate void SimNumDelegate(string data);
		public static event SimNumDelegate SimNum_Info;

		//IMEI crc calculated using Luhm algorithm
		public void GetImeiCrc_Click(object sender, EventArgs e, string str) {
			//example:
			//str = "3549200301";

			int sum1 = 0;
			int sum2 = 0;

			for (int i = 0; i < str.Length; i++) {
				int num = str[i] - '0';
				if ((num < 10) && (num >= 0)) {
					if (i % 2 > 0) {
						int tmp = num * 2;
						sum2 += tmp % 10 + tmp / 10;
					}
					else {
						sum1 += num;
					}
				}
			}
			sum1 = 10 - (sum1 + sum2) % 10;

			if (sum1 == 10) {
				sum1 = 0;
			}

			str += sum1.ToString();

			if (SetIMEI_TB != null) {
				SetIMEI_TB(str);
			}
			Clipboard.SetText(str);
		}

		public void CheckSimNum(string sim_num) {
			//89 61 01 46614609000029
			if (sim_num.Substring(0, 2) != "89" || sim_num.Length < 19) {
				if (SimNum_Info != null) {
					SimNum_Info("Bad Sim Num: " + sim_num);
					return;
				}
			}

			string country_code = sim_num.Substring(2, 2);
			ISO3166Country cc = ISO3166.FromDialCode(country_code);

			StringBuilder details = new StringBuilder("89 - Start characters\n");
			if (cc != null)
				details.Append(country_code + " - Country: " + cc.Name + "\n");
			else
				details.Append(country_code + " - Country: Unknown\n");

			Dictionary<string, string> australianIssuerIdList = new Dictionary<string, string>();
			australianIssuerIdList.Add("00", "Telstra");
			australianIssuerIdList.Add("01", "Telstra");
			australianIssuerIdList.Add("02", "Optus (Sigtel)");
			australianIssuerIdList.Add("03", "Vodafone");
			australianIssuerIdList.Add("06", "Vodafone");
			australianIssuerIdList.Add("12", "Optus (Sigtel)");
			australianIssuerIdList.Add("14", "AAPT Ltd (TPG?)");
			australianIssuerIdList.Add("21", "Optus (Sigtel)");
			australianIssuerIdList.Add("23", "Optus (Sigtel)");
			australianIssuerIdList.Add("50", "Pivotel");
			australianIssuerIdList.Add("61", "Telstra");
			australianIssuerIdList.Add("62", "Telstra");
			australianIssuerIdList.Add("88", "Pivotel");

			string issuer_id = sim_num.Substring(4, 2);
			string issuer_str = "unknown";

			if (australianIssuerIdList.ContainsKey(issuer_id)) {
				issuer_str = australianIssuerIdList[issuer_id];
			}

			details.Append(issuer_id + " - " + issuer_str + " - Issuer ID\n");
			details.Append(sim_num.Substring(6, 12) + " - Sim Num (Account ID)\n");
			details.Append(sim_num.Substring(18, 1) + " - CRC using Luhn algorithm\n");

			if (sim_num.Length == 20) {
				details.Append(sim_num.Substring(19, 1) + " - Extra byte");
			}

			if (SimNum_Info != null) {
				SimNum_Info(details.ToString());
			}
		}

		public void CalcAsciiCrc(string entry, TextBox ans) {
			int crc = 0;

			foreach (char b in entry) {
				crc += (int)b;
			}

			crc = crc & 0xFF;
			byte bCrc = (byte)((~crc) + 1);

			string output = entry + bCrc.ToString("X2");
			ans.Text = output;
			Clipboard.SetText(output);
		}

		public void CalcHexAsciiCrc(string entry, TextBox ans) {
			string hex_string = entry.Replace(" ", "");

			if (hex_string.Length % 2 != 0) {
				ans.Text = "Bad Hex Length\r\n";
				return;
			}

			int crc = 0;
			//byte[] byteArray = new byte[byteLength];
			for (int i = 0; i < hex_string.Length; i += 2) {
				string hs = hex_string.Substring(i, 2);
				byte b;
				if (!Byte.TryParse(hs, NumberStyles.HexNumber, null, out b)) {
					ans.Text = "Bad Hex Value\r\n";
					return;
				}

				crc += b;
			}

			crc = crc & 0xFF;
			byte bCrc = (byte)((~crc) + 1);

			string output = entry + " " + bCrc.ToString("X2");
			ans.Text = output;
			//Clipboard.SetText(output);
		}
	}
}
