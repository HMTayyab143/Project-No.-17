using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    public enum DMA
    {
        [Description("0")]
        DMA0,

        [Description("1")]
        DMA1,

        [Description("3")]
        DMA3,

        [Description("5")]
        DMA5,

        [Description("6")]
        DMA6,

        [Description("7")]
        DMA7,
    }
}
