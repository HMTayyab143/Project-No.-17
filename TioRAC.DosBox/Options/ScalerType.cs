using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRAC.DosBox.Options
{
    /// <summary>
    /// Scaler used to enlarge/enhance low resolution modes.
    /// </summary>
    public enum ScalerType
    {
        /// <summary>
        /// No scaling is performed.
        /// </summary>
        None,

        /// <summary>
        /// Nearest-neighbour scaling (big square pixels) - 2x
        /// </summary>
        Normal2x,

        /// <summary>
        /// Nearest-neighbour scaling (big square pixels) - 3x
        /// </summary>
        Normal3x,

        /// <summary>
        /// Smooths corners and removes jaggies from diagonal lines -2x
        /// </summary>
        AdvMame2x,

        /// <summary>
        /// Smooths corners and removes jaggies from diagonal lines -3x
        /// </summary>
        AdvMame3x,

        /// <summary>
        /// Identical to 'advmame' - 2x
        /// </summary>
        AdvInterp2x,

        /// <summary>
        /// Identical to 'advmame' - 3x
        /// </summary>
        AdvInterp3x,

        /// <summary>
        /// A 'high quality' scaler which delivers a cleaner and sharper image than 'advmame' or 'sai' scalers - 2x
        /// </summary>
        HQ2x,

        /// <summary>
        /// A 'high quality' scaler which delivers a cleaner and sharper image than 'advmame' or 'sai' scalers - 3x
        /// </summary>
        HQ3x,

        /// <summary>
        /// Similar to 'advmame' but with much softer color gradients and edges. 
        /// </summary>
        [Description("2xsai")]
        TwoxSai,

        /// <summary>
        /// Similar to 'sai' but sharper
        /// </summary>
        Super2xSai, 

        /// <summary>
        /// SuperEagle
        /// </summary>
        SuperEagle,

        /// <summary>
        /// Like 'scan', but with darkened versions of the data instead of black lines - 2x
        /// </summary>
        TV2x,

        /// <summary>
        /// Like 'scan', but with darkened versions of the data instead of black lines - 3x
        /// </summary>
        TV3x,

        /// <summary>
        /// Simulates the phosphors on a dot trio CRT - 2x
        /// </summary>
        RGB2x,

        /// <summary>
        /// Simulates the phosphors on a dot trio CRT - 3x
        /// </summary>
        RGB3x,

        /// <summary>
        /// Like 'normal', but with horizontal black lines - 2x
        /// </summary>
        Scan2x,

        /// <summary>
        /// Like 'normal', but with horizontal black lines - 3x
        /// </summary>
        Scan3x
    }
}
