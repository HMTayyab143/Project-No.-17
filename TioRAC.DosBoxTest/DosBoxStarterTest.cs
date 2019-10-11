using TioRAC.DosBox;
using NUnit.Framework;


namespace TioRAC.DosBoxTest
{
    public class DosBoxStarterTest
    {
        [Test]
        public void AAA()
        {
            var dosboxProcess = DosBoxStarter.FromProcess("dosbox.exe")
                .SetParameters(a => a.AddExit().AddFullscreen())
                .Start();


        }
    }
}
