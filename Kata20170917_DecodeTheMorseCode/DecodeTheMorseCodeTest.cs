using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata20170917_DecodeTheMorseCode
{
    [TestClass]
    public class DecodeTheMorseCodeTest
    {
        [TestMethod]
        public void Test_input_A()
        {
            MorseCodeDecoderShouldBe("A", ".-");
        }

        private static void MorseCodeDecoderShouldBe(string expected, string morseCode)
        {
            var morseCodeDecoder = new MorseCodeDecoder();
            var actual = morseCodeDecoder.Decode(morseCode);
            Assert.AreEqual(expected, actual);
        }
    }

    public class MorseCodeDecoder
    {
        private readonly Dictionary<string, string> MorseCode;

        public MorseCodeDecoder()
        {
            MorseCode = new Dictionary<string, string>
            {
                {".-", "A"}, {"-...", "B"},{ "-.-.", "C"}, {"-..", "D"}, {".", "E"},
                {"..-.", "F" }, {"--.", "G"}, {"....", "H"}, {"..", "I"}, {".---", "J"},
                {"-.-", "K" }, {".-..", "L"}, {"--", "M"}, {"-.", "N"}, {"---", "O"},
                {".--.", "P" }, {"--.-", "Q"}, {".-.", "R"}, {"...", "S"}, {"-", "T"},
                {"..-", "U" }, {"...-", "V"}, {".--", "W"}, {"-..-", "X"}, {"-.--", "Y"},
                {"--..", "Z" }, {"-----", "0"}, {".----", "1"}, {"..---", "2"}, {"...--", "3"},
                {"....-", "4" }, {".....", "5"}, {"-....", "6"}, {"--...", "7"}, {"---..", "8"},
                {"----.", "9" }
            };
        }

        public string Decode(string morseCode)
        {
            return MorseCode[morseCode];
        }
    }
}
