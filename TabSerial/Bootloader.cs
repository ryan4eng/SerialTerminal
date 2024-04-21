using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialTerminal.SerialTab
{
    class Bootloader
    {
        public bool inOperation;
        private byte[] firmFileContents;
        private int firmIndex;
        public List<byte> CurrentLine;
        private int RetryCount = 0;

        public Bootloader()
        {
            CurrentLine = new List<byte>();
        }

        public bool LoadFile()
        {
            if (File.Exists(Config.Data.SerialFlashHexLocation))
            {
                if (Config.Data.SerialProg_BinaryFormat)
                {
                    firmFileContents = File.ReadAllBytes(Config.Data.SerialFlashHexLocation);
                }
                else
                {
                    StreamReader read = new StreamReader(Config.Data.SerialFlashHexLocation);

                    string lines = read.ReadToEnd();

                    firmFileContents = Encoding.ASCII.GetBytes(lines.Replace("\r\n", ";"));

                }
                
                inOperation = true;
                return true;
            }

            return false;
        }

        public void Clear()
        {
            inOperation = false;
            firmFileContents = null;
            firmIndex = 0;
        }

        public List<byte> GetPreviousLine()
        {
            RetryCount++;

            if (RetryCount > 5)
            {
                RetryCount = 0;
                return null;
            }

            return CurrentLine;
        }

        public List<byte> GetNextLine()
        {
            //clear previous line contents
            CurrentLine.Clear();
            RetryCount = 0;
            bool magicNum = false;

            while (inOperation && firmFileContents != null && (firmIndex != firmFileContents.Length))
            {
                byte num = firmFileContents[firmIndex++];

                if (Config.Data.SerialProg_BinaryFormat)
                {
                    CurrentLine.Add(num);

                    if (magicNum)
                    {
                        magicNum = false;

                        if (num == 0x04)    //end of frame
                        {
                            return CurrentLine;
                        }
                    }
                    else if (num == 0x01)
                    {
                        magicNum = true;
                    }
                }
                else
                {
                    CurrentLine.Add(num);

                    if (num == ';')
                    {
                        return CurrentLine;
                    }
                }
            }

            if (firmIndex == firmFileContents.Length)
            {
                inOperation = false;
            }

            return null;
        }
    }
}
