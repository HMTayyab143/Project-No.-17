using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// <para>Speaker Options for DosBox</para>
    /// <para>See more in <a href="https://www.dosbox.com/wiki/Sound">Sound</a> Wiki page</para>
    /// </summary>
    public class SpeakerOptions : BaseOptions
    {
        #region "Constructions"

        /// <summary>
        /// Create instance of Speaker options class
        /// </summary>
        public SpeakerOptions()
            : base("speaker")
        {

        }

        #endregion "Constructions"

        #region "Fields"

        private bool? _pcspeaker;
        private SampleRate? _pcrate;
        private OnOffAuto? _tandy;
        private SampleRate? _tandyrate;
        private bool? _disney;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// Enable PC-Speaker emulation.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? PCSpeaker
        {
            get
            {
                return _pcspeaker;
            }
            set
            {
                _pcspeaker = value;
                OnPropertyChanged("PCSpeaker");
            }
        }

        /// <summary>
        /// Sample rate of the PC-Speaker sound generation.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public SampleRate? PCRate
        {
            get
            {
                return _pcrate;
            }
            set
            {
                _pcrate = value;
                OnPropertyChanged("PCRate");
            }
        }

        /// <summary>
        /// Enable Tandy Sound System emulation. For 'auto', emulation is present only if machine is set to 'tandy'.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public OnOffAuto? Tandy
        {
            get
            {
                return _tandy;
            }
            set
            {
                _tandy = value;
                OnPropertyChanged("Tandy");
            }
        }

        /// <summary>
        /// Sample rate of the Tandy 3-Voice generation.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public SampleRate? TandyRate
        {
            get
            {
                return _tandyrate;
            }
            set
            {
                _tandyrate = value;
                OnPropertyChanged("TandyRate");
            }
        }

        /// <summary>
        /// Enable Disney Sound Source emulation. (Covox Voice Master and Speech Thing compatible).
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? Disney
        {
            get
            {
                return _disney;
            }
            set
            {
                _disney = value;
                OnPropertyChanged("Disney");
            }
        }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create a new Speaker Options for DosBox configuration
        /// </summary>
        /// <returns>DosBox Speaker configuration to add another configuration</returns>
        public static SpeakerOptions Create()
        {
            return new SpeakerOptions();
        }

        /// <summary>
        /// Enable PC-Speaker emulation.
        /// </summary>
        /// <param name="pcspeaker">Enable PC-Speaker emulation.</param>
        /// <returns>DosBox Speaker configuration to add another configuration</returns>
        public SpeakerOptions AddPCSpeaker(bool? pcspeaker = true)
        {
            PCSpeaker = pcspeaker;
            return this;
        }

        /// <summary>
        /// Sample rate of the PC-Speaker sound generation.
        /// </summary>
        /// <param name="pcrate">Possible values: 44100, 48000, 32000, 22050, 16000, 11025, 8000, 49716.</param>
        /// <returns>DosBox Speaker configuration to add another configuration</returns>
        public SpeakerOptions AddPCRate(SampleRate? pcrate = SampleRate.Rate44100)
        {
            PCRate = pcrate;
            return this;
        }

        /// <summary>
        /// Enable Tandy Sound System emulation. For 'auto', emulation is present only if machine is set to 'tandy'.
        /// </summary>
        /// <param name="tandy">Possible values: auto, on, off.</param>
        /// <returns>DosBox Speaker configuration to add another configuration</returns>
        public SpeakerOptions AddTandy(OnOffAuto? tandy = OnOffAuto.Auto)
        {
            Tandy = tandy;
            return this;
        }

        /// <summary>
        /// Sample rate of the Tandy 3-Voice generation.
        /// </summary>
        /// <param name="tandyrate">Possible values: 44100, 48000, 32000, 22050, 16000, 11025, 8000, 49716.</param>
        /// <returns>DosBox Speaker configuration to add another configuration</returns>
        public SpeakerOptions AddTandyRate(SampleRate? tandyrate = SampleRate.Rate44100)
        {
            TandyRate = tandyrate;
            return this;
        }

        /// <summary>
        /// Enable Disney Sound Source emulation. (Covox Voice Master and Speech Thing compatible).
        /// </summary>
        /// <param name="disney">Enable Disney Sound Source emulation. (Covox Voice Master and Speech Thing compatible).</param>
        /// <returns>DosBox Speaker configuration to add another configuration</returns>
        public SpeakerOptions AddDisney(bool? disney = true)
        {
            Disney = disney;
            return this;
        }

        #endregion "Fluent"

        #region "String"

        /// <summary>
        /// Cast Speaker options to string
        /// </summary>
        /// <returns>String in INI format</returns>
        public override string ToString()
        {
            var options = new StringBuilder(base.ToString());

            options.CreateIniLine("pcspeaker", PCSpeaker);
            options.CreateIniLine("pcrate", PCRate);
            options.CreateIniLine("tandy", Tandy);
            options.CreateIniLine("tandyrate", TandyRate);
            options.CreateIniLine("disney", Disney);

            return options.ToString();
        }

        #endregion "String"

        #region "BaseOptions"

        /// <summary>
        /// Load Speaker options values from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary with options Speaker data</param>
        public override void LoadDictionary(IDictionary<string, object> dictionary)
        {
            foreach (var data in dictionary)
            {
                switch (data.Key)
                {
                    case "pcspeaker":
                        PCSpeaker = SimpleIniParse.GetBool(data.Value);
                        break;

                    case "pcrate":
                        PCRate = SimpleIniParse.GetEnum<SampleRate>(data.Value);
                        break;

                    case "tandy":
                        Tandy = SimpleIniParse.GetEnum<OnOffAuto>(data.Value);
                        break;

                    case "tandyrate":
                        TandyRate = SimpleIniParse.GetEnum<SampleRate>(data.Value);
                        break;

                    case "disney":
                        Disney = SimpleIniParse.GetBool(data.Value);
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion "BaseOptions"
    }
}
