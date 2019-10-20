using NUnit.Framework;
using System.Collections.Generic;
using TioRACLab.DosBox.Options;

namespace TioRACLab.DosBoxTest.Options
{
    public class GusOptionsTest
    {
        [Test]
        public void ToStringTest()
        {
            var gus = GusOptions.Create()
                .AddGUS()
                .AddGusRate()
                .AddGusBase()
                .AddGusIRQ()
                .AddGusDMA()
                .AddUltraDir();

            var iniGus = gus.ToString();

            Assert.AreEqual(iniGus, "[gus]\r\n\r\ngus=false\r\ngusrate=44100\r\ngusbase=240\r\ngusirq=5\r\ngusdma=3\r\nultradir=C:\\ULTRASND\r\n");
        }

        [Test]
        public void LoadDictionaryTest()
        {
            var gus = new GusOptions();
            var dictionary = new Dictionary<string, object>()
            {
                {"gus", "false"},
                {"gusrate", "44100"},
                {"gusbase", "240"},
                {"gusirq", "5"},
                {"gusdma", "3"},
                {"ultradir", @"C:\ULTRASND"}
            };

            gus.LoadDictionary(dictionary);

            Assert.IsFalse(gus.GUS);
            Assert.AreEqual(gus.GusRate, SampleRate.Rate44100);
            Assert.AreEqual(gus.GusBase, IOAddress.Port240);
            Assert.AreEqual(gus.GusIRQ, IRQ.IRQ5);
            Assert.AreEqual(gus.GusDMA, DMA.DMA3);
            Assert.AreEqual(gus.UltraDir, @"C:\ULTRASND");
        }
    }
}
