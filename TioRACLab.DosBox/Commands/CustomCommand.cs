﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Commands
{
    public class CustomCommand : Command
    {
        #region "Constructions"

        internal protected CustomCommand()
            : base (null)
        {

        }

        internal protected CustomCommand(string command)
            : this()
        {
            this.Command = command;
        }

        #endregion "Constructions"

        #region "Fields"

        private string _command;

        #endregion "Fields"

        #region "Properties"

        public string Command
        {
            get
            {
                return _command;
            }
            set
            {
                _command = value;
                OnPropertyChanged("Command");
            }
        }

        #endregion "Properties"

        #region "String Cast"

        public override string ToString()
        {
            return this.Command;
        }

        #endregion "String Cast"
    }
}
