using Microsoft.VisualStudio.TestTools.UnitTesting;
using NepitUtils.Encoding.Base32;
using System;

namespace EncodingTests
{
    [TestClass]
    public class Base32Tests
    {
        private static byte[] AllSymbolsBinary = { 
            0x00, 0x44, 0x32, 0x14, 0xc7, 0x42, 0x54, 0xb6, 0x35, 0xcf,
            0x84, 0x65, 0x3a, 0x56, 0xd7, 0xc6, 0x75, 0xbe, 0x77, 0xdf, 0x00
        };
        private static string AllSymbolsNS6316 = "0123456789ABCDEFGHJKMNPQRSTVWXYZ00";
        private static string AllSymbolsNS6316WithError = "Ol23456789aBCDEFgHJKMNPQRSTUWXYZ00";
        private static string AllSymbolsCrockfords = "0123456789ABCDEFGHJKMNPQRSTVWXYZ00";
        private static string AllSymbolsCrockfordsWithError = "Ol23456789aBCDEFgHJKMNPQRSTVWXYZ00";
        private static string AllSymbolsRFC4648 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567AA======";

        [TestMethod]
        public void NS6316Encode()
        {
            Assert.AreEqual(AllSymbolsBinary.Base32Encode(Base32Mapping.NS6316), AllSymbolsNS6316);
        }

        [TestMethod]
        public void NS6316Decode()
        {
            Assert.AreEqual(Convert.ToBase64String(AllSymbolsNS6316.Base32Decode(Base32Mapping.NS6316)), Convert.ToBase64String(AllSymbolsBinary));
        }

        [TestMethod]
        public void NS6316DecodeTranscriptionError()
        {
            Assert.AreEqual(Convert.ToBase64String(AllSymbolsNS6316WithError.Base32Decode(Base32Mapping.NS6316)), Convert.ToBase64String(AllSymbolsBinary));
        }

        [TestMethod]
        public void CrockfordsEncode()
        {
            Assert.AreEqual(AllSymbolsBinary.Base32Encode(Base32Mapping.Crockford), AllSymbolsCrockfords);
        }

        [TestMethod]
        public void CrockfordsDecode()
        {
            Assert.AreEqual(Convert.ToBase64String(AllSymbolsCrockfords.Base32Decode(Base32Mapping.Crockford)), Convert.ToBase64String(AllSymbolsBinary));
        }

        [TestMethod]
        public void CrockfordsDecodeTranscriptionError()
        {
            Assert.AreEqual(Convert.ToBase64String(AllSymbolsCrockfordsWithError.Base32Decode(Base32Mapping.Crockford)), Convert.ToBase64String(AllSymbolsBinary));
        }

        [TestMethod]
        public void RFC4648Encode()
        {
            Assert.AreEqual(AllSymbolsBinary.Base32Encode(Base32Mapping.RFC4648), AllSymbolsRFC4648);
        }

        [TestMethod]
        public void RFC4648Decode()
        {
            Assert.AreEqual(Convert.ToBase64String(AllSymbolsRFC4648.Base32Decode(Base32Mapping.RFC4648)), Convert.ToBase64String(AllSymbolsBinary));
        }

        [TestMethod]
        public void ConsistentDefaultMapping()
        {
            Assert.AreEqual(Convert.ToBase64String(AllSymbolsBinary.Base32Encode().Base32Decode()), Convert.ToBase64String(AllSymbolsBinary));
        }

        [TestMethod]
        public void ExtensionMethodsOnNS6316()
        {
            Assert.AreEqual(Convert.ToBase64String(Base32Mapping.NS6316.Decode(Base32Mapping.NS6316.Encode(AllSymbolsBinary))), Convert.ToBase64String(AllSymbolsBinary));
        }
    }
}
