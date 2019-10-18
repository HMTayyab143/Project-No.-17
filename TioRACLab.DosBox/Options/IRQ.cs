using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    public enum IRQ
    {
        [Description("3")]
        IRQ3,

        [Description("5")]
        IRQ5,

        [Description("7")]
        IRQ7,

        [Description("9")]
        IRQ9,

        [Description("10")]
        IRQ10,

        [Description("11")]
        IRQ11,

        [Description("12")]
        IRQ12,
    }
}
