using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// <para>GUS Options for DosBox</para>
    /// <para>See more in <a href="https://www.dosbox.com/wiki/Sound">Sound</a> Wiki page</para>
    /// </summary>
    public class GusOptions : BaseOptions
    {
        #region "Constructions"

        /// <summary>
        /// Create instance of GUS options class
        /// </summary>
        public GusOptions()
            : base("gus")
        {

        }

        #endregion "Constructions"

        #region "Fields"

        private bool? _gus;
        private SampleRate? _gusrate;
        private IOAddress? _gusbase;
        private IRQ? _gusirq;
        private DMA? _gusdma;
        private string _ultradir;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// Enable the Gravis Ultrasound emulation..
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? GUS
        {
            get
            {
                return _gus;
            }
            set
            {
                _gus = value;
                OnPropertyChanged("GUS");
            }
        }

        /// <summary>
        /// Sample rate of Ultrasound emulation.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public SampleRate? GusRate
        {
            get
            {
                return _gusrate;
            }
            set
            {
                _gusrate = value;
                OnPropertyChanged("GUSRate");
            }
        }

        /// <summary>
        /// The IO base address of the Gravis Ultrasound.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public IOAddress? GusBase
        {
            get
            {
                return _gusbase;
            }
            set
            {
                _gusbase = value;
                OnPropertyChanged("GUSBase");
            }
        }

        /// <summary>
        /// The IRQ number of the Gravis Ultrasound.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public IRQ? GusIRQ
        {
            get
            {
                return _gusirq;
            }
            set
            {
                _gusirq = value;
                OnPropertyChanged("GUSIRQ");
            }
        }

        /// <summary>
        /// The DMA channel of the Gravis Ultrasound.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public DMA? GusDMA
        {
            get
            {
                return _gusdma;
            }
            set
            {
                _gusdma = value;
                OnPropertyChanged("GUSDMA");
            }
        }

        /// <summary>
        /// Path to Ultrasound directory. In this directory there should be a MIDI directory that contains the patch files for GUS playback.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public string UltraDir
        {
            get
            {
                return _ultradir;
            }
            set
            {
                _ultradir = value;
                OnPropertyChanged("UltraDir");
            }
        }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create a new GUS Options for DosBox configuration
        /// </summary>
        /// <returns>DosBox GUS configuration to add another configuration</returns>
        public static GusOptions Create()
        {
            return new GusOptions();
        }

        /// <summary>
        /// Enable the Gravis Ultrasound emulation.
        /// </summary>
        /// <param name="gus">Enable the Gravis Ultrasound emulation.</param>
        /// <returns>DosBox GUS configuration to add another configuration</returns>
        public GusOptions AddGUS(bool? gus = false)
        {
            GUS = gus;
            return this;
        }

        /// <summary>
        /// Sample rate of Ultrasound emulation.
        /// </summary>
        /// <param name="gusrate">Possible values: 44100, 48000, 32000, 22050, 16000, 11025, 8000, 49716.</param>
        /// <returns>DosBox GUS configuration to add another configuration</returns>
        public GusOptions AddGusRate(SampleRate? gusrate = SampleRate.Rate44100)
        {
            GusRate = gusrate;
            return this;
        }

        /// <summary>
        ///  The IO base address of the Gravis Ultrasound.
        /// </summary>
        /// <param name="gusbase">Possible values: 240, 220, 260, 280, 2a0, 2c0, 2e0, 300.</param>
        /// <returns>DosBox GUS configuration to add another configuration</returns>
        public GusOptions AddGusBase(IOAddress? gusbase = IOAddress.Port240)
        {
            GusBase = gusbase;
            return this;
        }

        /// <summary>
        /// The IRQ number of the Gravis Ultrasound.
        /// </summary>
        /// <param name="gusirq">Possible values: 5, 3, 7, 9, 10, 11, 12.</param>
        /// <returns>DosBox GUS configuration to add another configuration</returns>
        public GusOptions AddGusIRQ(IRQ? gusirq = IRQ.IRQ5)
        {
            GusIRQ = gusirq;
            return this;
        }

        /// <summary>
        /// The DMA channel of the Gravis Ultrasound.
        /// </summary>
        /// <param name="dma">Possible values: 3, 0, 1, 5, 6, 7.</param>
        /// <returns>DosBox GUS configuration to add another configuration</returns>
        public GusOptions AddGusDMA(DMA? dma = DMA.DMA3)
        {
            GusDMA = dma;
            return this;
        }

        /// <summary>
        /// Path to Ultrasound directory. In this directory there should be a MIDI directory that contains the patch files for GUS playback.
        /// </summary>
        /// <param name="ultradir">Path to Ultrasound directory. In this directory there should be a MIDI directory that contains the patch files for GUS playback.</param>
        /// <returns>DosBox GUS configuration to add another configuration</returns>
        public GusOptions AddUltraDir(string ultradir = @"C:\ULTRASND")
        {
            UltraDir = ultradir;
            return this;
        }

        #endregion "Fluent"

        #region "String"

        /// <summary>
        /// Cast GUS options to string
        /// </summary>
        /// <returns>String in INI format</returns>
        public override string ToString()
        {
            var options = new StringBuilder(base.ToString());

            options.CreateIniLine("gus", GUS);
            options.CreateIniLine("gusrate", GusRate);
            options.CreateIniLine("gusbase", GusBase);
            options.CreateIniLine("gusirq", GusIRQ);
            options.CreateIniLine("gusdma", GusDMA);
            options.CreateIniLine("ultradir", UltraDir);

            return options.ToString();
        }

        #endregion "String"

        #region "BaseOptions"

        /// <summary>
        /// Load GUS options values from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary with options GUS data</param>
        public override void LoadDictionary(IDictionary<string, object> dictionary)
        {
            foreach (var data in dictionary)
            {
                switch (data.Key)
                {
                    case "gus":
                        GUS = SimpleIniParse.GetBool(data.Value);
                        break;

                    case "gusrate":
                        GusRate = SimpleIniParse.GetEnum<SampleRate>(data.Value);
                        break;

                    case "gusbase":
                        GusBase = SimpleIniParse.GetEnum<IOAddress>(data.Value);
                        break;

                    case "gusirq":
                        GusIRQ = SimpleIniParse.GetEnum<IRQ>(data.Value);
                        break;

                    case "gusdma":
                        GusDMA = SimpleIniParse.GetEnum<DMA>(data.Value);
                        break;

                    case "ultradir":
                        UltraDir = data.Value.ToString();
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion "BaseOptions"
    }
}
