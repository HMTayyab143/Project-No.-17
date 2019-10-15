using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// CPU Type used in emulation
    /// </summary>
    public enum CPUType
    {
        /// <summary>
        /// Auto is the fastest choice
        /// </summary>
        Auto, 

        /// <summary>
        /// 386 CPU type
        /// </summary>
        [Description("386")]
        CPU386,

        /// <summary>
        /// Slow 386 CPU Type
        /// </summary>
        [Description("386_slow")]
        Slow386,

        /// <summary>
        /// Slow 486 CPU Type
        /// </summary>
        [Description("486_slow")]
        Slow486,

        /// <summary>
        /// Slow Pentium CPU Type
        /// </summary>
        [Description("pentium_slow")]
        SlowPentium,

        /// <summary>
        /// Prefetch 386 CPU Type
        /// </summary>
        [Description("386_prefetch")]
        Prefetch386
    }
}
