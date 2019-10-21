using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// An interrupt request (or IRQ) is a hardware signal sent to the processor that temporarily stops a running program and allows a special program
    /// </summary>
    public enum IRQ
    {
        /// <summary>
        /// IRQ 3
        /// </summary>
        [Description("3")]
        IRQ3,

        /// <summary>
        /// IRQ 5
        /// </summary>
        [Description("5")]
        IRQ5,

        /// <summary>
        /// IRQ 7
        /// </summary>
        [Description("7")]
        IRQ7,

        /// <summary>
        /// IRQ 9
        /// </summary>
        [Description("9")]
        IRQ9,

        /// <summary>
        /// IRQ 10
        /// </summary>
        [Description("10")]
        IRQ10,

        /// <summary>
        /// IRQ 11
        /// </summary>
        [Description("11")]
        IRQ11,

        /// <summary>
        /// IRQ 12
        /// </summary>
        [Description("12")]
        IRQ12,
    }
}
