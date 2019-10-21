using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    public class Serial
    {
        protected Serial()
        {

        }

        public SerialDevice Device { get; protected set; }

        public string RealPort { get; protected set; }

        public uint? Port { get; protected set; }

        public string Server { get; protected set; }

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

        public static Serial CreateDisabled()
        {
            return new Serial
            {
                Device = SerialDevice.Disabled
            };
        }

        public static Serial CreateDummy()
        {
            return new Serial
            {
                Device = SerialDevice.Dummy
            };
        }

        public static Serial CreateModem(uint? listenport = null)
        {
            return new Serial
            {
                Device = SerialDevice.Modem,
                Port = listenport
            };
        }

        public static Serial CreateNullModem(uint? port = null, string server = null)
        {
            return new Serial
            {
                Device = SerialDevice.NullModem,
                Port = port,
                Server = server
            };
        }

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
    }
}
