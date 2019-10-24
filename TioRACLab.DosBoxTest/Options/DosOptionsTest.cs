using NUnit.Framework;
using TioRACLab.DosBox.Options;
using System.Collections.Generic;

namespace TioRACLab.DosBoxTest.Options
{
    public class DosOptionsTest
    {
        [Test]
        public void ToStringTest()
        {
            var dos = DosOptions.Create()
                .AddXMS()
                .AddEMS()
                .AddUMB()
                .AddKeyboardLayout(KeyboardLayout.Auto);

            var iniDOS = dos.ToString();

            Assert.AreEqual(iniDOS, "[dos]\r\n\r\nxms=true\r\nems=true\r\numb=true\r\nkeyboardlayout=auto\r\n");
        }

        [Test]
        public void LoadDictionaryTest()
        {
            DosOptions dos = new DosOptions();
            var dictionary = new Dictionary<string, object>()
            {
                {"xms", "true"},
                {"ems", "true"},
                {"umb", "true"},
                {"keyboardlayout", "auto"}
            };

            dos.LoadDictionary(dictionary);

            Assert.IsTrue(dos.XMS);
            Assert.IsTrue(dos.EMS);
            Assert.IsTrue(dos.UMB);
            Assert.AreEqual(dos.KeyboardLayout.ToString(), "auto");
        }
    }
}
