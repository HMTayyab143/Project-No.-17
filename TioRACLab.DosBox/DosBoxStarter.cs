using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox
{
    /// <summary>
    /// Easy start DosBox
    /// </summary>
    public class DosBoxStarter
    {
        #region "Constructions"

        /// <summary>
        /// Create DosBox launcher 
        /// </summary>
        /// <param name="filename">DosBox application file name</param>
        protected DosBoxStarter(string filename)
        {
            Process = new DosBoxProcess(filename);
        }

        #endregion "Constructions"

        #region "Properties"

        /// <summary>
        /// Process to start dosbox application
        /// </summary>
        protected DosBoxProcess Process { get; set; }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create DosBox launcher
        /// </summary>
        /// <param name="filename">DosBox application file name</param>
        /// <returns>DosBox launcher</returns>
        public static DosBoxStarter FromProcess(string filename)
        {
            return new DosBoxStarter(filename);
        }

        /// <summary>
        /// Edit DosBox application startup parameters 
        /// </summary>
        /// <param name="parameters">DosBox Parameters</param>
        /// <returns>DosBox Launcher</returns>
        public DosBoxStarter SetParameters(Action<DosBoxParameters> parameters)
        {
            if (parameters != null)
                parameters.Invoke(Process.Parameters);

            return this;
        }

        /// <summary>
        /// Start DosBox application
        /// </summary>
        /// <returns>Process of DosBox Application</returns>
        public DosBoxProcess Start()
        {
            Process.Start();
            return Process;
        }

        /// <summary>
        /// Start and wait for end DosBox Application
        /// </summary>
        public void StartAndWait()
        {
            using (Process)
            {
                Process.Start();
                Process.WaitEndDosBox();
            }
        }

        #endregion "Fluent"
    }
}
