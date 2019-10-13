using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TioRACLab.DosBox;

namespace TioRACLab.DosBoxTest
{
    public class DosBoxVersionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StringCastTest()
        {
            DosBoxVersion version = DosBoxVersion.Official0_74;
            Assert.AreEqual(version.ToString(), "0.74");
            Assert.AreEqual(version.Version, "0.74");
            Assert.AreEqual((string)version, "0.74");
        }

        [Test]
        public void VersionCastTest()
        {
            var version = new Version("0.74");

            DosBoxVersion versionDosBox = version;
            Assert.AreEqual(versionDosBox.ToString(), "0.74");
            Assert.AreEqual(versionDosBox.Version, "0.74");
            Assert.AreEqual((string)versionDosBox, "0.74");
            Assert.AreEqual(versionDosBox.Version, version.ToString());
        }
    }
}
