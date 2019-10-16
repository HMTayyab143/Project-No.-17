using NUnit.Framework;
using TioRACLab.DosBox.Options;
using System.Collections.Generic;

namespace TioRACLab.DosBoxTest.Options
{
    public class MidiOptionsTest
    {
        [Test]
        public void ToStringTest()
        {
            var midi = MidiOptions.Create()
                .AddMPU401()
                .AddMidiDevice()
                .AddMidiConfig("midicfg");

            var iniMidi = midi.ToString();

            Assert.AreEqual(iniMidi, "[midi]\r\n\r\nmpu401=intelligent\r\nmididevice=default\r\nmidiconfig=midicfg\r\n");
        }

        [Test]
        public void LoadDictionaryTest()
        {
            var midi = new MidiOptions();
            var dictionary = new Dictionary<string, object>()
            {
                {"mpu401", "uart"},
                {"mididevice", "win32"},
                {"midiconfig", "midicfg"}
            };

            midi.LoadDictionary(dictionary);

            Assert.AreEqual(midi.MPU401, MPU401.Uart);
            Assert.AreEqual(midi.MidiDevice, MidiDevice.Win32);
            Assert.AreEqual(midi.MidiConfig, "midicfg");
        }
    }
}
