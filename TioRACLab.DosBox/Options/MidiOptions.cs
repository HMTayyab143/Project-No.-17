using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// <para>Here you can define any MIDI related settings. The term MIDI is commonly used to refer to background music found in games, but specifically it refers to synthesizer audio (which can be passed directly from emulated games to modern hardware.</para>
    /// <para>See more in <a href="https://www.dosbox.com/wiki/Configuration:MIDI">MIDI Configuriotn SDL</a> Wiki page</para>
    /// </summary>
    public class MidiOptions : BaseOptions
    {
        #region "Constructions"

        /// <summary>
        /// Create instance of Midi options class
        /// </summary>
        public MidiOptions()
            : base("midi")
        {

        }

        #endregion "Constructions"

        #region "Fields"

        private MPU401? _mpu401;
        private MidiDevice? _mididevice;
        private string _midiconfig;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// Specifies which type of MIDI Processing Unit to emulate. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public MPU401? MPU401
        {
            get
            {
                return _mpu401;
            }
            set
            {
                _mpu401 = value;
                OnPropertyChanged("MPU401");
            }
        }

        /// <summary>
        /// A slightly confusing config name, because this isn't so much which MIDI device to use as which MIDI interface to use.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public MidiDevice? MidiDevice
        {
            get
            {
                return _mididevice;
            }
            set
            {
                _mididevice = value;
                OnPropertyChanged("MidiDevice");
            }
        }

        /// <summary>
        /// As used by the MIDI interface described above, this specifies the ID which identifies the particular MIDI device to playback MIDI on.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public string MidiConfig
        {
            get
            {
                return _midiconfig;
            }
            set
            {
                _midiconfig = value;
                OnPropertyChanged("MidiConfig");
            }
        }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create a new Midi Options for DosBox configuration
        /// </summary>
        /// <returns>DosBox Midi configuration to add another configuration</returns>
        public static MidiOptions Create()
        {
            return new MidiOptions();
        }

        /// <summary>
        /// ESpecifies which type of MIDI Processing Unit to emulate.
        /// </summary>
        /// <param name="mpu401">Intelligent | Uart | None</param>
        /// <returns>DosBox DOS configuration to add another configuration</returns>
        public MidiOptions AddMPU401(MPU401? mpu401 = Options.MPU401.Intelligent)
        {
            MPU401 = mpu401;
            return this;
        }

        /// <summary>
        /// A slightly confusing config name, because this isn't so much which MIDI device to use as which MIDI interface to use..
        /// </summary>
        /// <param name="mididevice">A slightly confusing config name, because this isn't so much which MIDI device to use as which MIDI interface to use..</param>
        /// <returns>DosBox Midi configuration to add another configuration</returns>
        public MidiOptions AddMidiDevice(MidiDevice? mididevice = Options.MidiDevice.Default)
        {
            MidiDevice = mididevice;
            return this;
        }

        /// <summary>
        /// As used by the MIDI interface described above, this specifies the ID which identifies the particular MIDI device to playback MIDI on.
        /// </summary>
        /// <param name="midiconfig">As used by the MIDI interface described above, this specifies the ID which identifies the particular MIDI device to playback MIDI on.</param>
        /// <returns>DosBox DOS configuration to add another configuration</returns>
        public MidiOptions AddMidiConfig(string midiconfig = null)
        {
            MidiConfig = midiconfig;
            return this;
        }

        #endregion "Fluent"

        #region "String"

        /// <summary>
        /// Cast Midi options to string
        /// </summary>
        /// <returns>String in INI format</returns>
        public override string ToString()
        {
            var options = new StringBuilder(base.ToString());

            options.CreateIniLine("mpu401", MPU401);
            options.CreateIniLine("mididevice", MidiDevice);
            options.CreateIniLine("midiconfig", MidiConfig);

            return options.ToString();
        }

        #endregion "String"

        #region "BaseOptions"

        /// <summary>
        /// Load Midi options values from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary with options Midi data</param>
        public override void LoadDictionary(IDictionary<string, object> dictionary)
        {
            foreach (var data in dictionary)
            {
                switch (data.Key)
                {
                    case "mpu401":
                        MPU401 = SimpleIniParse.GetEnum<MPU401>(data.Value);
                        break;

                    case "mididevice":
                        MidiDevice = SimpleIniParse.GetEnum<MidiDevice>(data.Value);
                        break;

                    case "midiconfig":
                        MidiConfig = data.Value.ToString();
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion "BaseOptions"
    }
}
