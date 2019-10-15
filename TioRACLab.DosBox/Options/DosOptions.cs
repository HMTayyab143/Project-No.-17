using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// <para>DOS Options for DosBox</para>
    /// <para>See more in <a href="https://www.dosbox.com/wiki/Configuration:DOS">DOS Configuriotn SDL</a> Wiki page</para>
    /// </summary>
    public class DosOptions : BaseOptions
    {
        #region "Constructions"

        /// <summary>
        /// Create instance of DOS options class
        /// </summary>
        public DosOptions()
            : base("dos")
        {

        }

        #endregion "Constructions"

        #region "Fields"

        private bool? _xms;
        private bool? _ems;
        private bool? _umb;
        private KeyboardLayout? _keyboardLayout;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// Enable xms memory.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? XMS
        {
            get
            {
                return _xms;
            }
            set
            {
                _xms = value;
                OnPropertyChanged("XMS");
            }
        }

        /// <summary>
        /// Enable ems memory.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? EMS
        {
            get
            {
                return _ems;
            }
            set
            {
                _ems = value;
                OnPropertyChanged("EMS");
            }
        }

        /// <summary>
        /// Enable umb memory.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? UMB
        {
            get
            {
                return _umb;
            }
            set
            {
                _umb = value;
                OnPropertyChanged("UMB");
            }
        }

        /// <summary>
        /// Change layout of the keyboard
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public KeyboardLayout? KeyboardLayout
        {
            get
            {
                return _keyboardLayout;
            }
            set
            {
                _keyboardLayout = value;
                OnPropertyChanged("KeyboardLayout");
            }
        }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create a new DOS Options for DosBox configuration
        /// </summary>
        /// <returns>DosBox DOS configuration to add another configuration</returns>
        public static DosOptions Create()
        {
            return new DosOptions();
        }

        /// <summary>
        /// Enable XMS memory.
        /// </summary>
        /// <param name="xms">XMS Memory.</param>
        /// <returns>DosBox DOS configuration to add another configuration</returns>
        public DosOptions AddXMS(bool? xms = true)
        {
            XMS = xms;
            return this;
        }

        /// <summary>
        /// Enable EMS memory.
        /// </summary>
        /// <param name="ems">EMS Memory.</param>
        /// <returns>DosBox DOS configuration to add another configuration</returns>
        public DosOptions AddEMS(bool? ems = true)
        {
            EMS = ems;
            return this;
        }

        /// <summary>
        /// Enable UMB memory.
        /// </summary>
        /// <param name="umb">UMB Memory.</param>
        /// <returns>DosBox DOS configuration to add another configuration</returns>
        public DosOptions AddUMB(bool? umb = true)
        {
            UMB = umb;
            return this;
        }

        /// <summary>
        /// Change layout of the keyboard
        /// </summary>
        /// <param name="keyboardLayout">Keyboard Layout</param>
        /// <returns>DosBox DOS configuration to add another configuration</returns>
        public DosOptions AddKeyboardLayout(KeyboardLayout? keyboardLayout = null)
        {
            KeyboardLayout = keyboardLayout;
            return this;
        }

        #endregion "Fluent"

        #region "String"

        /// <summary>
        /// Cast DOS options to string
        /// </summary>
        /// <returns>String in INI format</returns>
        public override string ToString()
        {
            var options = new StringBuilder(base.ToString());

            options.CreateIniLine("xms", XMS);
            options.CreateIniLine("ems", EMS);
            options.CreateIniLine("umb", UMB);
            options.CreateIniLine("keyboardlayout", KeyboardLayout);

            return options.ToString();
        }

        #endregion "String"

        #region "BaseOptions"

        /// <summary>
        /// Load DOS options values from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary with options DOS data</param>
        public override void LoadDictionary(IDictionary<string, object> dictionary)
        {
            foreach (var data in dictionary)
            {
                switch (data.Key)
                {
                    case "xms":
                        XMS = SimpleIniParse.GetBool(data.Value);
                        break;

                    case "ems":
                        EMS = SimpleIniParse.GetBool(data.Value);
                        break;

                    case "umb":
                        UMB = SimpleIniParse.GetBool(data.Value);
                        break;

                    case "keyboardlayout":
                        KeyboardLayout = new KeyboardLayout(data.Value.ToString());
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion "BaseOptions"
    }
}
