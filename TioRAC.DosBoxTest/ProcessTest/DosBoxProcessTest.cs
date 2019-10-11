using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TioRAC.DosBox;

namespace TioRAC.DosBoxTest.ProcessTest
{
    public class DosBoxProcessTest
    {
        [Test]
        public void Bla()
        {
            var p = new DosBoxProcess("ping.exe");
            p.Start();
            p.WaitEndDosBox();

        }
    }
}
