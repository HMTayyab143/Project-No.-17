using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// Provider for the OPL emulation. compat might provide better quality
    /// </summary>
    public enum OplEmu
    {
        /// <summary>
        /// OPL Emu Default
        /// </summary>
        Default, 

        /// <summary>
        /// OPL Emu Compat
        /// </summary>
        Compat, 

        /// <summary>
        /// OPL Emu Fast
        /// </summary>
        Fast
    }
}
