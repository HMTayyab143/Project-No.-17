using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// <para>Joystick Options for DosBox</para>
    /// </summary>
    public class JoystickOptions : BaseOptions
    {
        #region "Constructions"

        /// <summary>
        /// Create instance of Joystick options class
        /// </summary>
        public JoystickOptions()
            : base("joystick")
        {

        }

        #endregion "Constructions"

        #region "Fields"

        private Joystick? _joysticktype;
        private bool? _timed;
        private bool? _autofire;
        private bool? _swap34;
        private bool? _buttonwrap;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// Type of joystick to emulate
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public Joystick? JoystickType
        {
            get
            {
                return _joysticktype;
            }
            set
            {
                _joysticktype = value;
                OnPropertyChanged("JoystickType");
            }
        }

        /// <summary>
        /// Enable timed intervals for axis. Experiment with this option, if your joystick drifts (away).
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? Timed
        {
            get
            {
                return _timed;
            }
            set
            {
                _timed = value;
                OnPropertyChanged("Timed");
            }
        }

        /// <summary>
        /// Continuously fires as long as you keep the button pressed.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? AutoFire
        {
            get
            {
                return _autofire;
            }
            set
            {
                _autofire = value;
                OnPropertyChanged("AutoFire");
            }
        }

        /// <summary>
        /// Swap the 3rd and the 4th axis. Can be useful for certain joysticks.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? Swap34
        {
            get
            {
                return _swap34;
            }
            set
            {
                _swap34 = value;
                OnPropertyChanged("Swap34");
            }
        }

        /// <summary>
        /// Enable button wrapping at the number of emulated buttons.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? ButtonWrap
        {
            get
            {
                return _buttonwrap;
            }
            set
            {
                _buttonwrap = value;
                OnPropertyChanged("ButtonWrap");
            }
        }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create a new Joystick Options for DosBox configuration
        /// </summary>
        /// <returns>DosBox Joystick configuration to add another configuration</returns>
        public static JoystickOptions Create()
        {
            return new JoystickOptions();
        }

        /// <summary>
        /// Type of joystick to emulate.
        /// </summary>
        /// <param name="joysticktype">Possible values: auto, 2axis, 4axis, 4axis_2, fcs, ch, none.</param>
        /// <returns>DosBox Joystick configuration to add another configuration</returns>
        public JoystickOptions AddJoystickType(Joystick? joysticktype = Joystick.Auto)
        {
            JoystickType = joysticktype;
            return this;
        }

        /// <summary>
        /// Enable timed intervals for axis. Experiment with this option, if your joystick drifts (away).
        /// </summary>
        /// <param name="timed">Enable timed intervals for axis. Experiment with this option, if your joystick drifts (away).</param>
        /// <returns>DosBox Joystick configuration to add another configuration</returns>
        public JoystickOptions AddTimed(bool? timed = true)
        {
            Timed = timed;
            return this;
        }

        /// <summary>
        /// Continuously fires as long as you keep the button pressed.
        /// </summary>
        /// <param name="autofire">Continuously fires as long as you keep the button pressed.</param>
        /// <returns>DosBox Joystick configuration to add another configuration</returns>
        public JoystickOptions AddAutoFire(bool? autofire = false)
        {
            AutoFire = autofire;
            return this;
        }

        /// <summary>
        /// Swap the 3rd and the 4th axis. Can be useful for certain joysticks.
        /// </summary>
        /// <param name="swap34">Swap the 3rd and the 4th axis. Can be useful for certain joysticks.</param>
        /// <returns>DosBox Joystick configuration to add another configuration</returns>
        public JoystickOptions AddSwap34(bool? swap34 = false)
        {
            Swap34 = swap34;
            return this;
        }

        /// <summary>
        /// Enable button wrapping at the number of emulated buttons.
        /// </summary>
        /// <param name="buttonwrap">Enable button wrapping at the number of emulated buttons.</param>
        /// <returns>DosBox Joystick configuration to add another configuration</returns>
        public JoystickOptions AddButtonWrap(bool? buttonwrap = false)
        {
            ButtonWrap = buttonwrap;
            return this;
        }

        #endregion "Fluent"

        #region "String"

        /// <summary>
        /// Cast Joystick options to string
        /// </summary>
        /// <returns>String in INI format</returns>
        public override string ToString()
        {
            var options = new StringBuilder(base.ToString());

            options.CreateIniLine("joysticktype", JoystickType);
            options.CreateIniLine("timed", Timed);
            options.CreateIniLine("autofire", AutoFire);
            options.CreateIniLine("swap34", Swap34);
            options.CreateIniLine("buttonwrap", ButtonWrap);

            return options.ToString();
        }

        #endregion "String"

        #region "BaseOptions"

        /// <summary>
        /// Load Joystick options values from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary with options Joystick data</param>
        public override void LoadDictionary(IDictionary<string, object> dictionary)
        {
            foreach (var data in dictionary)
            {
                switch (data.Key)
                {
                    case "joysticktype":
                        JoystickType = SimpleIniParse.GetEnum<Joystick>(data.Value);
                        break;

                    case "timed":
                        Timed = SimpleIniParse.GetBool(data.Value);
                        break;

                    case "autofire":
                        AutoFire = SimpleIniParse.GetBool(data.Value);
                        break;

                    case "swap34":
                        Swap34 = SimpleIniParse.GetBool(data.Value);
                        break;

                    case "buttonwrap":
                        ButtonWrap = SimpleIniParse.GetBool(data.Value);
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion "BaseOptions"
    }
}
