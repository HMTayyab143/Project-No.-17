using System;
using System.Diagnostics;

namespace TioRAC.DosBox
{
    /// <summary>
    /// Dosbox Process Control
    /// </summary>
    public class DosBoxProcess : IDisposable
    {
        #region "Constructions"

        /// <summary>
        /// Create Dosbox Process Control
        /// </summary>
        public DosBoxProcess()
        {
            Parameters = new DosBoxParameters();
        }

        /// <summary>
        /// Dosbox Process Control with file name of dosbox application
        /// </summary>
        /// <param name="fileName">DosBox application file name</param>
        public DosBoxProcess(string fileName)
            : this()
        {
            FileName = fileName;
        }

        #endregion "Constructions"

        #region "Properties"

        /// <summary>
        /// DosBox application file name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Parameters to start dosbox application
        /// </summary>
        public DosBoxParameters Parameters { get; set; }

        /// <summary>
        /// Informs if the dosbox is running
        /// </summary>
        public bool IsRunning 
        { 
            get
            {
                try
                {
                    Process.GetProcessById(RuntimeProcess?.Id ?? -1);
                    return true;
                }
                catch 
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Process of DosBox Application
        /// </summary>
        protected Process RuntimeProcess { get; set; }

        #endregion "Properties"

        #region "Process Control"

        /// <summary>
        /// Start DosBox application
        /// </summary>
        public void Start()
        {
            RuntimeProcess = new Process
            {
                StartInfo = CreateStartInfo(),
            };

            RuntimeProcess.EnableRaisingEvents = true;
            RuntimeProcess.Exited += RuntimeProcessExited;
            
            RuntimeProcess.Start();
        }

        /// <summary>
        /// Create start info for process
        /// </summary>
        /// <returns></returns>
        protected ProcessStartInfo CreateStartInfo()
        {
            return new ProcessStartInfo
            {
                FileName = FileName,
                Arguments = Parameters
            };
        }

        /// <summary>
        /// Stop DosBox application
        /// </summary>
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

        /// <summary>
        /// Wait DosBox end application
        /// </summary>
        public void WaitEndDosBox()
        {
            if (IsRunning)
                RuntimeProcess.WaitForExit();
        }

        private void RuntimeProcessExited(object sender, EventArgs e)
        {
            Stop();
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
