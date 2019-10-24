using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// The DosBox configurations class
    /// </summary>
    public class DosBoxConfiguration
    {
        #region "Constructions"

        /// <summary>
        /// Create empty DosBox configurations
        /// </summary>
        public DosBoxConfiguration()
        {
            SDL = new SdlOptions();
            DosBox = new DosBoxOptions();
            Render = new RenderOptions();
            CPU = new CPUOptions();
            Mixer = new MixerOptions();
            Midi = new MidiOptions();
            SoundBlaster = new SoundBlasterOptions();
            GUS = new GusOptions();
            Speaker = new SpeakerOptions();
            Joystick = new JoystickOptions();
            Serial = new SerialOptions();
            DOS = new DosOptions();
            IPX = new IPXOptions();
            Autoexec = new AutoexecOptions();
        }

        /// <summary>
        /// Create from dosbox config string
        /// </summary>
        /// <param name="config">String with dosbox configuration</param>
        public DosBoxConfiguration(string config)
            : this()
        {
            var dictionary = SimpleIniParse.ReadIniOptions(config);
            LoadDictionary(dictionary);
        }

        /// <summary>
        /// Create from dictionary with config data
        /// </summary>
        /// <param name="dictionary">dictionary with config data</param>
        public DosBoxConfiguration(IDictionary<string, object> dictionary)
            : this()
        {
            LoadDictionary(dictionary);
        }

        #endregion "Constructions"

        #region "Properties"

        /// <summary>
        /// This section contains all of the low level system settings for how DOSBox interacts with your real hardware.
        /// </summary>
        public SdlOptions SDL { get; set; }

        /// <summary>
        /// The [dosbox] section contains various settings that do not pertain to any other section
        /// </summary>
        public DosBoxOptions DosBox { get; set; }

        /// <summary>
        /// The rendering (drawing) section controls methods that DOSBox uses to improve the speed and quality of the graphics displayed on the screen.
        /// </summary>
        public RenderOptions Render { get; set; }

        /// <summary>
        /// The CPU section controls how DOSBox tries to emulate the CPU, how fast the emulation should be, and to adjust it.
        /// </summary>
        public CPUOptions CPU { get; set; }

        /// <summary>
        /// Here you can define the quality of emulated audio. 
        /// </summary>
        public MixerOptions Mixer { get; set; }

        /// <summary>
        /// Here you can define any MIDI related settings.
        /// </summary>
        public MidiOptions Midi { get; set; }

        /// <summary>
        /// Sound Blaster related settings. 
        /// </summary>
        public SoundBlasterOptions SoundBlaster { get; set; }

        /// <summary>
        /// Gravis Ultra Sound related settings. 
        /// </summary>
        public GusOptions GUS { get; set; }

        /// <summary>
        /// PC Speaker related settings. 
        /// </summary>
        public SpeakerOptions Speaker { get; set; }

        /// <summary>
        /// Joystick related settings. 
        /// </summary>
        public JoystickOptions Joystick { get; set; }

        /// <summary>
        /// Serial port related settings. 
        /// </summary>
        public SerialOptions Serial { get; set; }

        /// <summary>
        /// DOS related settings. 
        /// </summary>
        public DosOptions DOS { get; set; }

        /// <summary>
        /// IPX protocol related settings. 
        /// </summary>
        public IPXOptions IPX { get; set; }

        /// <summary>
        /// Here you can define the contents of the AUTOEXEC.BAT file
        /// </summary>
        public AutoexecOptions Autoexec { get; set; }

        #endregion "Properties"

        #region "String"

        /// <summary>
        /// Cast the configuration to string format
        /// </summary>
        /// <returns>String DosBox configuration format</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(SDL?.ToString());
            sb.AppendLine(DosBox?.ToString());
            sb.AppendLine(Render?.ToString());
            sb.AppendLine(CPU?.ToString());
            sb.AppendLine(Mixer?.ToString());
            sb.AppendLine(Midi?.ToString());
            sb.AppendLine(SoundBlaster?.ToString());
            sb.AppendLine(GUS?.ToString());
            sb.AppendLine(Speaker?.ToString());
            sb.AppendLine(Joystick?.ToString());
            sb.AppendLine(Serial?.ToString());
            sb.AppendLine(DOS?.ToString());
            sb.AppendLine(IPX?.ToString());
            sb.Append(Autoexec?.ToString());

            return sb.ToString();
        }

        #endregion "String"

        #region "Loads"

        /// <summary>
        /// Load the default DosBox configuration
        /// </summary>
        /// <returns>DosBoxConfiguration data</returns>
        public DosBoxConfiguration LoadDeafult()
        {
            SDL.AddAutoLock()
                .AddFullDouble()
                .AddFullResolution(Resolution.Original)
                .AddFullScreen()
                .AddOutput(VideoOutput.Surface)
                .AddPriorityFocused()
                .AddPriorityMinimized()
                .AddSensitivity()
                .AddUseScanCodes()
                .AddWaitOnError()
                .AddWindowResolution(Resolution.Original);

            DosBox.AddCaptures()
                .AddMachine()
                .AddMemSize();

            Render.AddAspect()
                .AddFrameskip()
                .AddScaler(ScalerType.Normal2x);

            CPU.AddCore()
                .AddCPUType()
                .AddCycles(new CPUCycles("auto"))
                .AddCycleUp()
                .AddCycleDown();

            Mixer.AddNoSound()
                .AddRate()
                .AddBlockSize()
                .AddPreBuffer();

            Midi.AddMPU401()
                .AddMidiDevice();

            SoundBlaster.AddSBType()
                .AddSBBase()
                .AddIRQ()
                .AddDMA()
                .AddHDMA()
                .AddSoundMixer()
                .AddOplMode()
                .AddOplEmu()
                .AddOplRate();

            GUS.AddGUS()
                .AddGusRate()
                .AddGusBase()
                .AddGusIRQ()
                .AddGusDMA()
                .AddUltraDir();

            Speaker.AddPCSpeaker()
                .AddPCRate()
                .AddTandy()
                .AddTandyRate()
                .AddDisney();

            Joystick.AddJoystickType()
                .AddTimed()
                .AddAutoFire()
                .AddSwap34()
                .AddButtonWrap();

            Serial.AddSerial1(Options.Serial.CreateDummy())
                .AddSerial2(Options.Serial.CreateDummy())
                .AddSerial3(Options.Serial.CreateDisabled())
                .AddSerial4(Options.Serial.CreateDisabled());

            DOS.AddXMS()
                .AddEMS()
                .AddUMB()
                .AddKeyboardLayout(KeyboardLayout.Auto);

            IPX.AddIPX();

            return this;
        }

        /// <summary>
        /// Load configuration from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary with dosbox configuration data.</param>
        /// <returns>DosBoxConfiguration data</returns>
        public DosBoxConfiguration LoadDictionary(IDictionary<string, object> dictionary)
        {
            foreach (var keyValue in dictionary)
            {
                switch (keyValue.Key)
                {
                    case "sdl":
                        if (keyValue.Value is IDictionary<string, object>)
                            SDL.LoadDictionary(keyValue.Value as IDictionary<string, object>);
                        break;

                    case "dosbox":
                        if (keyValue.Value is IDictionary<string, object>)
                            DosBox.LoadDictionary(keyValue.Value as IDictionary<string, object>);
                        break;

                    case "render":
                        if (keyValue.Value is IDictionary<string, object>)
                            Render.LoadDictionary(keyValue.Value as IDictionary<string, object>);
                        break;

                    case "cpu":
                        if (keyValue.Value is IDictionary<string, object>)
                            CPU.LoadDictionary(keyValue.Value as IDictionary<string, object>);
                        break;

                    case "mixer":
                        if (keyValue.Value is IDictionary<string, object>)
                            Mixer.LoadDictionary(keyValue.Value as IDictionary<string, object>);
                        break;

                    case "midi":
                        if (keyValue.Value is IDictionary<string, object>)
                            Midi.LoadDictionary(keyValue.Value as IDictionary<string, object>);
                        break;

                    case "sblaster":
                        if (keyValue.Value is IDictionary<string, object>)
                            SoundBlaster.LoadDictionary(keyValue.Value as IDictionary<string, object>);
                        break;

                    case "gus":
                        if (keyValue.Value is IDictionary<string, object>)
                            GUS.LoadDictionary(keyValue.Value as IDictionary<string, object>);
                        break;

                    case "speaker":
                        if (keyValue.Value is IDictionary<string, object>)
                            Speaker.LoadDictionary(keyValue.Value as IDictionary<string, object>);
                        break;

                    case "joystick":
                        if (keyValue.Value is IDictionary<string, object>)
                            Joystick.LoadDictionary(keyValue.Value as IDictionary<string, object>);
                        break;

                    case "serial":
                        if (keyValue.Value is IDictionary<string, object>)
                            Serial.LoadDictionary(keyValue.Value as IDictionary<string, object>);
                        break;

                    case "dos":
                        if (keyValue.Value is IDictionary<string, object>)
                            DOS.LoadDictionary(keyValue.Value as IDictionary<string, object>);
                        break;

                    case "ipx":
                        if (keyValue.Value is IDictionary<string, object>)
                            IPX.LoadDictionary(keyValue.Value as IDictionary<string, object>);
                        break;

                    case "autoexec":
                        if (keyValue.Value is IDictionary<string, object>)
                            Autoexec.LoadDictionary(keyValue.Value as IDictionary<string, object>);
                        break;

                    default:
                        break;
                }
            }

            return this;
        }

        /// <summary>
        /// Load configuration from file
        /// </summary>
        /// <param name="file">DosBox configuration file name</param>
        /// <returns>DosBoxConfiguration data</returns>
        public static DosBoxConfiguration LoadFromFile(string file)
        {
            if (File.Exists(file))
            {
                var configFile = File.ReadAllText(file);
                return new DosBoxConfiguration(configFile);
            }

            return new DosBoxConfiguration();
        }

        #endregion "Loads"

        #region "Save"

        /// <summary>
        /// Save configuration as file
        /// </summary>
        /// <param name="file">File name</param>
        /// <param name="overwrite">Overwrite file exists</param>
        public void SaveAsFile(string file, bool overwrite = false)
        {
            if (File.Exists(file))
            {
                if (!overwrite)
                    throw new IOException("File exists");

                File.Delete(file);
            }

            File.WriteAllText(file, this.ToString());
        }

        #endregion "Save"
    }
}
