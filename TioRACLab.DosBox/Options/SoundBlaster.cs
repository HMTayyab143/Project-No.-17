using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    public enum SoundBlaster
    {
        None,

        [Description("sb1")]
        SoundBlaster1,

        [Description("sb2")]
        SoundBlaster2,

        [Description("sbpro1")]
        SoundBlasterPro1,

        [Description("sbpro2")]
        SoundBlasterPro2,

        [Description("sb16")]
        SoundBlaster16,

        [Description("gb")]
        Gameblaster
    }
}
