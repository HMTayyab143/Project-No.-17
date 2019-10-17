using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// <para>IPX Options for DosBox</para>
    /// <para>See more in <a href="https://www.dosbox.com/wiki/Configuration:IPX">IPX Configuriotn SDL</a> Wiki page</para>
    /// </summary>
    public class IPXOptions : BaseOptions
    {
        #region "Constructions"

        /// <summary>
        /// Create instance of IPX options class
        /// </summary>
        public IPXOptions()
            : base("ipx")
        {

        }

        #endregion "Constructions"

        #region "Fields"

        private bool? _ipx;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// Enable IPX.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? IPX
        {
            get
            {
                return _ipx;
            }
            set
            {
                _ipx = value;
                OnPropertyChanged("IPX");
            }
        }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create a new IPX Options for DosBox configuration
        /// </summary>
        /// <returns>DosBox IPX configuration to add another configuration</returns>
        public static IPXOptions Create()
        {
            return new IPXOptions();
        }

        /// <summary>
        /// Enable IPX.
        /// </summary>
        /// <param name="ipx">Enable IPX.</param>
        /// <returns>DosBox IPX configuration to add another configuration</returns>
        public IPXOptions AddIPX(bool? ipx = false)
        {
            IPX = ipx;
            return this;
        }

        #endregion "Fluent"

        #region "String"

        /// <summary>
        /// Cast IPX options to string
        /// </summary>
        /// <returns>String in INI format</returns>
        public override string ToString()
        {
            var options = new StringBuilder(base.ToString());

            options.CreateIniLine("ipx", IPX);

            return options.ToString();
        }

        #endregion "String"

        #region "BaseOptions"

        /// <summary>
        /// Load IPX options values from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary with options IPX data</param>
        public override void LoadDictionary(IDictionary<string, object> dictionary)
        {
            foreach (var data in dictionary)
            {
                switch (data.Key)
                {
                    case "ipx":
                        IPX = SimpleIniParse.GetBool(data.Value);
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion "BaseOptions"
    }
}
