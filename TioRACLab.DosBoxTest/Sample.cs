using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TioRACLab.DosBox;

namespace TioRACLab.DosBoxTest
{
    class Sample
    {
        public void SimpleRequest()
        {
            DosBoxStarter.FromProcess(@"c:\dosbox\dosbox.exe").Start();
        }

        public void SimpleRequestParameters()
        {
            DosBoxStarter.FromProcess(@"c:\dosbox\dosbox.exe")
                .WithParameters(p => p.AddName(@"c:\war2")
                                      .AddFullscreen()
                                      .AddExit())
                .Start();
        }

        public void SimpleRequestWithConfig()
        {
            DosBoxStarter.FromProcess(@"c:\dosbox\dosbox.exe")
                .WithParameters(p => p.AddName(@"c:\war2")
                                      .AddFullscreen()
                                      .AddExit())
                .WithIPXOptions(i => i.AddIPX(true))
                .WithAutoexecOptions(a => a.AddCommand("ipxnet startserver")
                                           .AddCommand("war2.exe"))
                .Start();
        }
    }
}
