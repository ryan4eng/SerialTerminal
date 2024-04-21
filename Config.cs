using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerialInterface
{
    public partial class SerialForm
    {
        public const string fileloc = @"config.xml";
        static public void SerializeToXML(XMLInterface xmlobj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XMLInterface));
            TextWriter textWriter = new StreamWriter(fileloc);
            serializer.Serialize(textWriter, xmlobj);
            textWriter.Close();
        }

        static XMLInterface DeserializeFromXML()
        {
            if (!File.Exists(fileloc))
            {
                return null;
            }
            XMLInterface xmlObj;
            // Constructs an instance of the XmlSerializer with the type
            // of object that is being de-serialized.
            XmlSerializer deserializer = new XmlSerializer(typeof(XMLInterface));
            // To read the file, creates a FileStream.
            FileStream myFileStream = new FileStream(fileloc, FileMode.Open);
            // Calls the Deserialize method and casts to the object type.
            xmlObj = (XMLInterface)deserializer.Deserialize(myFileStream);
            myFileStream.Close();

            return xmlObj;
        }
    }
    public class XMLInterface
    {
        public bool AdvancedSettings
        { get; set; }

        public int BaudRate
        { get; set; }

        public int ComPort
        { get; set; }

        public int DataBits
        { get; set; }

        public int Parity
        { get; set; }

        public int StopBits
        { get; set; }

        public String LogLocation
        { get; set; }

        public string[] SerialTextBox   //text entries for quick sending of data
        { get; set; }

        public string TestFirmwareHexLocation
        { get; set; }
    }
}
