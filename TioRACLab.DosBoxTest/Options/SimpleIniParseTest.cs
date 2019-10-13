using NUnit.Framework;
using System.Collections.Generic;
using TioRACLab.DosBox.Options;

namespace TioRACLab.DosBoxTest.Options
{
    public class SimpleIniParseTest
    {
        [Test]
        public void ReadIniOptionsTest()
        {
            var iniText = "[sdl]\n" +
                    "# Comment..\n" +
                    "# Comment..\n" +
                    "            \n" +
                    "fullscreen =true\n" +
                    "fulldouble=true   \n" +
                    "fullresolution=desktop\n" +
                    "windowresolution= 640x480\n" +
                    "output=opengl\n" +
                    "autolock=true\n" +
                    "sensitivity=100\n" +
                    "waitonerror=true\n" +
                    "priority=higher, normal\n" +
                    "mapperfile=mapper-0.74-3.map\n" +
                    "usescancodes=true\n" +
                    "\n" +
                    "\n" +
                    "[autoexec]\n" +
                    "\n" +
                    "mount c c:\\\n" +
                    "mount d d:\\\n" +
                    "exit";

            var result = SimpleIniParse.ReadIniOptions(iniText);

            Assert.IsTrue(result.ContainsKey("sdl"));
            Assert.IsTrue(result.ContainsKey("autoexec"));

            Assert.IsTrue(result["sdl"] is Dictionary<string, object>);
            Assert.IsTrue(result["autoexec"] is Dictionary<string, object>);

            var sdl = result["sdl"] as Dictionary<string, object>;

            Assert.AreEqual(sdl["fullscreen"], "true");
            Assert.AreEqual(sdl["fulldouble"], "true");
            Assert.AreEqual(sdl["fullresolution"], "desktop");
            Assert.AreEqual(sdl["windowresolution"], "640x480");
            Assert.AreEqual(sdl["output"], "opengl");
            Assert.AreEqual(sdl["autolock"], "true");
            Assert.AreEqual(sdl["sensitivity"], "100");
            Assert.AreEqual(sdl["waitonerror"], "true");
            Assert.AreEqual(sdl["mapperfile"], "mapper-0.74-3.map");
            Assert.AreEqual(sdl["usescancodes"], "true");

            Assert.IsTrue(sdl.ContainsKey("priority"));
            Assert.IsTrue(sdl["priority"] is List<string>);

            var priority = sdl["priority"] as List<string>;
            Assert.Contains("higher", priority);
            Assert.Contains("normal", priority);

            var autoexec = result["autoexec"] as Dictionary<string, object>;
            Assert.IsTrue(autoexec.ContainsKey("content"));
        }

        [Test]
        public void GetEnumTest()
        {
            var normal2x = SimpleIniParse.GetEnum<ScalerType>("normal2x");
            var twoxSai = SimpleIniParse.GetEnum<ScalerType>("2xsai");

            Assert.AreEqual(normal2x, ScalerType.Normal2x);
            Assert.AreEqual(twoxSai, ScalerType.TwoxSai);
        }
    }
}
