﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TioRACLab.DosBox;

namespace TioRACLab.DosBoxTest
{
    public class DosBoxProcessTest
    {
        [Test]
        public void IsRunning()
        {
            using var dosBoxProcess = new DosBoxProcess
            {
                FileName = "dosbox.exe"
            };;

            Assert.IsFalse(dosBoxProcess.IsRunning);
        }
    }
}
