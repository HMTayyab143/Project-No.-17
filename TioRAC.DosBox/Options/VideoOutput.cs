using System;
using System.Collections.Generic;
using System.Text;

namespace TioRAC.DosBox.Options
{
    /// <summary>
    /// Output options in <a href="https://www.dosbox.com/wiki/Dosbox.conf#.5Bsdl.5D">SDL</a> options
    /// </summary>
    public enum VideoOutput
    {
        /// <summary>
        /// Output surface
        /// </summary>
        Surface,

        /// <summary>
        /// Output overlay
        /// </summary>
        Overlay,

        /// <summary>
        /// Output OpenGL
        /// </summary>
        OpenGL,

        /// <summary>
        /// Output OpenGLln
        /// </summary>
        OpenGLnb,

        /// <summary>
        /// Output DirectDraw
        /// </summary>
        DDraw
    }
}
