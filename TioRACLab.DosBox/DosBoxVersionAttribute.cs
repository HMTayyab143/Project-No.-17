using System;

namespace TioRACLab.DosBox
{
    /// <summary>
    /// Informs if parameter or setting is supported by DosBox Application version (future use)
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DosBoxVersionAttribute : Attribute
    {
        /// <summary>
        /// Create attribute with information of minimum and maximun version supported
        /// </summary>
        /// <param name="minVersion">Minimum version supported</param>
        /// <param name="maxVersion">Maximum version supported</param>
        public DosBoxVersionAttribute(string minVersion, string maxVersion = null)
        {
            MinVersion = new Version(minVersion);

            if (!string.IsNullOrWhiteSpace(maxVersion))
                MaxVersion = new Version(maxVersion);
        }

        /// <summary>
        /// Create attribute with information of minimum and maximun version supported
        /// </summary>
        /// <param name="minVersion">Minimum version supported</param>
        /// <param name="maxVersion">Maximum version supported</param>
        public DosBoxVersionAttribute(Version minVersion, Version maxVersion = null)
        {
            MinVersion = minVersion;
            MaxVersion = maxVersion;
        }

        /// <summary>
        /// Minimum DosBox application version supported
        /// </summary>
        public DosBoxVersion MinVersion { get; protected set; }

        /// <summary>
        /// Maximum DosBox application version supported
        /// </summary>
        public DosBoxVersion MaxVersion { get; protected set; }
    }
}