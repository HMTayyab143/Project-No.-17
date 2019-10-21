using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// The Sound Blaster is widely considered the most popular audio device standard. In the DOS era of games, it came in several editions.
    /// </summary>
    public enum SoundBlaster
    {
        /// <summary>
        /// Sound Blaster Emulation disabled
        /// </summary>
        None,

        /// <summary>
        /// Emulation Sound Blaster 1.0 
        /// </summary>
        [Description("sb1")]
        SoundBlaster1,

        /// <summary>
        /// Emulation Sound Blaster 2.0 
        /// </summary>
        [Description("sb2")]
        SoundBlaster2,

        /// <summary>
        /// Emulation Sound Blaster Pro 1.0 
        /// </summary>
        [Description("sbpro1")]
        SoundBlasterPro1,

        /// <summary>
        /// Emulation Sound Blaster Pro 2.0
        /// </summary>
        [Description("sbpro2")]
        SoundBlasterPro2,

        /// <summary>
        /// Emulation Sound Blaster 16
        /// </summary>
        [Description("sb16")]
        SoundBlaster16,

        /// <summary>
        /// Emulation GameBlaster
        /// </summary>
        [Description("gb")]
        Gameblaster
    }
}
