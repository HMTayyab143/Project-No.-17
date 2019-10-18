using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// <para>Here you can define the quality of emulated audio.</para>
    /// <para>See more in <a href="https://www.dosbox.com/wiki/Sound">Sound DoSBox</a> Wiki page</para>
    /// </summary>
    public class MixerOptions : BaseOptions
    {
        #region "Constructions"

        /// <summary>
        /// Create instance of Mixer options class
        /// </summary>
        public MixerOptions()
            : base("mixer")
        {
        }

        #endregion "Constructions"

        #region "Fields"

        private bool? _nosound;
        private SampleRate? _rate;
        private MixerBlockSize? _blocksize;
        private uint? _prebuffer;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// Enable silent mode, sound is still emulated though.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? NoSound
        {
            get
            {
                return _nosound;
            }
            set
            {
                _nosound = value;
                OnPropertyChanged("NoSound");
            }
        }

        /// <summary>
        /// Mixer sample rate, setting any device's rate higher than this will probably lower their sound quality.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public SampleRate? Rate
        {
            get
            {
                return _rate;
            }
            set
            {
                _rate = value;
                OnPropertyChanged("Rate");
            }
        }

        /// <summary>
        /// Mixer block size, larger blocks might help sound stuttering but sound will also be more lagged.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public MixerBlockSize? BlockSize
        {
            get
            {
                return _blocksize;
            }
            set
            {
                _blocksize = value;
                OnPropertyChanged("BlockSize");
            }
        }

        /// <summary>
        /// How many milliseconds of data to keep on top of the blocksize.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public uint? PreBuffer
        {
            get
            {
                return _prebuffer;
            }
            set
            {
                _prebuffer = value;
                OnPropertyChanged("PreBuffer");
            }
        }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create a new Mixer options for DosBox configuration
        /// </summary>
        /// <returns>Mixer options to add another configuration</returns>
        public static MixerOptions Create()
        {
            return new MixerOptions();
        }

        /// <summary>
        /// Enable silent mode, sound is still emulated though.
        /// </summary>
        /// <param name="nosound">Enable silent mode, sound is still emulated though.</param>
        /// <returns></returns>
        public MixerOptions AddNoSound(bool? nosound = false)
        {
            NoSound = nosound;
            return this;
        }

        /// <summary>
        /// Mixer sample rate, setting any device's rate higher than this will probably lower their sound quality.
        /// </summary>
        /// <param name="rate">Possible values: 44100, 48000, 32000, 22050, 16000, 11025, 8000, 49716.</param>
        /// <returns>Mixer options to add another configuration</returns>
        public MixerOptions AddRate(SampleRate? rate = SampleRate.Rate44100)
        {
            Rate = rate;
            return this;
        }

        /// <summary>
        /// Mixer block size, larger blocks might help sound stuttering but sound will also be more lagged.
        /// </summary>
        /// <param name="blocksize">Possible values: 1024, 2048, 4096, 8192, 512, 256.</param>
        /// <returns>Mixer options to add another configuration</returns>
        public MixerOptions AddBlockSize(MixerBlockSize? blocksize = MixerBlockSize.Block1024)
        {
            BlockSize = blocksize;
            return this;
        }

        /// <summary>
        /// How many milliseconds of data to keep on top of the blocksize.
        /// </summary>
        /// <param name="prebuffer">How many milliseconds of data to keep on top of the blocksize.</param>
        /// <returns>Mixer options to add another configuration</returns>
        public MixerOptions AddPreBuffer(uint? prebuffer = 25)
        {
            PreBuffer = prebuffer;
            return this;
        }

        #endregion "Fluent"

        #region "String"

        /// <summary>
        /// Cast Mixer options to string
        /// </summary>
        /// <returns>Mixer options ini format</returns>
        public override string ToString()
        {
            var options = new StringBuilder(base.ToString());

            options.CreateIniLine("nosound", NoSound);
            options.CreateIniLine("rate", Rate);
            options.CreateIniLine("blocksize", BlockSize);
            options.CreateIniLine("prebuffer", PreBuffer);

            return options.ToString();
        }

        #endregion "String"

        #region "BaseOptions"

        /// <summary>
        /// Load Mixer options value from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary with options DosBox data</param>
        public override void LoadDictionary(IDictionary<string, object> dictionary)
        {
            foreach (var data in dictionary)
            {
                switch (data.Key)
                {
                    case "nosound":
                        NoSound = SimpleIniParse.GetBool(data.Value);
                        break;

                    case "rate":
                        Rate = SimpleIniParse.GetEnum<SampleRate>(data.Value);
                        break;

                    case "blocksize":
                        BlockSize = SimpleIniParse.GetEnum<MixerBlockSize>(data.Value);
                        break;

                    case "prebuffer":
                        PreBuffer = SimpleIniParse.GetUInt(data.Value);
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion "BaseOptions"
    }
}
