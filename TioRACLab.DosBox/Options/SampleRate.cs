using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// Mixer sample rate
    /// </summary>
    public enum SampleRate
    {
        /// <summary>
        /// Mixer sample rate 8000
        /// </summary>
        [Description("8000")]
        Rate8000,

        /// <summary>
        /// Mixer sample rate 11025
        /// </summary>
        [Description("11025")]
        Rate11025,

        /// <summary>
        /// Mixer sample rate 16000
        /// </summary>
        [Description("16000")]
        Rate16000,

        /// <summary>
        /// Mixer sample rate 22050
        /// </summary>
        [Description("22050")]
        Rate22050,

        /// <summary>
        /// Mixer sample rate 32000
        /// </summary>
        [Description("32000")]
        Rate32000,

        /// <summary>
        /// Mixer sample rate 44100
        /// </summary>
        [Description("44100")]
        Rate44100,

        /// <summary>
        /// Mixer sample rate 48000
        /// </summary>
        [Description("48000")]
        Rate48000,

        /// <summary>
        /// Mixer sample rate 49716
        /// </summary>
        [Description("49716")]
        Rate49716
    }
}
