using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// CPU core used in emulation
    /// </summary>
    public enum CPUCore
    {
        /// <summary>
        /// Real-mode programs are run with the normal core. For protected mode programs it switches to dynamic core, if available. 
        /// </summary>
        Auto,

        /// <summary>
        /// The program instructions are, in blocks, translated to host processor instructions that execute directly. See also [1]. In the most cases this approach is more efficent than interpretation, except for programs that employ massive self-modifying code. This option is not present on all host platforms. 
        /// </summary>
        Dynamic,

        /// <summary>
        /// The program is interpreted instruction by instruction. This approach is a lot more CPU demanding than dynamic core but allows for a more fine-grained time emulation and is needed on platforms for which DOSBox doesn't have a dynamic core. 
        /// </summary>
        Normal,

        /// <summary>
        /// Basically the same as normal, but optimized for real-mode (older) games. In case a protected-mode game is started, it automatically switches back to normal core. 
        /// </summary>
        Simple
    }
}
