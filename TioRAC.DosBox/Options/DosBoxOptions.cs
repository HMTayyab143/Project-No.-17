using System;
using System.Collections.Generic;
using System.Text;

namespace TioRAC.DosBox.Options
{
    public class DosBoxOptions : BaseOptions
    {
        #region "Constructions"

        public DosBoxOptions()
            : base("dosbox")
        {
        }

        #endregion "Constructions"

        #region "Fields"

        private string _language;
        private DosBoxMachine _machine;
        private string _captures;
        private uint _memSize;

        #endregion "Fields"

        #region "Properties"

        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
                OnPropertyChanged("Language");
            }
        }

        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public DosBoxMachine Machine
        {
            get
            {
                return _machine;
            }
            set
            {
                _machine = value;
                OnPropertyChanged("Machine");
            }
        }

        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public string Captures
        {
            get
            {
                return _captures;
            }
            set
            {
                _captures = value;
                OnPropertyChanged("Captures");
            }
        }

        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public uint MemSize
        {
            get
            {
                return _memSize;
            }
            set
            {
                _memSize = value;
                OnPropertyChanged("MemSize");
            }
        }

        #endregion "Properties"





        public override void LoadDictionary(IDictionary<string, object> dictionary)
        {
            throw new NotImplementedException();
        }
    }
}
