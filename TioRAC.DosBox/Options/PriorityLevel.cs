using System;
using System.Collections.Generic;
using System.Text;

namespace TioRAC.DosBox.Options
{
    /// <summary>
    ///  Priority level for DosBox in <a href="https://www.dosbox.com/wiki/Dosbox.conf#.5Bsdl.5D">SDL</a> options
    /// </summary>
    public enum PriorityLevel
    {
        /// <summary>
        /// Pause DosBox, only when minimized
        /// </summary>
        Pause = 0,

        /// <summary>
        /// Lowest priority
        /// </summary>
        Lowest,

        /// <summary>
        /// Lower priority
        /// </summary>
        Lower,

        /// <summary>
        /// Normal priority
        /// </summary>
        Normal,

        /// <summary>
        /// Higher priority
        /// </summary>
        Higher,

        /// <summary>
        /// Highest priority
        /// </summary>
        Highest, 
    }
}
