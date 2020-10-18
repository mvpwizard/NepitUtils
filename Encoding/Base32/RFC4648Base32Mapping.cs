using System.Collections.Generic;

namespace NepitUtils.Encoding.Base32
{
    internal class RFC4648Base32Mapping : IMapping
    {
        private static string[] WordToChar = new string[] {
            "A", "B", "C", "D", "E", "F", "G", "H",
            "I", "J", "K", "L", "M", "N", "O", "P",
            "Q", "R", "S", "T", "U", "V", "W", "X",
            "Y", "Z", "2", "3", "4", "5", "6", "7"
        };

        private static Dictionary<string, byte> CharToWord = new Dictionary<string, byte> {
        { "A", 0 },  { "B", 1 },  { "C", 2 },  { "D", 3 },
        { "E", 4 },  { "F", 5 },  { "G", 6 },  { "H", 7 },
        { "I", 8 },  { "J", 9 },  { "K", 10 }, { "L", 11 },
        { "M", 12 }, { "N", 13 }, { "O", 14 }, { "P", 15 },
        { "Q", 16 }, { "R", 17 }, { "S", 18 }, { "T", 19 },
        { "U", 20 }, { "V", 21 }, { "W", 22 }, { "X", 23 },
        { "Y", 24 }, { "Z", 25 }, { "2", 26 }, { "3", 27 },
        { "4", 28 }, { "5", 29 }, { "6", 30 }, { "7", 31 },
    };

        public string this[int val] => WordToChar[val];
        public int this[string val] => CharToWord[val];
        public int Quantum => 8;
        public string Padding => "=";
    }
}

