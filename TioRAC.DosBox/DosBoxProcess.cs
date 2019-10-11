﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TioRAC.DosBox
{
    public class DosBoxProcess : IDisposable
    {
        #region "Constructions"

        public DosBoxProcess()
        {
            Parameters = new DosBoxParameters();
        }

        public DosBoxProcess(string fileName)
            : this()
        {
            FileName = fileName;
        }

        #endregion "Constructions"

        #region "Properties"

        public string FileName { get; set; }

        public DosBoxParameters Parameters { get; set; }

        public bool IsRunning 
        { 
            get
            {
                try
                {
                    System.Diagnostics.Process.GetProcessById(RuntimeProcess?.Id ?? -1);
                    return true;
                }
                catch 
                {
                    return false;
                }
            }
        }

        protected Process RuntimeProcess { get; set; }

        #endregion "Properties"

        #region "Process Control"

        public void Start()
        {
            RuntimeProcess = new System.Diagnostics.Process
            {
                StartInfo = CreateStartInfo(),
            };

            RuntimeProcess.EnableRaisingEvents = true;
            RuntimeProcess.Exited += RuntimeProcessExited;
            
            RuntimeProcess.Start();
        }

        protected ProcessStartInfo CreateStartInfo()
        {
            return new ProcessStartInfo
            {
                FileName = FileName,
                Arguments = Parameters
            };
        }

        private void RuntimeProcessExited(object sender, EventArgs e)
        {
            Stop();
        }

        public void Stop()
        {
            if (RuntimeProcess != null)
            {
                RuntimeProcess.Exited -= RuntimeProcessExited;
                RuntimeProcess.Close();
                RuntimeProcess.Dispose();
                RuntimeProcess = null;
            }
        }

        public void WaitEndDosBox()
        {
            if (IsRunning)
                RuntimeProcess.WaitForExit();
        }

        #endregion "Process Control"

        #region "IDisposable"

        void IDisposable.Dispose()
        {
            Stop();
        }

        #endregion "IDisposable"
    }
}