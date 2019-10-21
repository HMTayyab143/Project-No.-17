using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// Device Serial Type
    /// </summary>
    public enum SerialDevice
    {
        /// <summary>
        /// Disabled
        /// </summary>
        Disabled,

        /// <summary>
        /// Dummy
        /// </summary>
        Dummy,

        /// <summary>
        /// Modem
        /// </summary>
        Modem,

        /// <summary>
        /// NullModem
        /// </summary>
        NullModem,

        /// <summary>
        /// DirectSerial
        /// </summary>
        DirectSerial
    }
}
