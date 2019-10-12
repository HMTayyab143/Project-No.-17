using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TioRAC.DosBox.Options
{
    /// <summary>
    /// Abstract class for using option classes
    /// </summary>
    public abstract class BaseOptions : INotifyPropertyChanged
    {
        #region "Constructions"

        /// <summary>
        /// Create base class for options
        /// </summary>
        public BaseOptions()
        {

        }

        /// <summary>
        /// Create base class for options with section name
        /// </summary>
        /// <param name="sectionName">Section name from options</param>
        public BaseOptions(string sectionName)
            : this()
        {
            SectionName = sectionName;
        }

        #endregion "Constructions"

        #region "Properties"

        /// <summary>
        /// Section name of options file
        /// </summary>
        public string SectionName { get; set; }

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

        #region "Cast String"

        /// <summary>
        /// Return string with section name in INI file format 
        /// </summary>
        /// <returns>Section name in INI file format</returns>
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(SectionName))
                return "";
            
            return $"[{SectionName}]\r\n\r\n";
        }

        #endregion "Cast String"

        #region "abstract"

        /// <summary>
        /// Load options values from dictonary
        /// </summary>
        /// <param name="dictionary">Dictonary with options data</param>
        public abstract void LoadDictonary(IDictionary<string, object> dictionary);

        #endregion "abstract"
    }
}