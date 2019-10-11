
namespace TioRAC.DosBox
{
    /// <summary>
    /// DosBox version (future use)
    /// </summary>
    public struct DosBoxVersion
    {
        #region "Constructions"

        /// <summary>
        /// Create a version fo the DosBox Application
        /// </summary>
        /// <param name="version">Version application</param>
        private DosBoxVersion(string version)
        {
            Version = version;
        }

        #endregion "Constructions"

        #region "Properties"

        /// <summary>
        /// DosBox version string
        /// </summary>
        public string Version { get; private set; }

        #endregion "Properties"

        #region "Versions"

        /// <summary>
        /// Version from Official DosBox 0.74
        /// </summary>
        public const string Official0_74 = "0.74";

        #endregion "Versions"

        #region "Casts"

        /// <summary>
        /// Return version as string
        /// </summary>
        /// <returns>String of version</returns>
        public override string ToString()
        {
            return this.Version;
        }

        /// <summary>
        /// Cast DosBoxVersion struct to string
        /// </summary>
        /// <param name="version">DosBoxVersion for cast</param>
        public static explicit operator string(DosBoxVersion version)
        {
            return version.Version;
        }

        /// <summary>
        /// Cast string to DosBoxVersion struct
        /// </summary>
        /// <param name="version">string to cast</param>
        public static implicit operator DosBoxVersion(string version)
        {
            return new DosBoxVersion(version);
        }

        /// <summary>
        /// Cast DosBoxVersion struct to Version class
        /// </summary>
        /// <param name="version">DosBoxVersion for cast</param>
        public static implicit operator System.Version(DosBoxVersion version)
        {
            return new System.Version(version.Version);
        }

        /// <summary>
        /// Cast Version class to DosBoxVersion struct
        /// </summary>
        /// <param name="version">Version class to cast</param>
        public static implicit operator DosBoxVersion(System.Version version)
        {
            return new DosBoxVersion(version.ToString());
        }

        #endregion "Casts"
    }
}
