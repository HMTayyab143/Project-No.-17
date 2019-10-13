using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// The type of machine DOSBox tries to emulate.
    /// </summary>
    public enum DosBoxMachine
    {
        /// <summary>
        /// Refers to a graphics card developed by Hercules Computer Technology 
        /// </summary>
        Hercules,

        /// <summary>
        /// Refers to IBM's first color graphics card
        /// </summary>
        CGA,

        /// <summary>
        /// Refers to the additional graphics modes available on a Tandy 1000 or PCjr
        /// </summary>
        Tandy,

        /// <summary>
        /// Refers not to a graphics mode but an entire system developed by IBM
        /// </summary>
        PCjr,

        /// <summary>
        /// Refers to a graphics card developed by IBM between the CGA and VGA
        /// </summary>
        EGA,

        /// <summary>
        /// IBM's graphics system introduced with the PS/2
        /// </summary>
        VGAOnly,

        /// <summary>
        ///  A loose standard designed to allow graphics modes superior to that of VGA. This option emulates an S3 Trio64
        /// </summary>
        SVGA_S3,

        /// <summary>
        /// Emulates the Tseng Labs ET3000
        /// </summary>
        SVGA_et3000,

        /// <summary>
        /// Emulates the Tseng Labs ET4000
        /// </summary>
        SVGA_et4000,

        /// <summary>
        /// Emulates the Paradise PVGA1A
        /// </summary>
        SVGA_Paradise,

        /// <summary>
        /// The same as svga_s3 introduces a no-line frame buffer hack
        /// </summary>
        Vesa_nolfb,

        /// <summary>
        /// The same as svga_s3, but uses a lower version of VESA (1.3)
        /// </summary>
        Vesa_oldvbe
    }
}
