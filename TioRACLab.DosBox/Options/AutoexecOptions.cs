using System;
using System.Collections.Generic;
using System.Text;
using TioRACLab.DosBox.Commands;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// Here you can define the contents of the AUTOEXEC.BAT file
    /// </summary>
    public class AutoexecOptions : BaseOptions
    {
        #region "Constructions"

        /// <summary>
        /// Create instance of Autoexec options class
        /// </summary>
        public AutoexecOptions()
            : base("autoexec")
        {
            _commands = new CommandsList();
        }

        #endregion "Constructions"

        #region "Fields"

        private CommandsList _commands;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// List commands to autoexec run
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public CommandsList Commands
        {
            get
            {
                return _commands;
            }
            protected set
            {
                _commands = value;
                OnPropertyChanged("Commands");
            }
        }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create a new Autoexec Options for DosBox configuration
        /// </summary>
        /// <returns>DosBox Autoexec configuration to add another configuration</returns>
        public static AutoexecOptions Create()
        {
            return new AutoexecOptions();
        }

        /// <summary>
        /// Add command to autoexec options
        /// </summary>
        /// <param name="command">Add command to autoexec options</param>
        /// <returns>DosBox Autoexec configuration to add another configuration</returns>
        public AutoexecOptions AddCommand(Command command)
        {
            this.Commands.Add(command);
            return this;
        }

        /// <summary>
        /// Add command to autoexec options
        /// </summary>
        /// <param name="command">Add command to autoexec options</param>
        /// <returns>DosBox Autoexec configuration to add another configuration</returns>
        public AutoexecOptions AddCommand(string command)
        {
            this.Commands.Add(new CustomCommand(command));
            return this;
        }

        #endregion "Fluent"

        #region "String"

        /// <summary>
        /// Cast CPU options to string
        /// </summary>
        /// <returns>CPU options ini format</returns>
        public override string ToString()
        {
            return base.ToString() + this.Commands.ToString();
        }

        #endregion "String"

        #region "BaseOptions"

        /// <summary>
        /// Load Autoexec options value from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary with options DosBox data</param>
        public override void LoadDictionary(IDictionary<string, object> dictionary)
        {
            foreach (var data in dictionary)
            {
                switch (data.Key)
                {
                    case "content":
                        Commands = new CommandsList(data.Value.ToString());
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion "BaseOptions"
    }
}
