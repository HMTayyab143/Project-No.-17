using NUnit.Framework;
using TioRACLab.DosBox.Options;
using System.Collections.Generic;

namespace TioRACLab.DosBoxTest.Options
{
    public class DosBoxConfigurationTest
    {
        [Test]
        public void ToStringTest()
        {
            var dosbox = new DosBoxConfiguration();
            var dosboxConfig = dosbox.ToString();

            Assert.AreEqual(dosboxConfig, "[sdl]\r\n\r\n\r\n[dosbox]\r\n\r\n\r\n[render]\r\n\r\n\r\n[cpu]\r\n\r\n\r\n[mixer]\r\n\r\n\r\n[midi]\r\n\r\n\r\n[sblaster]\r\n\r\n\r\n[gus]\r\n\r\n\r\n[speaker]\r\n\r\n\r\n[joystick]\r\n\r\n\r\n[serial]\r\n\r\n\r\n[dos]\r\n\r\n\r\n[ipx]\r\n\r\n\r\n[autoexec]\r\n\r\n");
        }

        /*[Test]
        public void OtherTest()
        {
            var dosbox = DosBoxConfiguration.LoadFromFile(@"C:\Users\tiorac\AppData\Local\DOSBox\dosbox-0.74-3.conf");
            dosbox.SaveAsFile(@"c:\teste\dosbox1.conf", true);
        }*/
    }
}
