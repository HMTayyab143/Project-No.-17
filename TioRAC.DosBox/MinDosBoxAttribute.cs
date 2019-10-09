using System;

namespace TioRAC.DosBox
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MinDosBoxAttribute : Attribute
    {
        public MinDosBoxAttribute(string version)
        {
            this.Version = version;
        }

        public string Version { get; protected set; }
    }
}
