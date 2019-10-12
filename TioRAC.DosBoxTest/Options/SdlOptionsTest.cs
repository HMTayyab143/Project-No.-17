using NUnit.Framework;
using System;
using System.Collections.Generic;
using TioRAC.DosBox.Options;

namespace TioRAC.DosBoxTest.Options
{
    public class SdlOptionsTest
    {
        [Test]
        public void ToStringTest()
        {
            var sdl=SdlOptions.Create()
                .AddAutoLock()
                .AddFullDouble()
                .AddFullResolution(Resolution.Desktop)
                .AddFullScreen()
                .AddMapperFile("mapper-0.74-3.map")
                .AddOutput(VideoOutput.OpenGL)
                .AddPriorityFocused()
                .AddPriorityMinimized()
                .AddSensitivity()
                .AddUseScanCodes()
                .AddWaitOnError()
                .AddWindowResolution(Resolution.VGA);

            var iniSDL=sdl.ToString();

            Assert.AreEqual(iniSDL, "[sdl]\r\n\r\nfullscreen=true\r\nfulldouble=true\r\nfullresolution=desktop\r\nwindowresolution=640x480\r\n"
                + "output=opengl\r\nautolock=true\r\nsensitivity=100\r\nwaitonerror=true\r\npriority=higher,normal\r\n"
                + "mapperfile=mapper-0.74-3.map\r\nusescancodes=true\r\n");
        }

        [Test]
        public void LoadDictionaryTest()
        {
            var sdl = new SdlOptions();
            var dictionary = new Dictionary<string, object>()
            {
                {"fullscreen", "true"},
                {"fulldouble", "true"},
                {"fullresolution", "desktop"},
                {"windowresolution", "640x480"},
                {"output", "opengl"},
                {"autolock", "true"},
                {"sensitivity", "100"},
                {"waitonerror", "true"},
                {"priority", new List<string>() { "higher", "normal"}},
                {"mapperfile", "mapper-0.74-3.map"},
                {"usescancodes", "true"}
            };

            sdl.LoadDictionary(dictionary);

            Assert.IsTrue(sdl.FullScreen);
            Assert.IsTrue(sdl.FullDouble);
            Assert.AreEqual(sdl.FullResolution, Resolution.Desktop);
            Assert.AreEqual(sdl.WindowResolution, Resolution.VGA);
            Assert.AreEqual(sdl.Output, VideoOutput.OpenGL);
            Assert.IsTrue(sdl.AutoLock);
            Assert.AreEqual(sdl.Sensitivity, 100);
            Assert.IsTrue(sdl.WaitOnError);
            Assert.AreEqual(sdl.PriorityFocused, PriorityLevel.Higher);
            Assert.AreEqual(sdl.PriorityMinimized, PriorityLevel.Normal);
            Assert.AreEqual(sdl.MapperFile, "mapper-0.74-3.map");
            Assert.IsTrue(sdl.UseScanCodes);
        }
    }
}
