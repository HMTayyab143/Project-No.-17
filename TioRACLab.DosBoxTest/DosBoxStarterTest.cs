using TioRACLab.DosBox;
using NUnit.Framework;


namespace TioRACLab.DosBoxTest
{
    public class DosBoxStarterTest
    {
        [Test]
        public void Sample()
        {
            var dosboxProcess = DosBoxStarter.FromProcess("dosbox.exe")
                .SetParameters(a => a.AddExit().AddFullscreen());
        }
    }
}
