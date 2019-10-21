using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    ///  Input/Output base address is the first address of a range of consecutive read/write addresses that a device uses on the x86's IO bus.
    /// </summary>
    public enum IOAddress
    {
        /// <summary>
        /// Address 220 - Default Sound Card IO
        /// </summary>
        [Description("220")]
        Address220,

        /// <summary>
        /// Address 240
        /// </summary>
        [Description("240")]
        Address240,

        /// <summary>
        /// Address 260
        /// </summary>
        [Description("260")]
        Address260,

        /// <summary>
        /// Address 280
        /// </summary>
        [Description("280")]
        Address280,

        /// <summary>
        /// Address 2A0
        /// </summary>
        [Description("2a0")]
        Address2A0,

        /// <summary>
        /// Address 2C0
        /// </summary>
        [Description("2c0")]
        Address2C0,

        /// <summary>
        /// Address 2E0
        /// </summary>
        [Description("2e0")]
        Address2E0,

        /// <summary>
        /// Address 300 - Default NIC Card
        /// </summary>
        [Description("300")]
        Address300
    }
}
