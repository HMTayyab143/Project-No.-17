using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TioRAC.DosBox;

namespace TioRAC.DosBoxTest
{
    public class DosBoxVersionAttributeTest
    {
        [Test]
        public void SetAttributeTest()
        {
            var dosboxAttribute = new DosBoxVersionAttribute("0.74", "0.75");
            Assert.AreEqual(dosboxAttribute.MinVersion.Version, "0.74");
            Assert.AreEqual(dosboxAttribute.MaxVersion.Version, "0.75");

            dosboxAttribute = new DosBoxVersionAttribute(new Version("0.76"), new Version("0.75"));
            Assert.AreEqual(dosboxAttribute.MinVersion.Version, "0.76");
            Assert.AreEqual(dosboxAttribute.MaxVersion.Version, "0.75");
        }
    }
}
