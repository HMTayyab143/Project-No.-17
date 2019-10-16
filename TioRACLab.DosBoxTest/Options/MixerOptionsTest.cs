using NUnit.Framework;
using System;
using System.Collections.Generic;
using TioRACLab.DosBox.Options;

namespace TioRACLab.DosBoxTest.Options
{
    public class MixerOptionsTest
    {
        [Test]
        public void ToStringTest()
        {
            var mixer = MixerOptions.Create()
                .AddNoSound()
                .AddRate()
                .AddBlockSize()
                .AddPreBuffer();

            var iniMixer = mixer.ToString();

            Assert.AreEqual(iniMixer, "[mixer]\r\n\r\nnosound=false\r\nrate=44100\r\nblocksize=1024\r\nprebuffer=25\r\n");
        }

        [Test]
        public void LoadDictionaryTest()
        {
            var mixer = new MixerOptions();
            var dictionary = new Dictionary<string, object>()
            {
                {"nosound", "false"},
                {"rate", "44100"},
                {"blocksize", "1024"},
                {"prebuffer", "25"}
            };

            mixer.LoadDictionary(dictionary);

            Assert.IsFalse(mixer.NoSound);
            Assert.AreEqual(mixer.Rate, SampleRate.Rate44100);
            Assert.AreEqual(mixer.BlockSize, MixerBlockSize.Block1024);
            Assert.AreEqual(mixer.PreBuffer, 25);
        }
    }
}
