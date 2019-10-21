using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// A slightly confusing config name, because this isn't so much which MIDI device to use as which MIDI interface to use.
    /// </summary>
    public enum MidiDevice
    {
        /// <summary>
        /// The default system MIDI playback device is used. 
        /// </summary>
        Default,

        /// <summary>
        /// Win32 MIDI playback interface is used. 
        /// </summary>
        Win32,

        /// <summary>
        /// Linux's Advanced Linux Sound Architecture playback interface is used.
        /// </summary>
        Alsa,

        /// <summary>
        /// Linux's Open Sound System playback interface is used.
        /// </summary>
        OSS,

        /// <summary>
        /// MacOS X's framework to render the music through the built-in OS X synthesizer. 
        /// </summary>
        CoreAudio,

        /// <summary>
        /// MacOS X's framework to route MIDI commands to any device that has been configured in Audio MIDI Setup. 
        /// </summary>
        CoreMidi,

        /// <summary>
        /// MIDI is disabled.
        /// </summary>
        None
    }
}
