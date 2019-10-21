using NUnit.Framework;
using TioRACLab.DosBox.Options;
using System.Collections.Generic;

namespace TioRACLab.DosBoxTest.Options
{
    public class SerialOptionsTest
    {
        [Test]
        public void ToStringTest()
        {
            var serial = SerialOptions.Create()
                .AddSerial1(Serial.CreateDummy())
                .AddSerial2(Serial.CreateModem(333))
                .AddSerial3(Serial.CreateNullModem(222, "localhost"))
                .AddSerial4(Serial.CreateDirectSerial("COM5"));

            var iniSerial = serial.ToString();

            Assert.AreEqual(iniSerial, "[serial]\r\n\r\nserial1=dummy\r\nserial2=modem listenport:333\r\nserial3=nullmodem port:222 server:localhost\r\nserial4=directserial realport:COM5\r\n");
        }

        [Test]
        public void LoadDictionaryTest()
        {
            SerialOptions serial = new SerialOptions();
            var dictionary = new Dictionary<string, object>()
            {
                {"serial1", "dummy"},
                {"serial2", "modem listenport:333"},
                {"serial3", "nullmodem port:222 server:localhost"},
                {"serial4", "directserial realport:COM5"}
            };

            serial.LoadDictionary(dictionary);

            Assert.AreEqual(serial.Serial1.Device, SerialDevice.Dummy);
            
            Assert.AreEqual(serial.Serial2.Device, SerialDevice.Modem);
            Assert.AreEqual(serial.Serial2.Port, 333);

            Assert.AreEqual(serial.Serial3.Device, SerialDevice.NullModem);
            Assert.AreEqual(serial.Serial3.Port, 222);
            Assert.AreEqual(serial.Serial3.Server, "localhost");

            Assert.AreEqual(serial.Serial4.Device, SerialDevice.DirectSerial);
            Assert.AreEqual(serial.Serial4.RealPort, "COM5");
        }
    }
}
