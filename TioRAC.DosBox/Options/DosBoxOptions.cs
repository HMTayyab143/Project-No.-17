using System;
using System.Collections.Generic;
using System.Text;

namespace TioRAC.DosBox.Options
{
    /// <summary>
    /// <para>The DosBox options section contains various settings that do not pertain to any other section</para>
    /// <para>See more in <a href="https://www.dosbox.com/wiki/Configuration:DOSBOX">DosBox Configuriotn DOSBox</a> Wiki page</para>
    /// </summary>
    public class DosBoxOptions : BaseOptions
    {
        #region "Constructions"

        /// <summary>
        /// Create instance of DosBox options class
        /// </summary>
        public DosBoxOptions()
            : base("dosbox")
        {
        }

        #endregion "Constructions"

        #region "Fields"

        private string _language;
        private DosBoxMachine? _machine;
        private string _captures;
        private uint? _memSize;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// Select another language file.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
                OnPropertyChanged("Language");
            }
        }

        /// <summary>
        /// The type of machine (specifically the type of graphics hardware) DOSBox tries to emulate.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public DosBoxMachine? Machine
        {
            get
            {
                return _machine;
            }
            set
            {
                _machine = value;
                OnPropertyChanged("Machine");
            }
        }

        /// <summary>
        /// Directory where things like music (wave and MIDI) and screenshots are captured when special keys CTRL-F5 and CTRL-F6 are used. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public string Captures
        {
            get
            {
                return _captures;
            }
            set
            {
                _captures = value;
                OnPropertyChanged("Captures");
            }
        }

        /// <summary>
        /// Amount of high memory (in megabytes) available to programs.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public uint? MemSize
        {
            get
            {
                return _memSize;
            }
            set
            {
                _memSize = value;
                OnPropertyChanged("MemSize");
            }
        }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create a new DosBox options for DosBox configuration
        /// </summary>
        /// <returns>DosBox options to add another configuration</returns>
        public static DosBoxOptions Create()
        {
            return new DosBoxOptions();
        }

        /// <summary>
        /// Select another language file.
        /// </summary>
        /// <param name="language">language file.</param>
        /// <returns>DosBox options to add another configuration</returns>
        public DosBoxOptions AddLanguage(string language = null)
        {
            this.Language = language;
            return this;
        }

        /// <summary>
        /// The type of machine (specifically the type of graphics hardware) DOSBox tries to emulate.
        /// </summary>
        /// <param name="machine">Machine type</param>
        /// <returns>DosBox options to add another configuration</returns>
        public DosBoxOptions AddMachine(DosBoxMachine? machine = DosBoxMachine.SVGA_S3)
        {
            Machine = machine;
            return this;
        }

        /// <summary>
        /// Directory where things like music (wave and MIDI) and screenshots are captured when special keys CTRL-F5 and CTRL-F6 are used.
        /// </summary>
        /// <param name="captures">Captures directory</param>
        /// <returns>DosBox options to add another configuration</returns>
        public DosBoxOptions AddCaptures(string captures = "capture")
        {
            Captures = captures;
            return this;
        }

        /// <summary>
        /// Amount of high memory (in megabytes) available to programs.
        /// </summary>
        /// <param name="memSize">Memory size</param>
        /// <returns>DosBox options to add another configuration</returns>
        public DosBoxOptions AddMemSize(uint? memSize = 16)
        {
            MemSize = memSize;
            return this;
        }

        #endregion "Fluent"

        #region "String"

        /// <summary>
        /// Cast DosBox options to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var options = new StringBuilder(base.ToString());

            options.CreateIniLine("language", Language);
            options.CreateIniLine("machine", Machine);
            options.CreateIniLine("captures", Captures);
            options.CreateIniLine("memsize", MemSize);

            return options.ToString();
        }

        #endregion "String"

        #region "BaseOptions"

        /// <summary>
        /// Load DosBox options value from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary with options DosBox data</param>
        public override void LoadDictionary(IDictionary<string, object> dictionary)
        {
            foreach (var data in dictionary)
            {
                switch (data.Key)
                {
                    case "language":
                        Language = data.Value.ToString();
                        break;

                    case "machine":
                        Machine = SimpleIniParse.GetEnum<DosBoxMachine>(data.Value);
                        break;

                    case "captures":
                        Captures = data.Value.ToString(); ;
                        break;

                    case "memsize":
                        MemSize = SimpleIniParse.GetUInt(data.Value);
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion "BaseOptions"
    }
}
