using NUnit.Framework;
using TioRACLab.DosBox.Options;
using System.Collections.Generic;

namespace TioRACLab.DosBoxTest.Options
{
    public class AutoexecOptionsTest
    {
        [Test]
        public void ToStringTest()
        {
            var autoexec = AutoexecOptions.Create()
                .AddCommand("cd war2")
                .AddCommand("war2.exe");

            var iniAutoexec = autoexec.ToString();

            Assert.AreEqual(iniAutoexec, "[autoexec]\r\n\r\ncd war2\r\nwar2.exe\r\n");
        }

        [Test]
        public void LoadDictionaryTest()
        {
            var autoexec = new AutoexecOptions();
            var dictionary = new Dictionary<string, object>()
            {
                {"content", "cd war2\r\nwar2.exe" }
            };

            autoexec.LoadDictionary(dictionary);

            Assert.AreEqual(autoexec.Commands[0].ToString(), "cd war2");
            Assert.AreEqual(autoexec.Commands[1].ToString(), "war2.exe");
        }
    }
}
