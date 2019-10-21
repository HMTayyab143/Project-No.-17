using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// KeyboardLayout is used to change the layout of the keyboard used for different countries. 
    /// </summary>
    public struct KeyboardLayout
    {
        #region "Constructions"

        /// <summary>
        /// Crete a KeyboardLayout struct
        /// </summary>
        /// <param name="layout">keyboard layout</param>
        public KeyboardLayout(string layout)
        {
            if (string.IsNullOrWhiteSpace(layout))
            {
                Layout = layout;
                Character = null;
            }
            else if (layout == "none")
            {
                Layout = null;
                Character = null;
            }
            else
            {
                var kb = layout.Trim().Replace("  ", " ");

                if (kb.Contains(" "))
                {
                    var kbs = kb.Split(' ');
                    Layout = kbs[0];

                    if (uint.TryParse(kbs[1], out uint character))
                        Character = character;
                    else
                        Character = null;
                }
                else
                {
                    Layout = layout;
                    Character = null;
                }
            }
        }

        /// <summary>
        /// Crete a KeyboardLayout struct
        /// </summary>
        /// <param name="layout">Keyboard layout</param>
        /// <param name="character">Character set</param>
        public KeyboardLayout(string layout, uint character)
        {
            Layout = layout;
            Character = character;
        }

        #endregion "Constructions"

        #region "Properties"

        /// <summary>
        /// Keyboard layout 
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// Character set
        /// </summary>
        public uint? Character { get; set; }

        #endregion "Properties"

        #region "String Cast"

        /// <summary>
        /// Cast struct KeyboardLayout to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Layout == null && Character == null)
                return "none";

            if (Character.HasValue)
                return $"{Layout} {Character.Value}";
            else
                return Layout;
        }

        #endregion "String Cast"
    }
}
