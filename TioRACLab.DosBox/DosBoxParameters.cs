using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace TioRACLab.DosBox
{
    /// <summary>
    /// DosBox command line parameters see: <a href="https://www.dosbox.com/wiki/Usage">DosBox Wiki: Usage</a>
    /// </summary>
    public class DosBoxParameters : INotifyPropertyChanged
    {
        #region "Constructions"

        ///<summary>
        ///Create new instance to DosBoxParameters with parameters for DosBox application
        ///</summary>
        public DosBoxParameters()
        {
            this.Commands = new ObservableCollection<string>();
            this.Configurations = new ObservableCollection<string>();
            this.Languages = new ObservableCollection<string>();
            this.EditConfs = new ObservableCollection<string>();
        }

        ///<summary>
        ///Create new instance to DosBoxParameters with parameters for DosBox application
        ///</summary>
        /// <param name="name">Add parameter Name <seealso cref="DosBoxParameters.Name" /></param>
        public DosBoxParameters(string name)
            : this()
        {
            this.Name = name;
        }

        #endregion "Constructions"

        #region "Fields"

        private string _name;
        private bool _exit;
        private ObservableCollection<string> _commands;
        private bool _fullscreen;
        private bool _userConf;
        private ObservableCollection<string> _configurations;
        private ObservableCollection<string> _languages;
        private string _machine;
        private bool _noConsole;
        private bool _startMapper;
        private bool _noAutoexec;
        private bool _secureMode;
        private bool _scaler;
        private bool _forceScaler;
        private bool _version;
        private ObservableCollection<string> _editConfs;
        private string _openCaptures;
        private bool _printConf;
        private bool _resetConf;
        private bool _resetMapper;
        private bool _socket;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// <para>If name is a directory, DOSBox will mount the specified directory as the C drive.</para>
        /// <para>If name is an executable, DOSBox will mount the directory of name as the C drive, and start executing name.</para>
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// DOSBox will close itself when the DOS application name ends. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool Exit
        {
            get
            {
                return _exit;
            }
            set
            {
                _exit = value;
                OnPropertyChanged("Exit");
            }
        }

        /// <summary>
        /// Runs the specified command before running name. Multiple commands can be specified. Each command should start with -c though. A command can be: an Internal Program, a DOS command or an executable on a mounted drive. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public ObservableCollection<string> Commands
        {
            get
            {
                return _commands;
            }
            protected set
            {
                _commands = value;
                OnPropertyChanged("Commands");
            }
        }

        /// <summary>
        /// Starts DOSBox in fullscreen mode. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool Fullscreen
        {
            get
            {
                return _fullscreen;
            }
            set
            {
                _fullscreen = value;
                OnPropertyChanged("Fullscreen");
            }
        }

        /// <summary>
        /// Load the configuration from the user's profile or home directory. This is the default behavior, so this switch is useful when using -conf, below. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool UserConf
        {
            get
            {
                return _userConf;
            }
            set
            {
                _userConf = value;
                OnPropertyChanged("UserConf");
            }
        }

        /// <summary>
        /// Load the config file specified in configfilelocation. Useful for specifying particular options for specific games. If used after -userconf, or if you use multiple -conf switches, options present in multiple configs will be overwritten by the last, except for autoexec entries, which will be appended in order. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public ObservableCollection<string> Configurations
        {
            get
            {
                return _configurations;
            }
            protected set
            {
                _configurations = value;
                OnPropertyChanged("Configurations");
            }
        }

        /// <summary>
        /// Start DOSBox using the language string specified in languagefilelocation. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public ObservableCollection<string> Languages
        {
            get
            {
                return _languages;
            }
            protected set
            {
                _languages = value;
                OnPropertyChanged("Languages");
            }
        }

        /// <summary>
        /// Setup DOSBox to emulate a specific type of machine. Valid choices are: hercules, cga, ega, pcjr, tandy, svga_s3 (default) as well as the additional svga chipsets listed in the DOSBox configuration file. The machinetype affects the video card and the available sound cards. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public string Machine
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
        /// Start DOSBox without showing the console window, output will be redirected to stdout.txt and stderr.txt. This is useful if DOSBox crashes, since the error messages stored in stdout.txt and stderr.txt may help the developers fixing the problem. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool NoConsole
        {
            get
            {
                return _noConsole;
            }
            set
            {
                _noConsole = value;
                OnPropertyChanged("NoConsole");
            }
        }

        /// <summary>
        /// Enter the mapper directly on startup. Useful for people with keyboard or joystick problems. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool StartMapper
        {
            get
            {
                return _startMapper;
            }
            set
            {
                _startMapper = value;
                OnPropertyChanged("StartMapper");
            }
        }

        /// <summary>
        /// Skips the [autoexec] section of the loaded configuration file. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool NoAutoexec
        {
            get
            {
                return _noAutoexec;
            }
            set
            {
                _noAutoexec = value;
                OnPropertyChanged("NoAutoexec");
            }
        }

        /// <summary>
        /// Same as -noautoexec, but adds config.com -securemode at the bottom of AUTOEXEC.BAT (which in turn disables any changes to how the drives are mounted inside DOSBox). 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool SecureMode
        {
            get
            {
                return _secureMode;
            }
            set
            {
                _secureMode = value;
                OnPropertyChanged("SecureMode");
            }
        }

        /// <summary>
        /// Uses the scaler specified by "scaler". See the DOSBox configuration file for the available scalers.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool Scaler
        {
            get
            {
                return _scaler;
            }
            set
            {
                _scaler = value;
                OnPropertyChanged("Scaler");
            }
        }

        /// <summary>
        /// Similar to the -scaler parameter, but tries to force usage of the specified scaler even if it might not fit.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool ForceScaler
        {
            get
            {
                return _forceScaler;
            }
            set
            {
                _forceScaler = value;
                OnPropertyChanged("ForceScaler");
            }
        }

        /// <summary>
        /// output version information and exit. (see stdout.txt) Useful for frontends. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
                OnPropertyChanged("Version");
            }
        }

        /// <summary>
        /// calls program with as first parameter the configuration file. You can specify this command more than once. In this case it will move to second program if the first one fails to start. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public ObservableCollection<string> EditConfs
        {
            get
            {
                return _editConfs;
            }
            protected set
            {
                _editConfs = value;
                OnPropertyChanged("EditConfs");
            }
        }

        /// <summary>
        /// calls program with as first parameter the location of the captures folder. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public string OpenCaptures
        {
            get
            {
                return _openCaptures;
            }
            set
            {
                _openCaptures = value;
                OnPropertyChanged("OpenCaptures");
            }
        }

        /// <summary>
        /// prints the location of the default configuration file. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool PrintConf
        {
            get
            {
                return _printConf;
            }
            set
            {
                _printConf = value;
                OnPropertyChanged("PrintConf");
            }
        }

        /// <summary>
        /// removes the default configuration file. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool ResetConf
        {
            get
            {
                return _resetConf;
            }
            set
            {
                _resetConf = value;
                OnPropertyChanged("ResetConf");
            }
        }

        /// <summary>
        /// removes the mapperfile used by the default clean configuration file. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool ResetMapper
        {
            get
            {
                return _resetMapper;
            }
            set
            {
                _resetMapper = value;
                OnPropertyChanged("ResetMapper");
            }
        }

        /// <summary>
        /// passes the socket number to the nullmodem emulation. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool Socket
        {
            get
            {
                return _socket;
            }
            set
            {
                _socket = value;
                OnPropertyChanged("Socket");
            }
        }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create a new DosBox Parameters object
        /// </summary>
        /// <returns>New DosBox Parameters object</returns>
        public static DosBoxParameters Create()
        {
            return new DosBoxParameters();
        }

        /// <summary>
        /// Create a new DosBox Parameters object
        /// </summary>
        /// <param name="name">Add parameter Name <seealso cref="DosBoxParameters.Name" /></param>
        /// <returns>New DosBox Parameters object</returns>
        public static DosBoxParameters Create(string name)
        {
            return new DosBoxParameters(name);
        }

        /// <summary>
        /// Add parameter name
        /// </summary>
        /// <param name="name">If name is a directory, DOSBox will mount the specified directory as the C drive.
        /// If name is an executable, DOSBox will mount the directory of name as the C drive, and start executing name. </param>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddName(string name)
        {
            this.Name = name;
            return this;
        }

        /// <summary>
        /// Add parameter: -exit
        /// DOSBox will close itself when the DOS application name ends. 
        /// </summary>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddExit()
        {
            Exit = true;
            return this;
        }

        /// <summary>
        /// Add single parameter command
        /// </summary>
        /// <param name="command">Runs the specified command before running name.</param>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddCommand(string command)
        {
            this.Commands.Add(command);
            return this;
        }

        /// <summary>
        /// Add parameter: -fullscreen
        /// Starts DOSBox in fullscreen mode. 
        /// </summary>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddFullscreen()
        {
            Fullscreen = true;
            return this;
        }

        /// <summary>
        /// Add parameter: -userconf
        /// -Load the configuration from the user's profile or home directory.
        /// </summary>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddUserConf()
        {
            UserConf = true;
            return this;
        }

        /// <summary>
        /// Add single parameter conf
        /// </summary>
        /// <param name="configuration">Load the config file specified.</param>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddConfiguration(string configuration)
        {
            this.Configurations.Add(configuration);
            return this;
        }

        /// <summary>
        /// Add single parameter lang 
        /// </summary>
        /// <param name="languages">Start DOSBox using the language string specified</param>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddLanguages(string languages)
        {
            this.Languages.Add(languages);
            return this;
        }

        /// <summary>
        /// Add parameter: -machine
        /// Setup DOSBox to emulate a specific type of machine.
        /// </summary>
        /// <param name="machine">Valid choices are: hercules, cga, ega, pcjr, tandy, svga_s3 (default)</param>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddMachine(string machine)
        {
            this.Machine= machine;
            return this;
        }

        /// <summary>
        /// Add parameter: -noconsole
        /// Start DOSBox without showing the console window (Windows Only).
        /// </summary>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddNoConsole()
        {
            NoConsole = true;
            return this;
        }

        /// <summary>
        /// Add parameter: -startmapper
        /// Enter the mapper directly on startup.
        /// </summary>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddStartMapper()
        {
            StartMapper = true;
            return this;
        }

        /// <summary>
        /// Add parameter: -noautoexec
        /// Skips the [autoexec] section of the loaded configuration file.
        /// </summary>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddNoAutoexec()
        {
            NoAutoexec = true;
            return this;
        }

        /// <summary>
        /// Add parameter: -securemode
        /// Same as -noautoexec, but adds config.com -securemode at the bottom of AUTOEXEC.BAT
        /// </summary>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddSecureMode()
        {
            SecureMode = true;
            return this;
        }

        /// <summary>
        /// Add parameter: -scaler
        /// Uses the scaler specified by "scaler".
        /// </summary>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddScaler()
        {
            Scaler = true;
            return this;
        }

        /// <summary>
        /// Add parameter: -forcescaler
        /// Similar to the -scaler parameter, but tries to force usage of the specified scaler even if it might not fit.
        /// </summary>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddForceScaler()
        {
            ForceScaler = true;
            return this;
        }

        /// <summary>
        /// Add parameter: -version
        /// output version information and exit.
        /// </summary>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddVersion()
        {
            Version = true;
            return this;
        }

        /// <summary>
        /// Add single parameter editconf 
        /// </summary>
        /// <param name="editConf">Calls program with as first parameter the configuration file.</param>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddEditConf(string editConf)
        {
            this.EditConfs.Add(editConf);
            return this;
        }

        /// <summary>
        /// Add parameter: -opencaptures
        /// Calls program with as first parameter the location of the captures folder. 
        /// </summary>
        /// <param name="openCaptures">Progam location</param>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddOpenCaptures(string openCaptures)
        {
            this.OpenCaptures = openCaptures;
            return this;
        }

        /// <summary>
        /// Add parameter: -printconf
        /// Prints the location of the default configuration file. 
        /// </summary>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddPrintConf()
        {
            PrintConf = true;
            return this;
        }

        /// <summary>
        /// Add parameter: -resetconf
        /// Removes the default configuration file.
        /// </summary>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddResetConf()
        {
            ResetConf = true;
            return this;
        }

        /// <summary>
        /// Add parameter: -resetmapper
        /// Removes the mapperfile used by the default clean configuration file. 
        /// </summary>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddResetMapper()
        {
            ResetMapper = true;
            return this;
        }

        /// <summary>
        /// Add parameter: -socket
        /// Passes the socket number to the nullmodem emulation. 
        /// </summary>
        /// <returns>DosBox parameters to add another parameter</returns>
        public DosBoxParameters AddSocket()
        {
            Socket = true;
            return this;
        }

        #endregion "Fluent"

        #region "INotifyPropertyChanged"

        /// <summary>
        /// Handler Property Changed
        /// </summary>
        protected PropertyChangedEventHandler PropertyChangedHandler;
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                PropertyChangedHandler += value;
            }
            remove
            {
                PropertyChangedHandler -= value;
            }
        }

        /// <summary>
        /// Notify Property Changed
        /// </summary>
        /// <param name="name">Name Property</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedHandler?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion "INotifyPropertyChanged"

        #region "String Casts"

        /// <summary>
        /// Return string with parameters
        /// </summary>
        /// <returns>String with parameters</returns>
        public override string ToString()
        {
            var listArguments = new List<string>();

            if (!string.IsNullOrWhiteSpace(Name))
                listArguments.Add($"\"{Name}\"");

            if (Exit)
                listArguments.Add("-exit");

            if (Commands.Count > 0)
                listArguments.AddRange(Commands.Select(c => $"-c \"{c}\""));

            if (Fullscreen)
                listArguments.Add("-fullscreen");

            if (UserConf)
                listArguments.Add("-userconf");

            if (Configurations.Count > 0)
                listArguments.AddRange(Configurations.Select(conf => $"-conf \"{conf}\""));

            if (Languages.Count > 0)
                listArguments.AddRange(Languages.Select(lang => $"-lang \"{lang}\""));

            if (!string.IsNullOrWhiteSpace(Machine))
                listArguments.Add($"-machine {Machine}");

            if (NoConsole)
                listArguments.Add("-noconsole");

            if (StartMapper)
                listArguments.Add("-startmapper");

            if (NoAutoexec)
                listArguments.Add("-noautoexec");

            if (SecureMode)
                listArguments.Add("-securemode");

            if (Scaler)
                listArguments.Add("-scaler");

            if (ForceScaler)
                listArguments.Add("-forcescaler");

            if (Version)
                listArguments.Add("-version");

            if (EditConfs.Count > 0)
                listArguments.AddRange(EditConfs.Select(editconf=> $"-editconf \"{editconf}\""));

            if (!string.IsNullOrWhiteSpace(OpenCaptures))
                listArguments.Add($"-opencaptures \"{OpenCaptures}\"");

            if (PrintConf)
                listArguments.Add("-printconf");

            if (ResetConf)
                listArguments.Add("-resetconf");

            if (ResetMapper)
                listArguments.Add("-resetmapper");

            if (Socket)
                listArguments.Add("-socket");

            return string.Join(" ", listArguments);
        }

        /// <summary>
        /// Load parameters from string
        /// </summary>
        /// <param name="parameters">String with parameters</param>
        protected void CastString(string parameters)
        {
            if (string.IsNullOrWhiteSpace(parameters))
                return;

            var listParameters = parameters.Replace("  ", " ").Split(' ').ToList();
            
            if (!listParameters.FirstOrDefault().StartsWith("-"))
            {
                Name = GetOptionParameter(listParameters);
            }

            while (listParameters.Count > 0)
            {
                var parameter = listParameters.FirstOrDefault().Trim();
                listParameters.RemoveAt(0);

                switch (parameter)
                {
                    case "-exit":
                        AddExit();
                        break;

                    case "-c":
                        AddCommand(GetOptionParameter(listParameters));
                        break;

                    case "-fullscreen":
                        AddFullscreen();
                        break;

                    case "-userconf":
                        AddUserConf();
                        break;

                    case "-conf":
                        AddConfiguration(GetOptionParameter(listParameters));
                        break;

                    case "-lang":
                        AddLanguages(GetOptionParameter(listParameters));
                        break;

                    case "-machine":
                        AddMachine(GetOptionParameter(listParameters));
                        break;

                    case "-noconsole":
                        AddNoConsole();
                        break;

                    case "-startmapper":
                        AddStartMapper();
                        break;

                    case "-noautoexec":
                        AddNoAutoexec();
                        break;

                    case "-securemode":
                        AddSecureMode();
                        break;

                    case "-scaler":
                        AddScaler();
                        break;

                    case "-forcescaler":
                        AddForceScaler();
                        break;

                    case "-version":
                        AddVersion();
                        break;

                    case "-editconf":
                        AddEditConf(GetOptionParameter(listParameters));
                        break;

                    case "-opencaptures":
                        AddOpenCaptures(GetOptionParameter(listParameters));
                        break;

                    case "-printconf":
                        AddPrintConf();
                        break;

                    case "-resetconf":
                        AddResetConf();
                        break;

                    case "-resetmapper":
                        AddResetMapper();
                        break;

                    case "-socket":
                        AddSocket();
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Get parameter options 
        /// </summary>
        /// <param name="listParameters">List parameters string split</param>
        /// <returns>Parameter options</returns>
        private static string GetOptionParameter(List<string> listParameters)
        {
            var option = listParameters.FirstOrDefault();
            listParameters.RemoveAt(0);

            if (option.StartsWith("\""))
            {
                while (!option.EndsWith("\""))
                {
                    option += $" {listParameters.FirstOrDefault()}";
                    listParameters.RemoveAt(0);
                }

                option = option.Substring(1, option.Length - 2);
            }

            return option;
        }

        /// <summary>
        /// Get DosBoxParameters from string with parameters
        /// </summary>
        /// <param name="parameters">String with parameters</param>
        /// <returns>DosBox object with parameters</returns>
        public static DosBoxParameters FromString(string parameters)
        {
            var dosboxParameters = new DosBoxParameters();
            dosboxParameters.CastString(parameters);

            return dosboxParameters;
        }

        /// <summary>
        /// Cast DosBox Parameters to string
        /// </summary>
        /// <param name="parameters">DosBox Parameters</param>
        public static implicit operator string(DosBoxParameters parameters)
        {
            return parameters?.ToString();
        }

        /// <summary>
        /// Cast string to DosBox Parameters
        /// </summary>
        /// <param name="parameters">DosBox Parameters</param>
        public static implicit operator DosBoxParameters(string parameters)
        {
            return DosBoxParameters.FromString(parameters);
        }

        #endregion "String Casts"
    }
}
