using NUnit.Framework;
using System;
using TioRACLab.DosBox.Options;

namespace TioRACLab.DosBoxTest.Options
{
    public class ResolutionTest
    {
        [Test]
        public void ToStringTest()
        {
            var resolution = new Resolution(1024, 768);
            Assert.AreEqual((string)resolution, "1024x768");

            resolution = Resolution.SVGA;
            Assert.AreEqual(resolution.ToString(), "800x600");

            resolution = new Resolution(Resolution.ResolutionType.Desktop);
            Assert.AreEqual(resolution.ToString(), "desktop");
        }

        [Test]
        public void ConstructionsTest()
        {
            var resolution = new Resolution("640x480");
            Assert.AreEqual(resolution.ToString(), "640x480");
            Assert.AreEqual(resolution.Width, 640);
            Assert.AreEqual(resolution.Height, 480);

            resolution = new Resolution("1024x768x32");
            Assert.AreEqual(resolution.ToString(), "1024x768");

            Assert.Catch(() => new Resolution(null));
            Assert.Catch(() => new Resolution("Error"));
            Assert.Catch(() => new Resolution("1024x768x32x64"));
        }
    }
}
