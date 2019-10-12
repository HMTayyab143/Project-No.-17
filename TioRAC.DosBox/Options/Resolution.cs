﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TioRAC.DosBox.Options
{
    /// <summary>
    /// Resolution dosbox will run. <a href="https://www.dosbox.com/wiki/Configuration:SDL">SDL</a> options.
    /// </summary>
    public struct Resolution
    {
        #region "Constructions"

        /// <summary>
        /// Create resolution options
        /// </summary>
        /// <param name="width">Width size</param>
        /// <param name="height">Height size</param>
        public Resolution(uint width, uint height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Create resolution from string
        /// </summary>
        /// <exception cref="NotSupportedException">Resolution string is badly formatted</exception>
        /// <param name="resolution">Resolution string, example 800x600</param>
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

        #endregion "Constructions"

        #region "Properties"

        /// <summary>
        /// Width size
        /// </summary>
        public uint Width { get; set; }

        /// <summary>
        /// Height size
        /// </summary>
        public uint Height { get; set; }

        #endregion "Properties"

        #region "String Casts"

        /// <summary>
        /// Cast resolution to string
        /// </summary>
        /// <returns>String of resolution, example 800x600</returns>
        public override string ToString()
        {
            if (Width == 0 || Height == 0)
                return "";

            return $"{Width}x{Height}";
        }

        /// <summary>
        /// Implicit cast from Resolution to string
        /// </summary>
        /// <param name="resolution">Resolution struct</param>
        public static implicit operator string(Resolution resolution)
        {
            return resolution.ToString();
        }

        /// <summary>
        /// Explicit cast from string to Resolution struct
        /// </summary>
        /// <exception cref="NotSupportedException">Resolution string is badly formatted</exception>
        /// <param name="resolution">Resolution string</param>
        public static explicit operator Resolution(string resolution)
        {
            return new Resolution(resolution);
        }

        #endregion "String Casts"

        #region "Resolutions"

        /// <summary>
        /// <para>Resolution from CGA format: 320x200.</para>
        /// <para>See <a href="https://en.wikipedia.org/wiki/Graphics_display_resolution">Wikipedia Graphics Display Resolution</a> article.</para>
        /// </summary>
        public static Resolution CGA => new Resolution(320, 200);

        /// <summary>
        /// <para>Resolution from WVGA format: 800x400.</para>
        /// <para>See <a href="https://en.wikipedia.org/wiki/Graphics_display_resolution">Wikipedia Graphics Display Resolution</a> article.</para>
        /// </summary>
        public static Resolution WVGA => new Resolution(800, 480);

        /// <summary>
        /// <para>Resolution from FWVGA format: 854x480.</para>
        /// <para>See <a href="https://en.wikipedia.org/wiki/Graphics_display_resolution">Wikipedia Graphics Display Resolution</a> article.</para>
        /// </summary>
        public static Resolution FWVGA => new Resolution(854, 480);

        /// <summary>
        /// <para>Resolution from WSVGA format: 1024x600.</para>
        /// <para>See <a href="https://en.wikipedia.org/wiki/Graphics_display_resolution">Wikipedia Graphics Display Resolution</a> article.</para>
        /// </summary>
        public static Resolution WSVGA => new Resolution(1024, 600);

        /// <summary>
        /// <para>Resolution from QVGA format: 320x240.</para>
        /// <para>See <a href="https://en.wikipedia.org/wiki/Graphics_display_resolution">Wikipedia Graphics Display Resolution</a> article.</para>
        /// </summary>
        public static Resolution QVGA => new Resolution(320, 240);

        /// <summary>
        /// <para>Resolution from VGA format: 640x480.</para>
        /// <para>See <a href="https://en.wikipedia.org/wiki/Graphics_display_resolution">Wikipedia Graphics Display Resolution</a> article.</para>
        /// </summary>
        public static Resolution VGA => new Resolution(640, 480);

        /// <summary>
        /// <para>Resolution from PAL format: 768x576.</para>
        /// <para>See <a href="https://en.wikipedia.org/wiki/Graphics_display_resolution">Wikipedia Graphics Display Resolution</a> article.</para>
        /// </summary>
        public static Resolution PAL => new Resolution(768, 576);

        /// <summary>
        /// <para>Resolution from SVGA format: 800x600.</para>
        /// <para>See <a href="https://en.wikipedia.org/wiki/Graphics_display_resolution">Wikipedia Graphics Display Resolution</a> article.</para>
        /// </summary>
        public static Resolution SVGA => new Resolution(800, 600);

        /// <summary>
        /// <para>Resolution from XGA format: 1024x768.</para>
        /// <para>See <a href="https://en.wikipedia.org/wiki/Graphics_display_resolution">Wikipedia Graphics Display Resolution</a> article.</para>
        /// </summary>
        public static Resolution XGA => new Resolution(1024, 768);

        #endregion "Resolutions"
    }
}
