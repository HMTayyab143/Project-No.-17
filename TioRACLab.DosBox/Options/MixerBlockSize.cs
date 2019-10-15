using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    ///  Mixer block size
    /// </summary>
    public enum MixerBlockSize
    {
        /// <summary>
        /// Block Size 1024
        /// </summary>
        [Description("1024")]
        Block1024,

        /// <summary>
        /// Block Size 2048
        /// </summary>
        [Description("2048")]
        Block2048,

        /// <summary>
        /// Block Size 4096
        /// </summary>
        [Description("4096")]
        Block4096,

        /// <summary>
        /// Block Size 8192
        /// </summary>
        [Description("8192")]
        Block8192,

        /// <summary>
        /// Block Size 512
        /// </summary>
        [Description("512")]
        Block512,

        /// <summary>
        /// Block Size 256
        /// </summary>
        [Description("256")]
        Block256
    }
}
