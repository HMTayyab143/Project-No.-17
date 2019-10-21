using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// Type of OPL emulation. On 'auto' the mode is determined by sblaster type. All OPL modes are Adlib-compatible, except for 'cms'.
    /// </summary>
    public enum OplMode
    {
        /// <summary>
        /// OPL Disabled
        /// </summary>
        None,

        /// <summary>
        /// OPL Auto
        /// </summary>
        Auto, 

        /// <summary>
        /// OPL CMD
        /// </summary>
        CMD, 

        /// <summary>
        /// OPL 2
        /// </summary>
        OPL2, 

        /// <summary>
        /// Dual OPL 2
        /// </summary>
        DualOPL2, 

        /// <summary>
        /// OPL 3
        /// </summary>
        OPL3
    }
}
