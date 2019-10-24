using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TioRACLab.DosBox.Options;

namespace TioRACLab.DosBox
{
    /// <summary>
    /// Easy start DosBox
    /// </summary>
    public class DosBoxStarter
    {
        #region "Constructions"

        /// <summary>
        /// Create DosBox launcher 
        /// </summary>
        /// <param name="filename">DosBox application file name</param>
        protected DosBoxStarter(string filename)
        {
            Process = new DosBoxProcess(filename);
        }

        #endregion "Constructions"

        #region "Properties"

        /// <summary>
        /// Process to start dosbox application
        /// </summary>
        protected DosBoxProcess Process { get; set; }

        /// <summary>
        /// Optional configuration to start application
        /// </summary>
        protected DosBoxConfiguration Configuration { get; set; }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create DosBox launcher
        /// </summary>
        /// <param name="filename">DosBox application file name</param>
        /// <returns>DosBox launcher</returns>
        public static DosBoxStarter FromProcess(string filename)
        {
            return new DosBoxStarter(filename);
        }

        /// <summary>
        /// Edit DosBox application startup parameters 
        /// </summary>
        /// <param name="parameters">DosBox Parameters</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter WithParameters(Action<DosBoxParameters> parameters)
        {
            if (parameters != null)
                parameters.Invoke(Process.Parameters);

            return this;
        }

        /// <summary>
        /// Create configuration to add options
        /// </summary>
        /// <returns>DosBox configurations</returns>
        protected DosBoxConfiguration WithConfiguration()
        {
            if (Configuration == null)
                Configuration = new DosBoxConfiguration();

            return Configuration;
        }

        /// <summary>
        /// Edit SDL Options to DosBox application
        /// </summary>
        /// <param name="options">SDL Options</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter WithSdlOptions(Action<SdlOptions> options)
        {
            if (options != null)
                options.Invoke(WithConfiguration().SDL);

            return this;
        }

        /// <summary>
        /// Edit DosBox Options to DosBox application
        /// </summary>
        /// <param name="options">DosBox Options</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter WithDosBoxOptions(Action<DosBoxOptions> options)
        {
            if (options != null)
                options.Invoke(WithConfiguration().DosBox);

            return this;
        }

        /// <summary>
        /// Edit Render Options to DosBox application
        /// </summary>
        /// <param name="options">Render Options</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter WithRenderOptions(Action<RenderOptions> options)
        {
            if (options != null)
                options.Invoke(WithConfiguration().Render);

            return this;
        }

        /// <summary>
        /// Edit CPU Options to DosBox application
        /// </summary>
        /// <param name="options">CPU Options</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter WithCPUOptions(Action<CPUOptions> options)
        {
            if (options != null)
                options.Invoke(WithConfiguration().CPU);

            return this;
        }

        /// <summary>
        /// Edit Mixer Options to DosBox application
        /// </summary>
        /// <param name="options">Mixer Options</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter WithMixerOptions(Action<MixerOptions> options)
        {
            if (options != null)
                options.Invoke(WithConfiguration().Mixer);

            return this;
        }

        /// <summary>
        /// Edit Midi Options to DosBox application
        /// </summary>
        /// <param name="options">Midi Options</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter WithMidiOptions(Action<MidiOptions> options)
        {
            if (options != null)
                options.Invoke(WithConfiguration().Midi);

            return this;
        }

        /// <summary>
        /// Edit SoundBlaster Options to DosBox application
        /// </summary>
        /// <param name="options">SoundBlaster Options</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter WithSoundBlasterOptions(Action<SoundBlasterOptions> options)
        {
            if (options != null)
                options.Invoke(WithConfiguration().SoundBlaster);

            return this;
        }

        /// <summary>
        /// Edit GUS Options to DosBox application
        /// </summary>
        /// <param name="options">GUS Options</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter WithGUSOptions(Action<GusOptions> options)
        {
            if (options != null)
                options.Invoke(WithConfiguration().GUS);

            return this;
        }

        /// <summary>
        /// Edit Speaker Options to DosBox application
        /// </summary>
        /// <param name="options">Speaker Options</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter WithSpeakerOptions(Action<SpeakerOptions> options)
        {
            if (options != null)
                options.Invoke(WithConfiguration().Speaker);

            return this;
        }

        /// <summary>
        /// Edit Joystick Options to DosBox application
        /// </summary>
        /// <param name="options">Joystick Options</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter WithJoystickOptions(Action<JoystickOptions> options)
        {
            if (options != null)
                options.Invoke(WithConfiguration().Joystick);

            return this;
        }

        /// <summary>
        /// Edit Serial Options to DosBox application
        /// </summary>
        /// <param name="options">Serial Options</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter WithSerialOptions(Action<SerialOptions> options)
        {
            if (options != null)
                options.Invoke(WithConfiguration().Serial);

            return this;
        }

        /// <summary>
        /// Edit DOS Options to DosBox application
        /// </summary>
        /// <param name="options">DOS Options</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter WithDOSOptions(Action<DosOptions> options)
        {
            if (options != null)
                options.Invoke(WithConfiguration().DOS);

            return this;
        }

        /// <summary>
        /// Edit IPX Options to DosBox application
        /// </summary>
        /// <param name="options">IPX Options</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter WithIPXOptions(Action<IPXOptions> options)
        {
            if (options != null)
                options.Invoke(WithConfiguration().IPX);

            return this;
        }

        /// <summary>
        /// Edit Autoexec Options to DosBox application
        /// </summary>
        /// <param name="options">Autoexec Options</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter WithAutoexecOptions(Action<AutoexecOptions> options)
        {
            if (options != null)
                options.Invoke(WithConfiguration().Autoexec);

            return this;
        }

        /// <summary>
        /// Start DosBox application
        /// </summary>
        /// <returns>Process of DosBox Application</returns>
        public DosBoxProcess Start()
        {
            if (Configuration != null)
                AddStarterConfiguration();
            
            Process.Start();
            return Process;
        }

        /// <summary>
        /// Start and wait for end DosBox Application
        /// </summary>
        public void StartAndWait()
        {
            using (Process)
            {
                this.Start().WaitEndDosBox();
            }
        }

        #endregion "Fluent"

        #region "Methods"

        /// <summary>
        /// Create configuratopn file and add to parameters
        /// </summary>
        protected void AddStarterConfiguration()
        {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "temp");

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var filename = Path.Combine(directory, "starterconfig.conf");

            Configuration.SaveAsFile(filename, true);

            WithParameters(p => p.AddConfiguration(filename));
        }

        #endregion "Methods"
    }
}
