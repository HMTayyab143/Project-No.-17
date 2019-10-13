using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    public enum CPUType
    {
        Auto, 

        [Description("386")]
        CPU386,

        [Description("386_slow")]
        Slow386,

        [Description("486_slow")]
        Slow486,

        [Description("pentium_slow")]
        SlowPentium,

        [Description("386_prefetch")]
        Prefetch386
    }
}
