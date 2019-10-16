using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    public enum MidiDevice
    {
        Default,
        Win32,
        Alsa,
        OSS,
        CoreAudio,
        CoreMidi,
        None
    }
}
