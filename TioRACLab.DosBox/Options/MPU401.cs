using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// Specifies which type of MIDI Processing Unit to emulate. 
    /// </summary>
    public enum MPU401
    {
        /// <summary>
        /// MIDI is not emulated. 
        /// </summary>
        None,

        /// <summary>
        /// The MPU-401 can work in two modes, normal mode and UART mode. "Normal mode" would provide the host system with an 8-track sequencer, MIDI clock output, SYNC 24 signal output, Tape Sync and a metronome; as a result of these features, it is often called "intelligent mode"
        /// </summary>
        Intelligent,

        /// <summary>
        /// This simply emulates UART mode, which reduces the MPU-401 to just relaying in-/outcoming MIDI data bytes. 
        /// </summary>
        Uart
    }
}
