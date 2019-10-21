using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TioRACLab.DosBox
{
    public abstract class DosBoxBaseClass : INotifyPropertyChanged
    {
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
