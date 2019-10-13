using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// <para>The rendering (drawing) section controls methods that DOSBox uses to improve the speed and quality of the graphics displayed on the screen</para>
    /// <para>See more in <a href="https://www.dosbox.com/wiki/Configuration:RENDER">Render Configuriotn DOSBox</a> Wiki page</para>
    /// </summary>
    public class RenderOptions : BaseOptions
    {
        #region "Constructions"

        /// <summary>
        /// Create instance of Render options class
        /// </summary>
        public RenderOptions()
            : base("render")
        {
        }

        #endregion "Constructions"

        #region "Fields"

        private uint? _frameskip;
        private bool? _aspect;
        private ScalerType? _scaler;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// How many frames DOSBox skips before drawing one.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public uint? Frameskip
        {
            get
            {
                return _frameskip;
            }
            set
            {
                _frameskip = value;
                OnPropertyChanged("Frameskip");
            }
        }

        /// <summary>
        /// Do aspect correction, if your output method doesn't support scaling this can slow things down!
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public bool? Aspect
        {
            get
            {
                return _aspect;
            }
            set
            {
                _aspect = value;
                OnPropertyChanged("Aspect");
            }
        }

        /// <summary>
        /// Scaler used to enlarge/enhance low resolution modes.
        /// </summary>
        [DosBoxVersion(DosBoxVersion.Official0_74)]
        public ScalerType? Scaler
        {
            get
            {
                return _scaler;
            }
            set
            {
                _scaler = value;
                OnPropertyChanged("Scaler");
            }
        }

        #endregion "Properties"

        #region "Fluent"

        /// <summary>
        /// Create a new Render options for DosBox configuration
        /// </summary>
        /// <returns>Render options to add another configuration</returns>
        public static RenderOptions Create()
        {
            return new RenderOptions();
        }

        /// <summary>
        /// How many frames DOSBox skips before drawing one.
        /// </summary>
        /// <param name="frameskip">frames skips</param>
        /// <returns>Render options to add another configuration</returns>
        public RenderOptions AddFrameskip(uint? frameskip = 0)
        {
            this.Frameskip = frameskip;
            return this;
        }

        /// <summary>
        /// Do aspect correction, if your output method doesn't support scaling this can slow things down!
        /// </summary>
        /// <param name="aspect">Aspect correction?</param>
        /// <returns>Render options to add another configuration</returns>
        public RenderOptions AddAspect(bool? aspect = false)
        {
            Aspect = aspect;
            return this;
        }

        /// <summary>
        /// Scaler used to enlarge/enhance low resolution modes.
        /// </summary>
        /// <param name="scaler">Scaler</param>
        /// <returns>Render options to add another configuration</returns>
        public RenderOptions AddScaler(ScalerType? scaler = ScalerType.Normal2x)
        {
            Scaler = scaler;
            return this;
        }

        #endregion "Fluent"

        #region "String"

        /// <summary>
        /// Cast Render options to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var options = new StringBuilder(base.ToString());

            options.CreateIniLine("frameskip", Frameskip);
            options.CreateIniLine("aspect", Aspect);
            options.CreateIniLine("scaler", Scaler);

            return options.ToString();
        }

        #endregion "String"

        #region "BaseOptions"

        /// <summary>
        /// Load Render options value from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary with options Render data</param>
        public override void LoadDictionary(IDictionary<string, object> dictionary)
        {
            foreach (var data in dictionary)
            {
                switch (data.Key)
                {
                    case "frameskip":
                        Frameskip = SimpleIniParse.GetUInt(data.Value);
                        break;

                    case "aspect":
                        Aspect = SimpleIniParse.GetBool(data.Value);
                        break;

                    case "scaler":
                        Scaler = SimpleIniParse.GetEnum<ScalerType>(data.Value);
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion "BaseOptions"
    }
}
