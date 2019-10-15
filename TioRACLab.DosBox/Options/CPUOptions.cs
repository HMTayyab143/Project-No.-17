using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// <para>The CPU section controls how DOSBox tries to emulate the CPU, how fast the emulation should be, and to adjust it. DOSBox offers 4 different methods of CPU emulation.</para>
    /// <para>See more in <a href="https://www.dosbox.com/wiki/Configuration:CPU">CPU Configuriotn DOSBox</a> Wiki page</para>
    /// </summary>
    public class CPUOptions : BaseOptions
    {
        #region "Constructions"

        /// <summary>
        /// Create instance of CPU options class
        /// </summary>
        public CPUOptions()
            : base("cpu")
        {
        }

        #endregion "Constructions"

        #region "Fields"

        private CPUCore? _core;
        private CPUType? _cputype;
        private CPUCycles? _cycles;
        private uint? _cycleup;
        private uint? _cycledown;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// CPU core used in emulation. The choices result in a different efficency of DOSBox and in very rare cases have an effect on stability. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public CPUCore? Core
        {
            get
            {
                return _core;
            }
            set
            {
                _core = value;
                OnPropertyChanged("Core");
            }
        }

        /// <summary>
        /// CPU Type used in emulation. auto is the fastest choice. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public CPUType? CPUType
        {
            get
            {
                return _cputype;
            }
            set
            {
                _cputype = value;
                OnPropertyChanged("CPUType");
            }
        }

        /// <summary>
        /// Amount of instructions DOSBox tries to emulate each millisecond. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public CPUCycles? Cycles
        {
            get
            {
                return _cycles;
            }
            set
            {
                _cycles = value;
                OnPropertyChanged("Cycles");
            }
        }

        /// <summary>
        /// Amount of cycles to increase with keycombo.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public uint? CycleUp
        {
            get
            {
                return _cycleup;
            }
            set
            {
                _cycleup = value;
                OnPropertyChanged("CycleUp");
            }
        }

        /// <summary>
        /// Amount of cycles to decrease with keycombo. 
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public uint? CycleDown
        {
            get
            {
                return _cycledown;
            }
            set
            {
                _cycledown = value;
                OnPropertyChanged("CycleDown");
            }
        }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create a new CPU options for DosBox configuration
        /// </summary>
        /// <returns>CPU options to add another configuration</returns>
        public static CPUOptions Create()
        {
            return new CPUOptions();
        }

        /// <summary>
        /// CPU Core used in emulation. auto will switch to dynamic if available and appropriate.
        /// </summary>
        /// <param name="core">auto, dynamic, normal, simple</param>
        /// <returns>CPU options to add another configuration</returns>
        public CPUOptions AddCore(CPUCore? core = CPUCore.Auto)
        {
            this.Core = core;
            return this;
        }

        /// <summary>
        /// CPU Type used in emulation. auto is the fastest choice.
        /// </summary>
        /// <param name="cputype">auto, 386, 386_slow, 486_slow, pentium_slow, 386_prefetch</param>
        /// <returns>CPU options to add another configuration</returns>
        public CPUOptions AddCPUType(CPUType? cputype = Options.CPUType.Auto)
        {
            CPUType = cputype;
            return this;
        }

        /// <summary>
        /// Amount of instructions DOSBox tries to emulate each millisecond.
        /// </summary>
        /// <param name="cycles">Amount of instructions DOSBox tries to emulate each millisecond.</param>
        /// <returns>CPU options to add another configuration</returns>
        public CPUOptions AddCycles(CPUCycles? cycles = null)
        {
            this.Cycles = cycles;
            return this;
        }

        /// <summary>
        /// Amount of cycles to decrease/increase with keycombos.
        /// </summary>
        /// <param name="cycleup">Amount of cycles to decrease/increase with keycombos.</param>
        /// <returns>CPU options to add another configuration</returns>
        public CPUOptions AddCycleUp(uint? cycleup = 10)
        {
            CycleUp = cycleup;
            return this;
        }

        /// <summary>
        /// Setting it lower than 100 will be a percentage.
        /// </summary>
        /// <param name="cycledown">Setting it lower than 100 will be a percentage.</param>
        /// <returns>CPU options to add another configuration</returns>
        public CPUOptions AddCycleDown(uint? cycledown = 20)
        {
            CycleUp = cycledown;
            return this;
        }

        #endregion "Fluent"

        #region "String"

        /// <summary>
        /// Cast CPU options to string
        /// </summary>
        /// <returns>CPU options ini format</returns>
        public override string ToString()
        {
            var options = new StringBuilder(base.ToString());

            options.CreateIniLine("core", Core);
            options.CreateIniLine("cputype", CPUType);
            options.CreateIniLine("cycles", Cycles);
            options.CreateIniLine("cycleup", CycleUp);
            options.CreateIniLine("cycledown", CycleDown);

            return options.ToString();
        }

        #endregion "String"

        #region "BaseOptions"

        /// <summary>
        /// Load CPU options value from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary with options DosBox data</param>
        public override void LoadDictionary(IDictionary<string, object> dictionary)
        {
            foreach (var data in dictionary)
            {
                switch (data.Key)
                {
                    case "core":
                        Core = SimpleIniParse.GetEnum<CPUCore>(data.Value);
                        break;

                    case "cputype":
                        CPUType = SimpleIniParse.GetEnum<CPUType>(data.Value);
                        break;

                    case "cycles":
                        Cycles = new CPUCycles(data.Value.ToString());
                        break;

                    case "cycleup":
                        CycleUp = SimpleIniParse.GetUInt(data.Value);
                        break;

                    case "cycledown":
                        CycleDown = SimpleIniParse.GetUInt(data.Value);
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion "BaseOptions"
    }
}