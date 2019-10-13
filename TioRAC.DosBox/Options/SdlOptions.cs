using System;
using System.Collections.Generic;
using System.Text;

namespace TioRAC.DosBox.Options
{
    /// <summary>
    /// <para>SDL Options for DosBox</para>
    /// <para>See more in <a href="https://www.dosbox.com/wiki/Configuration:SDL">DosBox Configuriotn SDL</a> Wiki page</para>
    /// </summary>
    public class SdlOptions : BaseOptions
    {
        #region "Constructions"

        /// <summary>
        /// Create instance of SDL options class
        /// </summary>
        public SdlOptions()
            : base("sdl")
        {

        }

        #endregion "Constructions"

        #region "Fields"

        private bool? _fullscreen;
        private bool? _fulldouble;
        private Resolution? _fullResolution;
        private Resolution? _windowResolution;
        private VideoOutput? _output;
        private bool? _autoLock;
        private int? _sensitivity;
        private bool? _waitOnError;
        private PriorityLevel? _priorityFocused;
        private PriorityLevel? _priorityMinimized;
        private string _mapperfile;
        private bool? _useScanCodes;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// Start DOSBox directly in fullscreen.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? FullScreen
        {
            get
            {
                return _fullscreen;
            }
            set
            {
                _fullscreen = value;
                OnPropertyChanged("FullScreen");
            }
        }

        /// <summary>
        /// Use double buffering in fullscreen.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? FullDouble
        {
            get
            {
                return _fulldouble;
            }
            set
            {
                _fulldouble = value;
                OnPropertyChanged("FullDouble");
            }
        }

        /// <summary>
        /// Scale the application to this size IF the output device supports hardware scaling 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public Resolution? FullResolution
        {
            get
            {
                return _fullResolution;
            }
            set
            {
                _fullResolution = value;
                OnPropertyChanged("FullResolution");
            }
        }

        /// <summary>
        /// Scale the window to this size IF the output device supports hardware scaling
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public Resolution? WindowResolution
        {
            get
            {
                return _windowResolution;
            }
            set
            {
                _windowResolution = value;
                OnPropertyChanged("WindowResolution");
            }
        }

        /// <summary>
        /// What to use for output. Surface does not support scaling or aspect correction.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public VideoOutput? Output
        {
            get
            {
                return _output;
            }
            set
            {
                _output = value;
                OnPropertyChanged("Output");
            }
        }

        /// <summary>
        /// Mouse will automatically lock, if you click on the screen.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? AutoLock
        {
            get
            {
                return _autoLock;
            }
            set
            {
                _autoLock = value;
                OnPropertyChanged("AutoLock");
            }
        }

        /// <summary>
        /// Mouse sensitivity. 1..1000
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public int? Sensitivity
        {
            get
            {
                return _sensitivity;
            }
            set
            {
                if (value < 1)
                    _sensitivity = 1;
                else if (value > 1000)
                    _sensitivity = 1000;
                else
                    _sensitivity = value;

                OnPropertyChanged("Sensitivity");
            }
        }

        /// <summary>
        /// Wait before closing the console if DOSBox has an error.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? WaitOnError
        {
            get
            {
                return _waitOnError;
            }
            set
            {
                _waitOnError = value;
                OnPropertyChanged("WaitOnError");
            }
        }

        /// <summary>
        /// <para>Priority levels for DOSBox.</para>
        /// <para>Priority for when DosBox is focused</para>
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public PriorityLevel? PriorityFocused
        {
            get
            {
                return _priorityFocused;
            }
            set
            {
                _priorityFocused = value;
                OnPropertyChanged("PriorityFocused");
            }
        }

        /// <summary>
        /// <para>Priority levels for DOSBox.</para>
        /// <para>Priority for when DosBox is minimized</para>
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public PriorityLevel? PriorityMinimized
        {
            get
            {
                return _priorityMinimized;
            }
            set
            {
                _priorityMinimized = value;
                OnPropertyChanged("PriorityMinimized");
            }
        }

        /// <summary>
        /// File used to load/save the key/event mappings from.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public string MapperFile
        {
            get
            {
                return _mapperfile;
            }
            set
            {
                _mapperfile = value;
                OnPropertyChanged("MapperFile");
            }
        }

        /// <summary>
        /// Avoid usage of symkeys, might not work on all operating systems
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? UseScanCodes
        {
            get
            {
                return _useScanCodes;
            }
            set
            {
                _useScanCodes = value;
                OnPropertyChanged("UseScanCodes");
            }
        }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create a new SDL Options for DosBox configuration
        /// </summary>
        /// <returns>DosBox SDL configuration to add another configuration</returns>
        public static SdlOptions Create()
        {
            return new SdlOptions();
        }

        /// <summary>
        /// Start DOSBox directly in fullscreen.
        /// </summary>
        /// <param name="fullscreen">Start DOSBox directly in fullscreen.</param>
        /// <returns>DosBox SDL configuration to add another configuration</returns>
        public SdlOptions AddFullScreen(bool? fullscreen = true)
        {
            FullScreen = fullscreen;
            return this;
        }

        /// <summary>
        /// Use double buffering in fullscreen.
        /// </summary>
        /// <param name="fulldouble">Use double buffering in fullscreen.</param>
        /// <returns>DosBox SDL configuration to add another configuration</returns>
        public SdlOptions AddFullDouble(bool? fulldouble = true)
        {
            FullDouble = fulldouble;
            return this;
        }

        /// <summary>
        /// Scale the application to this size IF the output device supports hardware scaling 
        /// </summary>
        /// <param name="resolution">Resolution the application</param>
        /// <returns>DosBox SDL configuration to add another configuration</returns>
        public SdlOptions AddFullResolution(Resolution? resolution)
        {
            FullResolution = resolution;
            return this;
        }

        /// <summary>
        /// Scale the window to this size IF the output device supports hardware scaling
        /// </summary>
        /// <param name="resolution">Windows resolution</param>
        /// <returns>DosBox SDL configuration to add another configuration</returns>
        public SdlOptions AddWindowResolution(Resolution? resolution)
        {
            WindowResolution = resolution;
            return this;
        }

        /// <summary>
        /// What to use for output. Surface does not support scaling or aspect correction.
        /// </summary>
        /// <param name="output">What to use for output. Surface does not support scaling or aspect correction.</param>
        /// <returns>DosBox SDL configuration to add another configuration</returns>
        public SdlOptions AddOutput(VideoOutput? output = VideoOutput.Surface)
        {
            Output = output;
            return this;
        }

        /// <summary>
        /// Mouse will automatically lock, if you click on the screen.
        /// </summary>
        /// <param name="autoLock">Mouse will automatically lock, if you click on the screen.</param>
        /// <returns>DosBox SDL configuration to add another configuration</returns>
        public SdlOptions AddAutoLock(bool? autoLock = true)
        {
            AutoLock = autoLock;
            return this;
        }

        /// <summary>
        /// Mouse sensitivity. 1..1000
        /// </summary>
        /// <param name="sensitivity">Mouse sensitivity. 1..1000</param>
        /// <returns>DosBox SDL configuration to add another configuration</returns>
        public SdlOptions AddSensitivity(int? sensitivity = 100)
        {
            Sensitivity = sensitivity;
            return this;
        }

        /// <summary>
        /// Wait before closing the console if DOSBox has an error.
        /// </summary>
        /// <param name="waitOnError">Wait before closing the console if DOSBox has an error.</param>
        /// <returns>DosBox SDL configuration to add another configuration</returns>
        public SdlOptions AddWaitOnError(bool? waitOnError = true)
        {
            WaitOnError = waitOnError;
            return this;
        }

        /// <summary>
        /// <para>Priority levels for DOSBox.</para>
        /// <para>Priority for when DosBox is focused</para>
        /// </summary>
        /// <param name="priorityFocused">Priority levels for DOSBox</param>
        /// <returns>DosBox SDL configuration to add another configuration</returns>
        public SdlOptions AddPriorityFocused(PriorityLevel? priorityFocused = PriorityLevel.Higher)
        {
            PriorityFocused = priorityFocused;
            return this;
        }

        /// <summary>
        /// <para>Priority levels for DOSBox.</para>
        /// <para>Priority for when DosBox is minimized</para>
        /// </summary>
        /// <param name="priorityMinimized">Priority levels for DOSBox</param>
        /// <returns>DosBox SDL configuration to add another configuration</returns>
        public SdlOptions AddPriorityMinimized(PriorityLevel? priorityMinimized = PriorityLevel.Normal)
        {
            PriorityMinimized = priorityMinimized;
            return this;
        }

        /// <summary>
        /// File used to load/save the key/event mappings from.
        /// </summary>
        /// <param name="mapperFile">File used to load/save the key/event mappings from.</param>
        /// <returns>DosBox SDL configuration to add another configuration</returns>
        public SdlOptions AddMapperFile(string mapperFile = null)
        {
            MapperFile = mapperFile;
            return this;
        }

        /// <summary>
        /// Avoid usage of symkeys, might not work on all operating systems
        /// </summary>
        /// <param name="useScanCodes">Avoid usage of symkeys, might not work on all operating systems</param>
        /// <returns>DosBox SDL configuration to add another configuration</returns>
        public SdlOptions AddUseScanCodes(bool? useScanCodes = true)
        {
            UseScanCodes = useScanCodes;
            return this;
        }

        #endregion "Fluent"

        #region "String"

        /// <summary>
        /// Cast SDL options to string
        /// </summary>
        /// <returns>String in INI format</returns>
        public override string ToString()
        {
            var options = new StringBuilder(base.ToString());

            options.CreateIniLine("fullscreen", FullScreen);
            options.CreateIniLine("fulldouble", FullDouble);
            options.CreateIniLine("fullresolution", FullResolution);
            options.CreateIniLine("windowresolution", WindowResolution);
            options.CreateIniLine("output", Output);
            options.CreateIniLine("autolock", AutoLock);
            options.CreateIniLine("sensitivity", Sensitivity);
            options.CreateIniLine("waitonerror", WaitOnError);
            options.CreateIniLine("priority", PriorityFocused, PriorityMinimized);
            options.CreateIniLine("mapperfile", MapperFile);
            options.CreateIniLine("usescancodes", UseScanCodes);

            return options.ToString();
        }

        #endregion "String"

        #region "BaseOptions"

        /// <summary>
        /// Load SDL options values from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary with options SDL data</param>
        public override void LoadDictionary(IDictionary<string, object> dictionary)
        {
            foreach (var data in dictionary)
            {
                switch (data.Key)
                {
                    case "fullscreen":
                        FullScreen = SimpleIniParse.GetBool(data.Value);
                        break;

                    case "fulldouble":
                        FullDouble = SimpleIniParse.GetBool(data.Value);
                        break;

                    case "fullresolution":
                        FullResolution = (Resolution)data.Value.ToString();
                        break;

                    case "windowresolution":
                        WindowResolution = (Resolution)data.Value.ToString();
                        break;

                    case "output":
                        Output = SimpleIniParse.GetEnum<VideoOutput>(data.Value);
                        break;

                    case "autolock":
                        AutoLock = SimpleIniParse.GetBool(data.Value);
                        break;

                    case "sensitivity":
                        Sensitivity = SimpleIniParse.GetInt(data.Value);
                        break;

                    case "waitonerror":
                        WaitOnError = SimpleIniParse.GetBool(data.Value);
                        break;

                    case "priority":
                        if (data.Value is System.Collections.IList priority && priority.Count > 0)
                        {
                            PriorityFocused = SimpleIniParse.GetEnum<PriorityLevel>(priority [0]);

                            if (priority.Count > 1)
                                PriorityMinimized = SimpleIniParse.GetEnum<PriorityLevel>(priority[1]);
                        }
                        break;

                    case "mapperfile":
                        MapperFile = data.Value?.ToString();
                        break;

                    case "usescancodes":
                        UseScanCodes = SimpleIniParse.GetBool(data.Value);
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion "BaseOptions"
    }
}
