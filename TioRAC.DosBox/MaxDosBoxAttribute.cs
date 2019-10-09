using System;

namespace TioRAC.DosBox
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MaxDosBoxAttribute : Attribute
    {
        public MaxDosBoxAttribute(string version)
        {
            this.Version = version;
        }

        public string Version { get; protected set; }
    }
}
