using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialTerminal
{
    public class GLOBAL
    {
        public const int BUTTON_SERIAL = 0;
        public const int BUTTON_TCP = 1;
        //public const int COM_CLOSE = 0, COM_OPEN = 1, COM_TOGGLE = 2;

        //0: None
        //1: Special Characters only
        //2: Special and New line
        //3. All Characters
        public const int HEX_LEVEL_NONE = 0;
        public const int HEX_LEVEL_NORMAL = 1;
        public const int HEX_LEVEL_ALL_EXCEPT_NL = 2;
        public const int HEX_LEVEL_ALL = 3;

        public const int CRC_TYPE_NONE = 0;
        public const int CRC_TYPE_OLD = 1;
        public const int CRC_TYPE_EXTENDED = 2;
    }
}
