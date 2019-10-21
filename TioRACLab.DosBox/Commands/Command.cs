using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox.Commands
{
    public abstract class Command : INotifyPropertyChanged
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

        #region "INotifyPropertyChanged"

        /// <summary>
        /// Handler Property Changed
        /// </summary>
        protected PropertyChangedEventHandler PropertyChangedHandler;
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                PropertyChangedHandler += value;
            }
            remove
            {
                PropertyChangedHandler -= value;
            }
        }

        /// <summary>
        /// Notify Property Changed
        /// </summary>
        /// <param name="name">Name Property</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedHandler?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion "INotifyPropertyChanged"
    }
}
