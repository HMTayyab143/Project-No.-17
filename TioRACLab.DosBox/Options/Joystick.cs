using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// Type of joystick
    /// </summary>
    public enum Joystick
    {
        /// <summary>
        /// Disables joystick emulation
        /// </summary>
        None,

        /// <summary>
        /// Supports two joysticks
        /// </summary>
        [Description("2axis")]
        TwoAxis,

        /// <summary>
        /// Supports one joystick, first joystick used
        /// </summary>
        [Description("4axis")]
        FourAxis,

        /// <summary>
        /// Supports one joystick, second joystick used
        /// </summary>
        [Description("4axis_2")]
        FourAxis2,

        /// <summary>
        /// Thrustmaster
        /// </summary>
        [Description("fcs")]
        Thrustmaster,

        /// <summary>
        /// CH Flightstick
        /// </summary>
        [Description("ch")]
        CHFlightstick,

        /// <summary>
        /// Chooses emulation depending on real joystick(s)
        /// </summary>
        Auto
    }
}
