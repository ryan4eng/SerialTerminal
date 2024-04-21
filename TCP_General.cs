using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SerialInterface
{
    public partial class SerialForm
    {
        private void tcpOpen_Click(object sender, EventArgs e)
        {
            tcpOpen.Text = "Close";

            IPAddress ipAddress = IPAddress.Parse("tr.carbontrack.com.au");
            using (TcpClient client = new TcpClient())
            {
                //client.Connect(ipAddress, 380);
                client.Connect("tr.carbontrack.com.au", 380);
                TCPlog.Text = "Connected...";

            }
        }

        private void SendTCPMessage(string msg)
        {
            // writer.Write(msg);

            AppendTextBox(TCPlog, msg, Color.Black);
        }

        private void sendTCPButton1_Click(object sender, EventArgs e)
        {
            SendTCPMessage(textTCP1.Text);
        }
    }
}
