using NUnit.Framework;
using TioRACLab.DosBox.Options;
using System.Collections.Generic;

namespace TioRACLab.DosBoxTest.Options
{
    public class CPUOptionsTest
    {
        [Test]
        public void ToStringTest()
        {
            var cpu = CPUOptions.Create()
                .AddCore()
                .AddCPUType()
                .AddCycles(new CPUCycles("auto"))
                .AddCycleUp()
                .AddCycleDown();

            var iniCPU = cpu.ToString();

            Assert.AreEqual(iniCPU, "[cpu]\r\n\r\ncore=auto\r\ncputype=auto\r\ncycles=auto\r\ncycleup=10\r\ncycledown=20\r\n");
        }

        [Test]
        public void LoadDictionaryTest()
        {
            var cpu = new CPUOptions();
            var dictionary = new Dictionary<string, object>()
            {
                {"core", "auto"},
                {"cputype", "auto"},
                {"cycles", "auto"},
                {"cycleup", "10"},
                {"cycledown", "20"}
            };

            cpu.LoadDictionary(dictionary);

            Assert.AreEqual(cpu.Core, CPUCore.Auto);
            Assert.AreEqual(cpu.CPUType, CPUType.Auto);
            Assert.AreEqual(cpu.Cycles, CPUCycles.AUTO);
            Assert.AreEqual(cpu.CycleUp, 10);
            Assert.AreEqual(cpu.CycleDown, 20);
        }
    }
}
