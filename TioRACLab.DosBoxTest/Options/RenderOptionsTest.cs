using NUnit.Framework;
using TioRACLab.DosBox.Options;
using System.Collections.Generic;

namespace TioRACLab.DosBoxTest.Options
{
    public class RenderOptionsTest
    {
        [Test]
        public void ToStringTest()
        {
            var render = RenderOptions.Create()
                .AddAspect()
                .AddFrameskip()
                .AddScaler(ScalerType.Super2xSai);

            var iniRender = render.ToString();

            Assert.AreEqual(iniRender, "[render]\r\n\r\nframeskip=0\r\naspect=false\r\nscaler=super2xsai\r\n");
        }

        [Test]
        public void LoadDictionaryTest()
        {
            var render = new RenderOptions();
            var dictionary = new Dictionary<string, object>()
            {
                {"frameskip", "0"},
                {"aspect", "false"},
                {"scaler", "normal2x"}
            };

            render.LoadDictionary(dictionary);

            Assert.AreEqual(render.Frameskip, 0);
            Assert.AreEqual(render.Aspect, false);
            Assert.AreEqual(render.Scaler, ScalerType.Normal2x);
        }
    }
}
