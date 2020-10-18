using System.Collections.Generic;
using System.IO;

namespace NepitUtils.Encoding.Base32
{
    public static class Base32
    {
        private static Dictionary<Base32Mapping, IMapping> mappings = new Dictionary<Base32Mapping, IMapping>()
        {
            { Base32Mapping.NS6316, new NS6316Base32Mapping() },
            { Base32Mapping.RFC4648, new RFC4648Base32Mapping() },
            { Base32Mapping.Crockford, new CrockfordsBase32Mapping() }
        };

        public static string Encode(this Base32Mapping mapping, byte[] data)
        {
            IMapping map = mappings[mapping];
            int dataIndex = 0;
            int bufferIndex = 0;
            int buffer = 0;
            int mask = 0b11111;
            string result = "";
            while (dataIndex < data.Length)
            {
                for (int i = 0; i < 3 && dataIndex < data.Length; i++)
                {
                    buffer = buffer << 8;
                    buffer += data[dataIndex++];
                    bufferIndex += 8;
                }

                while (bufferIndex >= 5)
                {
                    int offset = bufferIndex - 5;
                    result += map[(buffer & (mask << offset)) >> offset];
                    buffer = buffer & (~(mask << offset));
                    bufferIndex -= 5;
                }
            }
            if (bufferIndex != 0)
            {
                int d = 5 - bufferIndex;
                result += map[(buffer << d) & mask];
            }
            if (map.Padding != null)
            {
                while (result.Length % map.Quantum != 0) result += map.Padding;
            }
            return result;
        }

        public static byte[] Decode(this Base32Mapping mapping, string data)
        {
            IMapping map = mappings[mapping];
            int dataIndex = 0;
            int bufferIndex = 0;
            int buffer = 0;
            int mask = 0b11111111;
            if (map.Padding != null) data = data.Replace(map.Padding, "");
            MemoryStream result = new MemoryStream();
            while (dataIndex < data.Length)
            {
                for (int i = 0; i < 5 && dataIndex < data.Length; i++)
                {
                    buffer = buffer << 5;
                    buffer += map[data.Substring(dataIndex++, 1)];
                    bufferIndex += 5;
                }

                while (bufferIndex >= 8)
                {
                    int offset = bufferIndex - 8;
                    result.WriteByte((byte)((buffer & (mask << offset)) >> offset));
                    buffer = buffer & (~(mask << offset));
                    bufferIndex -= 8;
                }
            }
            return result.ToArray();
        }

        public static string Base32Encode(this byte[] data, Base32Mapping mapping = Base32Mapping.NS6316)
        {
            return mapping.Encode(data);
        }

        public static byte[] Base32Decode(this string data, Base32Mapping mapping = Base32Mapping.NS6316)
        {
            return mapping.Decode(data);
        }
    }
}
