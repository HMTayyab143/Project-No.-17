using NUnit.Framework;
using System.Collections.Generic;
using TioRACLab.DosBox.Options;

namespace TioRACLab.DosBoxTest.Options
{
    public class SoundBlasterTest
    {
        [Test]
        public void ToStringTest()
        {
            var sblaster = SoundBlasterOptions.Create()
                .AddSBType()
                .AddSBBase()
                .AddIRQ()
                .AddDMA()
                .AddHDMA()
                .AddSoundMixer()
                .AddOplMode()
                .AddOplEmu()
                .AddOplRate();

            var iniSblaster = sblaster.ToString();

            Assert.AreEqual(iniSblaster, "[sblaster]\r\n\r\nsbtype=sb16\r\nsbbase=220\r\nirq=7\r\ndma=1\r\nhdma=5\r\nsbmixer=true\r\noplmode=auto\r\noplemu=default\r\noplrate=44100\r\n");
        }

        [Test]
        public void LoadDictionaryTest()
        {
            var sblaster = new SoundBlasterOptions();
            var dictionary = new Dictionary<string, object>()
            {
                {"sbtype", "sb16"},
                {"sbbase", "220"},
                {"irq", "7"},
                {"dma", "1"},
                {"hdma", "5"},
                {"sbmixer", "true"},
                {"oplmode", "auto"},
                {"oplemu", "default"},
                {"oplrate", "44100"},
            };

            sblaster.LoadDictionary(dictionary);

            
            Assert.AreEqual(sblaster.SBType, SoundBlaster.SoundBlaster16);
            Assert.AreEqual(sblaster.SBBase, IOAddress.Address220);
            Assert.AreEqual(sblaster.IRQ, IRQ.IRQ7);
            Assert.AreEqual(sblaster.DMA, DMA.DMA1);
            Assert.AreEqual(sblaster.HDMA, DMA.DMA5);
            Assert.IsTrue(sblaster.SBMixer);
            Assert.AreEqual(sblaster.OplMode, OplMode.Auto);
            Assert.AreEqual(sblaster.OplEmu, OplEmu.Default);
            Assert.AreEqual(sblaster.OplRate, SampleRate.Rate44100);
        }
    }
}
