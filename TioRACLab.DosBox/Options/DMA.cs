using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// Direct memory access (DMA) is a feature of computer systems that allows certain hardware subsystems to access main system memory (random-access memory), independent of the central processing unit (CPU). 
    /// </summary>
    public enum DMA
    {
        /// <summary>
        /// DMA 0
        /// </summary>
        [Description("0")]
        DMA0,

        /// <summary>
        /// DMA 1
        /// </summary>
        [Description("1")]
        DMA1,

        /// <summary>
        /// DMA 3
        /// </summary>
        [Description("3")]
        DMA3,

        /// <summary>
        /// DMA 5
        /// </summary>
        [Description("5")]
        DMA5,

        /// <summary>
        /// DMA 6
        /// </summary>
        [Description("6")]
        DMA6,

        /// <summary>
        /// DMA7
        /// </summary>
        [Description("7")]
        DMA7,
    }
}
