using System;
using System.Collections.Generic;
using System.Text;

namespace TioRAC.DosBox.Options
{
    public struct Resolution
    {
        public Resolution(uint width, uint height)
        {
            Width = width;
            Height = height;
        }

        public Resolution(string resolution)
        {
            if (resolution == null)
                throw new NullReferenceException("Resolution argument is not a resolution. Example:\"800x600\"");

            var parts = resolution.Trim().Split('x');

            if (parts.Length < 2 || parts.Length > 3)
                throw new NotSupportedException("String is not a resolution. Example:\"800x600\"");

            if (!UInt32.TryParse(parts[0], out uint size))
                throw new NotSupportedException("String is not a resolution. Example:\"800x600\"");

            Width = size;
            if (!UInt32.TryParse(parts[1], out size))
                throw new NotSupportedException("String is not a resolution. Example:\"800x600\"");

            Height = size;
        }

        public uint Width { get; set; }

        public uint Height { get; set; }

        public override string ToString()
        {
            if (Width == 0 || Height == 0)
                return "";

            return $"{Width}x{Height}";
        }

        public static implicit operator string(Resolution resolution)
        {
            return resolution.ToString();
        }

        public static explicit operator Resolution(string resolution)
        {
            return new Resolution(resolution);
        }
        

        public static Resolution CGA => new Resolution(320, 200);

        public static Resolution WVGA => new Resolution(800, 480);

        public static Resolution FWVGA => new Resolution(854, 480);

        public static Resolution WSVGA => new Resolution(854, 480);

        public static Resolution QVGA => new Resolution(320, 240);

        public static Resolution VGA => new Resolution(640, 480);
        
        public static Resolution PAL => new Resolution(768, 576);

        public static Resolution SVGA => new Resolution(800, 600);

        public static Resolution XGA => new Resolution(1024, 768);
    }
}
