using System;
using System.Collections.Generic;
using System.Text;

namespace TioRAC.DosBox.Options
{
    public struct FullResolution
    {
        public FullResolution(uint width, uint height)
        {
            BaseResolution = new Resolution(width, height);
            ResolutionType = null;
        }

        public FullResolution(FullResolutionType type)
        {
            BaseResolution = null;
            ResolutionType = type;
        }

        public FullResolution(string resolution)
        {
            if (resolution?.ToLower() == "original")
            {
                BaseResolution = null;
                ResolutionType = FullResolutionType.Original;
            }
            else if (resolution?.ToLower() == "desktop")
            {
                BaseResolution = null;
                ResolutionType = FullResolutionType.Desktop;
            }
            else
            {
                BaseResolution = new Resolution(resolution);
                ResolutionType = null;
            }
        }

        public Resolution? BaseResolution { get; set; }

        public FullResolutionType? ResolutionType { get; set; }

        public override string ToString()
        {
            if (BaseResolution != null)
                return BaseResolution.ToString();
            else if (ResolutionType != null)
                return Enum.GetName(typeof(FullResolutionType), ResolutionType.Value).ToLower();
            else
                return "";
        }

        public static implicit operator string(FullResolution resolution)
        {
            return resolution.ToString();
        }

        public static explicit operator FullResolution(string resolution)
        {
            return new FullResolution(resolution);
        }

        public static explicit operator Resolution(FullResolution resolution)
        {
            return new Resolution(resolution.ToString());
        }

        public static implicit operator FullResolution(Resolution resolution)
        {
            return new FullResolution(resolution);
        }

        public enum FullResolutionType
        {
            Original,
            Desktop
        }
    }
}
