using System.Collections.Generic;

namespace NepitUtils.Encoding.Base32
{
    internal class NS6316Base32Mapping : IMapping
    {
        private static string[] WordToChar = new string[] {
            "0", "1", "2", "3", "4", "5", "6", "7",
            "8", "9", "A", "B", "C", "D", "E", "F",
            "G", "H", "J", "K", "M", "N", "P", "Q",
            "R", "S", "T", "V", "W", "X", "Y", "Z"
        };

        private static Dictionary<string, byte> CharToWord = new Dictionary<string, byte> {
            { "0", 0 },  { "o", 0 },  { "O", 0 },  { "1", 1 },  { "I", 1 },  { "i", 1 },  { "L", 1 },  { "l", 1 },
            { "2", 2 },  { "3", 3 },  { "4", 4 },  { "5", 5 },  { "6", 6 },  { "7", 7 },  { "8", 8 },  { "9", 9 },
            { "A", 10 }, { "a", 10 }, { "B", 11 }, { "b", 11 }, { "C", 12 }, { "c", 12 }, { "D", 13 }, { "d", 13 },
            { "E", 14 }, { "e", 14 }, { "F", 15 }, { "f", 15 }, { "G", 16 }, { "g", 16 }, { "H", 17 }, { "h", 17 },
            { "J", 18 }, { "j", 18 }, { "K", 19 }, { "k", 19 }, { "M", 20 }, { "m", 20 }, { "N", 21 }, { "n", 21 },
            { "P", 22 }, { "p", 22 }, { "Q", 23 }, { "q", 23 }, { "R", 24 }, { "r", 24 }, { "S", 25 }, { "s", 25 },
            { "T", 26 }, { "t", 26 }, { "V", 27 }, { "v", 27 }, { "U", 27 }, { "u", 27 }, { "W", 28 }, { "w", 28 },
            { "X", 29 }, { "x", 29 }, { "Y", 30 }, { "y", 30 }, { "Z", 31 }, { "z", 31 },
        };

        public string this[int val] => WordToChar[val];
        public int this[string val] => CharToWord[val];
        public int Quantum => 0;
        public string Padding => null;
    }
}
