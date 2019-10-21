using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// <para>Serial Options for DosBox</para>
    /// <para>See more in <a href="https://www.dosbox.com/wiki/Configuration:SerialPort">Serial Port Configuriotn SDL</a> Wiki page</para>
    /// </summary>
    public class SerialOptions : BaseOptions
    {
        #region "Constructions"

        /// <summary>
        /// Create instance of Serial options class
        /// </summary>
        public SerialOptions()
            : base("serial")
        {

        }

        #endregion "Constructions"

        #region "Fields"

        private Serial _serial1;
        private Serial _serial2;
        private Serial _serial3;
        private Serial _serial4;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// Set Serial 1.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public Serial Serial1
        {
            get
            {
                return _serial1;
            }
            set
            {
                _serial1 = value;
                OnPropertyChanged("Serial1");
            }
        }

        /// <summary>
        /// Set Serial 2.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public Serial Serial2
        {
            get
            {
                return _serial2;
            }
            set
            {
                _serial2 = value;
                OnPropertyChanged("Serial2");
            }
        }

        /// <summary>
        /// Set Serial 3.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public Serial Serial3
        {
            get
            {
                return _serial3;
            }
            set
            {
                _serial3 = value;
                OnPropertyChanged("Serial3");
            }
        }

        /// <summary>
        /// Set Serial 4.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public Serial Serial4
        {
            get
            {
                return _serial4;
            }
            set
            {
                _serial4 = value;
                OnPropertyChanged("Serial4");
            }
        }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create a new Serial Options for DosBox configuration
        /// </summary>
        /// <returns>DosBox Serial configuration to add another configuration</returns>
        public static SerialOptions Create()
        {
            return new SerialOptions();
        }

        /// <summary>
        /// Add Serial 1.
        /// </summary>
        /// <param name="serial">Serial 1.</param>
        /// <returns>DosBox Serial configuration to add another configuration</returns>
        public SerialOptions AddSerial1(Serial serial = null)
        {
            Serial1 = serial;
            return this;
        }

        /// <summary>
        /// Add Serial 2.
        /// </summary>
        /// <param name="serial">Serial 2.</param>
        /// <returns>DosBox Serial configuration to add another configuration</returns>
        public SerialOptions AddSerial2(Serial serial = null)
        {
            Serial2 = serial;
            return this;
        }

        /// <summary>
        /// Add Serial 3.
        /// </summary>
        /// <param name="serial">Serial 3.</param>
        /// <returns>DosBox Serial configuration to add another configuration</returns>
        public SerialOptions AddSerial3(Serial serial = null)
        {
            Serial3 = serial;
            return this;
        }

        /// <summary>
        /// Add Serial 4.
        /// </summary>
        /// <param name="serial">Serial 4.</param>
        /// <returns>DosBox Serial configuration to add another configuration</returns>
        public SerialOptions AddSerial4(Serial serial = null)
        {
            Serial4 = serial;
            return this;
        }

        #endregion "Fluent"

        #region "String"

        /// <summary>
        /// Cast Serial options to string
        /// </summary>
        /// <returns>String in INI format</returns>
        public override string ToString()
        {
            var options = new StringBuilder(base.ToString());

            options.CreateIniLine("serial1", Serial1);
            options.CreateIniLine("serial2", Serial2);
            options.CreateIniLine("serial3", Serial3);
            options.CreateIniLine("serial4", Serial4);

            return options.ToString();
        }

        #endregion "String"

        #region "BaseOptions"

        /// <summary>
        /// Load Serial options values from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary with options Serial data</param>
        public override void LoadDictionary(IDictionary<string, object> dictionary)
        {
            foreach (var data in dictionary)
            {
                switch (data.Key)
                {
                    case "serial1":
                        Serial1 = Serial.Create(data.Value.ToString());
                        break;

                    case "serial2":
                        Serial2 = Serial.Create(data.Value.ToString());
                        break;

                    case "serial3":
                        Serial3 = Serial.Create(data.Value.ToString());
                        break;

                    case "serial4":
                        Serial4 = Serial.Create(data.Value.ToString());
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion "BaseOptions"
    }
}
