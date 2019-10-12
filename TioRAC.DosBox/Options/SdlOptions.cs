using System;
using System.Collections.Generic;
using System.Text;

namespace TioRAC.DosBox.Options
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Computer_display_standard
    /// </summary>
    public class SdlOptions : BaseOptions
    {
        public SdlOptions()
            : base("sdl")
        {

        }

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

        public int? Sensitivity
        {
            get
            {
                return _sensitivity;
            }
            set
            {
                _sensitivity = value;
                OnPropertyChanged("Sensitivity");
            }
        }

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

    }
}
