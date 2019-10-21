using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// Serial Config
    /// </summary>
    public class Serial
    {
        #region "Constructions"

        /// <summary>
        /// Create a serial class instance
        /// </summary>
        protected Serial()
        {

        }

        #endregion "Constructions"

        #region "Properties"

        /// <summary>
        /// Serial device type
        /// </summary>
        public SerialDevice Device { get; protected set; }

        /// <summary>
        /// Real computer port
        /// </summary>
        public string RealPort { get; protected set; }

        /// <summary>
        /// TCP port connection
        /// </summary>
        public uint? Port { get; protected set; }

        /// <summary>
        /// Server TCP port connection
        /// </summary>
        public string Server { get; protected set; }

        #endregion "Properties"

        #region "String"

        /// <summary>
        /// Casto Serial to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var serialString = new StringBuilder(Enum.GetName(typeof(SerialDevice), Device).ToLower());

            if (Device == SerialDevice.Modem)
            {
                if (Port != null)
                    serialString.Append($" listenport:{Port}");
            }

            if (Device == SerialDevice.NullModem)
            {
                if (Port != null)
                    serialString.Append($" port:{Port}");

                if (!string.IsNullOrWhiteSpace(Server))
                    serialString.Append($" server:{Server}");
            }

            if (Device == SerialDevice.DirectSerial)
            {
                serialString.Append($" realport:{RealPort}");
            }

            return serialString.ToString();
        }

        #endregion "String"

        #region "Create Serial"

        /// <summary>
        /// Create serial config from string
        /// </summary>
        /// <param name="serial">String serial config</param>
        /// <returns></returns>
        public static Serial Create(string serial)
        {
            if (string.IsNullOrWhiteSpace(serial))
                return null;

            var serialParts = serial.Split(' ');
            var device = serialParts[0];

            switch (device.ToLower())
            {
                case "disabled":
                    return CreateDisabled();

                case "dummy":
                    return CreateDummy();

                case "modem":
                    uint? listenport = null;

                    foreach (var part in serialParts)
                    {
                        if (part.ToLower().StartsWith("listenport:"))
                        {
                            if (uint.TryParse(part.Replace("listenport:", ""), out uint l))
                                listenport = l;

                            break;
                        }
                    }

                    return CreateModem(listenport);

                case "nullmodem":
                    uint? port = null;
                    string server = null;

                    foreach (var part in serialParts)
                    {
                        if (part.ToLower().StartsWith("port:")
                            && uint.TryParse(part.Replace("port:", ""), out uint p))
                            port = p;

                        if (part.ToLower().StartsWith("server:"))
                            server = part.Replace("server:", "");
                    }


                    return CreateNullModem(port, server);

                case "directserial":
                    string realport = null;

                    foreach (var part in serialParts)
                    {
                        if (part.ToLower().StartsWith("realport:"))
                        {
                            realport = part.Replace("realport:", "");
                            break;
                        }
                    }

                    return CreateDirectSerial(realport);

                default:
                    return null;
            }
        }

        /// <summary>
        /// Create serial of type Disabled
        /// </summary>
        /// <returns>Serial Disabled</returns>
        public static Serial CreateDisabled()
        {
            return new Serial
            {
                Device = SerialDevice.Disabled
            };
        }

        /// <summary>
        /// Create serial of type Dummy
        /// </summary>
        /// <returns>Serial Dummy</returns>
        public static Serial CreateDummy()
        {
            return new Serial
            {
                Device = SerialDevice.Dummy
            };
        }

        /// <summary>
        /// Create serial of type Modem
        /// </summary>
        /// <param name="listenport">Listen TCP/UDP port</param>
        /// <returns>Serial Modem</returns>
        public static Serial CreateModem(uint? listenport = null)
        {
            return new Serial
            {
                Device = SerialDevice.Modem,
                Port = listenport
            };
        }

        /// <summary>
        /// Create serial of type NullModem
        /// </summary>
        /// <param name="port">TCP/UDP Port</param>
        /// <param name="server">Server IP or dns name</param>
        /// <returns>Serial NullModem</returns>
        public static Serial CreateNullModem(uint? port = null, string server = null)
        {
            return new Serial
            {
                Device = SerialDevice.NullModem,
                Port = port,
                Server = server
            };
        }

        /// <summary>
        /// Create serial of type Direct Serial
        /// </summary>
        /// <param name="realport">Serial real port name</param>
        /// <returns>Serial DirectSerial</returns>
        public static Serial CreateDirectSerial(string realport)
        {
            if (string.IsNullOrWhiteSpace(realport))
                realport = "COM1";

            return new Serial
            {
                Device = SerialDevice.DirectSerial,
                RealPort = realport
            };
        }

        #endregion "Create Serial"
    }
}
