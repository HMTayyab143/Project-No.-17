using NUnit.Framework;
using TioRACLab.DosBox.Options;
using System.Collections.Generic;

namespace TioRACLab.DosBoxTest.Options
{
    public class SpeakerOptionsTest
    {
        [Test]
        public void ToStringTest()
        {
            var speaker = SpeakerOptions.Create()
                .AddPCSpeaker()
                .AddPCRate()
                .AddTandy()
                .AddTandyRate()
                .AddDisney();

            var iniSpeaker = speaker.ToString();

            Assert.AreEqual(iniSpeaker, "[speaker]\r\n\r\npcspeaker=true\r\npcrate=44100\r\ntandy=auto\r\ntandyrate=44100\r\ndisney=true\r\n");
        }

        [Test]
        public void LoadDictionaryTest()
        {
            SpeakerOptions speaker = new SpeakerOptions();
            var dictionary = new Dictionary<string, object>()
            {
                {"pcspeaker", "true"},
                {"pcrate", "44100"},
                {"tandy", "auto"},
                {"tandyrate", "44100"},
                {"disney", "true"}
            };

            speaker.LoadDictionary(dictionary);

            Assert.IsTrue(speaker.PCSpeaker);
            Assert.AreEqual(speaker.PCRate, SampleRate.Rate44100);
            Assert.AreEqual(speaker.Tandy, OnOffAuto.Auto);
            Assert.AreEqual(speaker.TandyRate, SampleRate.Rate44100);
            Assert.IsTrue(speaker.Disney);
        }
    }
}
