using NUnit.Framework;
using System;
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

    }
}
