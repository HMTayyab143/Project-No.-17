using NUnit.Framework;
using TioRAC.DosBox.Options;
using System.Collections.Generic;

namespace TioRAC.DosBoxTest.Options
{
    public class DosBoxOptionsTest
    {
        [Test]
        public void ToStringTest()
        {
            var dosbox = DosBoxOptions.Create()
                .AddCaptures()
                .AddLanguage("pt-br.lang")
                .AddMachine()
                .AddMemSize();

            var iniDosBox = dosbox.ToString();

            Assert.AreEqual(iniDosBox, "[dosbox]\r\n\r\nlanguage=pt-br.lang\r\nmachine=svga_s3\r\ncaptures=capture\r\nmemsize=16\r\n");
        }

        [Test]
        public void LoadDictionaryTest()
        {
            var dosbox = new DosBoxOptions();
            var dictionary = new Dictionary<string, object>()
            {
                {"language", "pt-br.lang"},
                {"machine", "svga_s3"},
                {"captures", "capture"},
                {"memsize", "16"}
            };

            dosbox.LoadDictionary(dictionary);

            Assert.AreEqual(dosbox.Language, "pt-br.lang");
            Assert.AreEqual(dosbox.Machine, DosBoxMachine.SVGA_S3);
            Assert.AreEqual(dosbox.Captures, "capture");
            Assert.AreEqual(dosbox.MemSize, 16);
        }
    }
}
