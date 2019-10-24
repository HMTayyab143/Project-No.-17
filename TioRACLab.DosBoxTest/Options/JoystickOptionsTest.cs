using NUnit.Framework;
using TioRACLab.DosBox.Options;
using System.Collections.Generic;

namespace TioRACLab.DosBoxTest.Options
{
    public class JoystickOptionsTest
    {
        [Test]
        public void ToStringTest()
        {
            var joystick = JoystickOptions.Create()
                .AddJoystickType()
                .AddTimed()
                .AddAutoFire()
                .AddSwap34()
                .AddButtonWrap();

            var iniJoystick = joystick.ToString();

            Assert.AreEqual(iniJoystick, "[joystick]\r\n\r\njoysticktype=auto\r\ntimed=true\r\nautofire=false\r\nswap34=false\r\nbuttonwrap=false\r\n");
        }

        [Test]
        public void LoadDictionaryTest()
        {
            JoystickOptions joystick = new JoystickOptions();
            var dictionary = new Dictionary<string, object>()
            {
                {"joysticktype", "auto"},
                {"timed", "true"},
                {"autofire", "false"},
                {"swap34", "false"},
                {"buttonwrap", "false"}
            };

            joystick.LoadDictionary(dictionary);

            Assert.AreEqual(joystick.JoystickType, Joystick.Auto);
            Assert.IsTrue(joystick.Timed);
            Assert.IsFalse(joystick.AutoFire);
            Assert.IsFalse(joystick.Swap34);
            Assert.IsFalse(joystick.ButtonWrap);
        }
    }
}
