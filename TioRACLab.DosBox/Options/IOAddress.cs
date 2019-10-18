using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    public enum IOAddress
    {
        [Description("220")]
        Port220,

        [Description("240")]
        Port240,

        [Description("260")]
        Port260,

        [Description("280")]
        Port280,

        [Description("2a0")]
        Port2A0,

        [Description("2c0")]
        Port2C0,

        [Description("2e0")]
        Port2E0,

        [Description("300")]
        Port300
    }
}
