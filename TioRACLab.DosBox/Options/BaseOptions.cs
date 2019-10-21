using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// Abstract class for using option classes
    /// </summary>
    public abstract class BaseOptions : DosBoxBaseClass
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
        public abstract void LoadDictionary(IDictionary<string, object> dictionary);

        #endregion "abstract"
    }
}