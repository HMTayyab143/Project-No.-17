using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TioRAC.DosBox;

namespace TioRAC.DosBoxTest
{
    public class DosBoxParametersTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ToStringTest()
        {
            var parameter = DosBoxParameters.Create()
                .AddName("game.exe")
                .AddExit()
                .AddCommand("dir pasta")
                .AddFullscreen()
                .AddUserConf()
                .AddConfiguration("jogo.conf")
                .AddLanguages("lang.conf")
                .AddMachine("cga")
                .AddNoConsole()
                .AddStartMapper()
                .AddNoAutoexec()
                .AddSecureMode()
                .AddScaler()
                .AddForceScaler()
                .AddVersion()
                .AddEditConf("myEditConfig")
                .AddOpenCaptures("capture")
                .AddPrintConf()
                .AddResetConf()
                .AddResetMapper()
                .AddSocket();

            Assert.AreEqual(parameter.ToString(),
                "\"game.exe\" -exit -c \"dir pasta\" -fullscreen -userconf -conf \"jogo.conf\" -lang \"lang.conf\" -machine cga -noconsole -startmapper -noautoexec -securemode -scaler -forcescaler -version -editconf \"myEditConfig\" -opencaptures \"capture\" -printconf -resetconf -resetmapper -socket");
        }

        [Test]
        public void FromString()
        {
            var parameters = "game.exe -exit -c \"dir pasta\" -fullscreen -userconf -conf jogo.conf -lang lang.conf -machine cga -noconsole -startmapper -noautoexec -securemode -scaler -forcescaler -version -editconf myEditConfig -opencaptures capture -printconf -resetconf -resetmapper -socket";
            var test = DosBoxParameters.FromString(parameters);

            Assert.IsTrue(test.Exit);
            Assert.IsTrue(test.Fullscreen);
            Assert.IsTrue(test.UserConf);
            Assert.IsTrue(test.NoConsole);
            Assert.IsTrue(test.StartMapper);
            Assert.IsTrue(test.NoAutoexec);
            Assert.IsTrue(test.SecureMode);
            Assert.IsTrue(test.Scaler);
            Assert.IsTrue(test.ForceScaler);
            Assert.IsTrue(test.Version);
            Assert.IsTrue(test.PrintConf);
            Assert.IsTrue(test.ResetConf);
            Assert.IsTrue(test.ResetMapper);
            Assert.IsTrue(test.Socket);

            Assert.Contains("dir pasta", test.Commands);
            Assert.Contains("jogo.conf", test.Configurations);
            Assert.Contains("lang.conf", test.Languages);
            Assert.Contains("myEditConfig", test.EditConfs);

            Assert.AreEqual(test.Name, "game.exe");
            Assert.AreEqual(test.Machine, "cga");
            Assert.AreEqual(test.OpenCaptures, "capture");
        }

        [Test]
        public void CastTest()
        {
            string startParameters = "\"c:\\Program Files\\game\\game.exe\" -exit -c \"dir pasta\" -fullscreen -userconf -conf \"jogo.conf\" -lang \"lang.conf\" -machine cga -noconsole -startmapper -noautoexec -securemode -scaler -forcescaler -version -editconf \"myEditConfig\" -opencaptures \"capture\" -printconf -resetconf -resetmapper -socket";
            DosBoxParameters dosBoxParameters = startParameters;
            string endParameters = dosBoxParameters;

            Assert.AreEqual(startParameters, endParameters);
        }
    }
}
