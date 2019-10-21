using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// <para>Sound Blaster related settings.</para>
    /// <para>See more in <a href="https://www.dosbox.com/wiki/Sound">Sound DoSBox</a> Wiki page</para>
    /// </summary>
    public class SoundBlasterOptions : BaseOptions
    {
        #region "Constructions"

        /// <summary>
        /// Create instance of Sound Blaster options class
        /// </summary>
        public SoundBlasterOptions()
            : base("sblaster")
        {
        }

        #endregion "Constructions"

        #region "Fields"

        private SoundBlaster? _sbtype;
        private IOAddress? _sbbase;
        private IRQ? _irq;
        private DMA? _dma;
        private DMA? _hdma;
        private bool? _sbmixer;
        private OplMode? _oplmode;
        private OplEmu? _oplemu;
        private SampleRate? _oplrate;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// Type of Soundblaster to emulate. gb is Gameblaster.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public SoundBlaster? SBType
        {
            get
            {
                return _sbtype;
            }
            set
            {
                _sbtype = value;
                OnPropertyChanged("SBType");
            }
        }

        /// <summary>
        /// The IO address of the soundblaster.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public IOAddress? SBBase
        {
            get
            {
                return _sbbase;
            }
            set
            {
                _sbbase = value;
                OnPropertyChanged("SBBase");
            }
        }

        /// <summary>
        /// The IRQ number of the soundblaster.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public IRQ? IRQ
        {
            get
            {
                return _irq;
            }
            set
            {
                _irq = value;
                OnPropertyChanged("IRQ");
            }
        }

        /// <summary>
        /// The DMA number of the soundblaster.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public DMA? DMA
        {
            get
            {
                return _dma;
            }
            set
            {
                _dma = value;
                OnPropertyChanged("DMA");
            }
        }

        /// <summary>
        /// The High DMA number of the soundblaster.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public DMA? HDMA
        {
            get
            {
                return _hdma;
            }
            set
            {
                _hdma = value;
                OnPropertyChanged("HDMA");
            }
        }

        /// <summary>
        /// Allow the soundblaster mixer to modify the DOSBox mixer.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? SBMixer
        {
            get
            {
                return _sbmixer;
            }
            set
            {
                _sbmixer = value;
                OnPropertyChanged("SBMixer");
            }
        }

        /// <summary>
        /// Type of OPL emulation. On 'auto' the mode is determined by sblaster type. All OPL modes are Adlib-compatible, except for 'cms'.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public OplMode? OplMode
        {
            get
            {
                return _oplmode;
            }
            set
            {
                _oplmode = value;
                OnPropertyChanged("OplMode");
            }
        }

        /// <summary>
        /// Provider for the OPL emulation. compat might provide better quality (see oplrate as well).
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public OplEmu? OplEmu
        {
            get
            {
                return _oplemu;
            }
            set
            {
                _oplemu = value;
                OnPropertyChanged("OplEmu");
            }
        }

        /// <summary>
        /// Sample rate of OPL music emulation. Use 49716 for highest quality (set the mixer rate accordingly).
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public SampleRate? OplRate
        {
            get
            {
                return _oplrate;
            }
            set
            {
                _oplrate = value;
                OnPropertyChanged("OplRate");
            }
        }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create a new Sound Blaster options for DosBox configuration
        /// </summary>
        /// <returns>Sound Blaster options to add another configuration</returns>
        public static SoundBlasterOptions Create()
        {
            return new SoundBlasterOptions();
        }

        /// <summary>
        /// Type of Soundblaster to emulate. gb is Gameblaster.
        /// </summary>
        /// <param name="sbtype">Possible values: sb1, sb2, sbpro1, sbpro2, sb16, gb, none.</param>
        /// <returns>Sound Blaster options to add another configuration</returns>
        public SoundBlasterOptions AddSBType(SoundBlaster? sbtype = SoundBlaster.SoundBlaster16)
        {
            SBType = sbtype;
            return this;
        }

        /// <summary>
        /// The IO address of the soundblaster.
        /// </summary>
        /// <param name="sbbase">ossible values: 220, 240, 260, 280, 2a0, 2c0, 2e0, 300.</param>
        /// <returns>Sound Blaster options to add another configuration</returns>
        public SoundBlasterOptions AddSBBase(IOAddress? sbbase = IOAddress.Address220)
        {
            SBBase = sbbase;
            return this;
        }

        /// <summary>
        /// The IRQ number of the soundblaster.
        /// </summary>
        /// <param name="irq">Possible values: 7, 5, 3, 9, 10, 11, 12.</param>
        /// <returns>Sound Blaster options to add another configuration</returns>
        public SoundBlasterOptions AddIRQ(IRQ? irq = Options.IRQ.IRQ7)
        {
            IRQ = irq;
            return this;
        }

        /// <summary>
        /// The DMA number of the soundblaster.
        /// </summary>
        /// <param name="dma">Possible values: 1, 5, 0, 3, 6, 7.</param>
        /// <returns>Sound Blaster options to add another configuration</returns>
        public SoundBlasterOptions AddDMA(DMA? dma = Options.DMA.DMA1)
        {
            DMA = dma;
            return this;
        }

        /// <summary>
        /// The High DMA number of the soundblaster.
        /// </summary>
        /// <param name="hdma">Possible values: 1, 5, 0, 3, 6, 7.</param>
        /// <returns>Sound Blaster options to add another configuration</returns>
        public SoundBlasterOptions AddHDMA(DMA? hdma = Options.DMA.DMA5)
        {
            HDMA = hdma;
            return this;
        }

        /// <summary>
        /// Allow the soundblaster mixer to modify the DOSBox mixer.
        /// </summary>
        /// <param name="sbmixer">Allow the soundblaster mixer to modify the DOSBox mixer.</param>
        /// <returns>Sound Blaster options to add another configuration</returns>
        public SoundBlasterOptions AddSoundMixer(bool? sbmixer = true)
        {
            SBMixer = sbmixer;
            return this;
        }

        /// <summary>
        /// Type of OPL emulation. On 'auto' the mode is determined by sblaster type. All OPL modes are Adlib-compatible, except for 'cms'.
        /// </summary>
        /// <param name="oplmode">Possible values: auto, cms, opl2, dualopl2, opl3, none.</param>
        /// <returns>Sound Blaster options to add another configuration</returns>
        public SoundBlasterOptions AddOplMode(OplMode? oplmode = Options.OplMode.Auto)
        {
            OplMode = oplmode;
            return this;
        }

        /// <summary>
        /// Provider for the OPL emulation. compat might provide better quality (see oplrate as well).
        /// </summary>
        /// <param name="oplemu">Possible values: default, compat, fast.</param>
        /// <returns>Sound Blaster options to add another configuration</returns>
        public SoundBlasterOptions AddOplEmu(OplEmu? oplemu = Options.OplEmu.Default)
        {
            OplEmu = oplemu;
            return this;
        }

        /// <summary>
        /// Sample rate of OPL music emulation. Use 49716 for highest quality (set the mixer rate accordingly).
        /// </summary>
        /// <param name="oplrate">Possible values: 44100, 49716, 48000, 32000, 22050, 16000, 11025, 8000.</param>
        /// <returns>Sound Blaster options to add another configuration</returns>
        public SoundBlasterOptions AddOplRate(SampleRate? oplrate = SampleRate.Rate44100)
        {
            OplRate = oplrate;
            return this;
        }

        #endregion "Fluent"

        #region "String"

        /// <summary>
        /// Cast Sound Blaster options to string
        /// </summary>
        /// <returns>Sound Blaster options ini format</returns>
        public override string ToString()
        {
            var options = new StringBuilder(base.ToString());

            options.CreateIniLine("sbtype", SBType);
            options.CreateIniLine("sbbase", SBBase);
            options.CreateIniLine("irq", IRQ);
            options.CreateIniLine("dma", DMA);
            options.CreateIniLine("hdma", HDMA);
            options.CreateIniLine("sbmixer", SBMixer);
            options.CreateIniLine("oplmode", OplMode);
            options.CreateIniLine("oplemu", OplEmu);
            options.CreateIniLine("oplrate", OplRate);

            return options.ToString();
        }

        #endregion "String"

        #region "BaseOptions"

        /// <summary>
        /// Load Sound Blaster options value from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary with options DosBox data</param>
        public override void LoadDictionary(IDictionary<string, object> dictionary)
        {
            foreach (var data in dictionary)
            {
                switch (data.Key)
                {
                    case "sbtype":
                        SBType = SimpleIniParse.GetEnum<SoundBlaster>(data.Value);
                        break;

                    case "sbbase":
                        SBBase = SimpleIniParse.GetEnum<IOAddress>(data.Value);
                        break;

                    case "irq":
                        IRQ = SimpleIniParse.GetEnum<IRQ>(data.Value);
                        break;

                    case "dma":
                        DMA = SimpleIniParse.GetEnum<DMA>(data.Value);
                        break;

                    case "hdma":
                        HDMA = SimpleIniParse.GetEnum<DMA>(data.Value);
                        break;

                    case "sbmixer":
                        SBMixer = SimpleIniParse.GetBool(data.Value);
                        break;

                    case "oplmode":
                        OplMode = SimpleIniParse.GetEnum<OplMode>(data.Value);
                        break;

                    case "oplemu":
                        OplEmu = SimpleIniParse.GetEnum<OplEmu>(data.Value);
                        break;

                    case "oplrate":
                        OplRate = SimpleIniParse.GetEnum<SampleRate>(data.Value);
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion "BaseOptions"
    }
}
