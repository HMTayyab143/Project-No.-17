using System;
using System.Collections.Generic;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    public struct KeyboardLayout
    {
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

        public KeyboardLayout(string layout, uint character)
        {
            Layout = layout;
            Character = character;
        }


        public string Layout { get; set; }

        public uint? Character { get; set; }

        public override string ToString()
        {
            if (Layout == null && Character == null)
                return "none";

            if (Character.HasValue)
                return $"{Layout} {Character.Value}";
            else
                return Layout;
        }
    }
}
