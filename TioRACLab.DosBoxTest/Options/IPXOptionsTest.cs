using NUnit.Framework;
using TioRACLab.DosBox.Options;
using System.Collections.Generic;

namespace TioRACLab.DosBoxTest.Options
{
    public class IPXOptionsTest
    {
        [Test]
        public void ToStringTest()
        {
            var ipx = IPXOptions.Create()
                .AddIPX();

            var iniIPX = ipx.ToString();

            Assert.AreEqual(iniIPX, "[ipx]\r\n\r\nipx=false\r\n");
        }

        [Test]
        public void LoadDictionaryTest()
        {
            IPXOptions ipx = new IPXOptions();
            var dictionary = new Dictionary<string, object>()
            {
                {"ipx", "true"}
            };

            ipx.LoadDictionary(dictionary);

            Assert.IsTrue(ipx.IPX);
        }
    }
}
