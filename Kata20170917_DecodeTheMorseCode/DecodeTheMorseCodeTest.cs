using System;
using System.Collections.Generic;
using System.Linq;
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

        [TestMethod]
        public void Test_input_AB()
        {
            MorseCodeDecoderShouldBe("AB", ".- -...");
        }

        [TestMethod]
        public void Test_input_ABC()
        {
            MorseCodeDecoderShouldBe("ABC", ".- -... -.-.");
        }

        [TestMethod]
        public void Test_input_ABC_A()
        {
            MorseCodeDecoderShouldBe("ABC A", ".- -... -.-.   .-");
        }

        [TestMethod]
        public void Test_input_HEY_JUDE()
        {
            MorseCodeDecoderShouldBe("HEY JUDE", ".... . -.--   .--- ..- -.. .");
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
        private static readonly Dictionary<string, string> MorseCode = new Dictionary<string, string>
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

        public string Decode(string morseCode)
        {
            var morseCodeWords = morseCode.Split(new []{ "   " }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", morseCodeWords.Select(DecodeWord));
        }

        public static string DecodeWord(string word)
        {
            var chars = word.Split(' ');
            return string.Concat(chars.Select(c => MorseCode[c]));
        }
    }
}
