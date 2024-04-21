using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SerialTerminal.ProgTab
{
    class ChipConfig
    {
        private const string fileLoc = @"chip_config.xml";
        public List<string> DeviceList = new List<string>();
        public bool configLoaded = false;

        public ChipConfig()
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(fileLoc);
            }
            catch
            {
                //file more than likely doesn't exist...
                return;
            }

            configLoaded = true;

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                DeviceList.Add(node["ProductName"].InnerText);
            }
        }
    }
}
