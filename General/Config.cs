using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerialTerminal
{
    class Config
    {
        public const string fileloc = @"config.xml";
        static public XMLInterface Data = new XMLInterface();

        static public void SerializeToXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XMLInterface));
            TextWriter textWriter = new StreamWriter(fileloc);
            serializer.Serialize(textWriter, Data);
            textWriter.Close();
        }

        public static int DeserializeFromXML()
        {
            if (!File.Exists(fileloc))
            {
                return 1;
            }
            
            // Constructs an instance of the XmlSerializer with the type
            // of object that is being de-serialized.
            XmlSerializer deserializer = new XmlSerializer(typeof(XMLInterface));

            // To read the file, creates a FileStream.
            FileStream myFileStream = new FileStream(fileloc, FileMode.Open);

            // Calls the Deserialize method and casts to the object type.
            Data = (XMLInterface)deserializer.Deserialize(myFileStream);
            myFileStream.Close();

            return 0;
        }
    }

    public class XMLInterface
    {
		#region General
		public bool AdvancedSettings
        { get; set; }
		#endregion

		#region Serial Port
		//index of baud rate from the list
		public string BaudRate
        { get; set; }

        //index
        public string ComPort
        { get; set; }

        //index
        public string DataBits
        { get; set; }

        //index
        //public int Parity
        public string Parity
        { get; set; }

        //index
        //public int StopBits
        public string StopBits
        { get; set; }

        public string Serial_LogDirectory
        { get; set; }

        //text in the quick send boxes for the Serial Form.
        public string[] SerialTextBox
        { get; set; }

		//text in the quick send boxes for the Serial Form.
		public bool[] SerialHexCB
		{ get; set; }

		//text in the quick send boxes for the Serial Form.
		public bool[] SerialLFCB { get; set; }

		public int Serial_DisplayLevel { get; set; }

		//Test firmware location for options
		public string SerialFlashHexLocation { get; set; }

		//whether app will programmed in binary framing or ascii hex framing
		public bool SerialProg_BinaryFormat { get; set; }

		#endregion

		#region TCP Client
		public string TcpClientIPAddr { get; set; }
		public string TcpClientPort { get; set; }

		//directory to log data to when a tcp connection is open
		public string TcpClient_LogDirectory { get; set; }

		//the format that text will appear in the tcp tab. binary, text, non-ascii only etc.
		public int TcpClient_DisplayLevel { get; set; }

		//text in the quick send boxes for the Serial Form.
		public string[] TcpClientTextBox { get; set; }

		//text in the quick send boxes for the Serial Form.
		public bool[] TcpClientHexCB { get; set; }

		//text in the quick send boxes for the Serial Form.
		public bool[] TcpClientLFCB { get; set; }
		#endregion

		#region TCP Server
		public string TcpSvrPort { get; set; }

		//directory to log data to when a tcp connection is open
		public string TcpSvr_LogDirectory { get; set; }

		//the format that text will appear in the tcp tab. binary, text, non-ascii only etc.
		public int TcpSvr_DisplayLevel { get; set; }

		//text in the quick send boxes for the Serial Form.
		public string[] TcpSvrTextBox { get; set; }

		//text in the quick send boxes for the Serial Form.
		public bool[] TcpSvrHexCB { get; set; }

		//text in the quick send boxes for the Serial Form.
		public bool[] TcpSvrLFCB { get; set; }
		#endregion

		#region Programmer
		public string Prog_Firmware_SPI
        { get; set; }
		#endregion
	}
}
