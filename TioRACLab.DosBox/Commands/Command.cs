using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox.Commands
{
    public abstract class Command : DosBoxBaseClass
    {
        #region "Constructions"

        public Command(string name)
        {
            Name = name;
        }

        #endregion "Constructions"

        #region "Fields"

        private string _name;

        #endregion "Fields"

        #region "Properties"

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        #endregion "Properties"

        #region "Create"

        public static Command CreateCommand(string command)
        {
            return new CustomCommand(command);
        }

        #endregion "Create"
    }
}
