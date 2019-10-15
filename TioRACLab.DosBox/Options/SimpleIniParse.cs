using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TioRACLab.DosBox.Options
{
    /// <summary>
    /// Simple class for read and write INI data
    /// </summary>
    public static class SimpleIniParse
    {
        #region "Create Ini"

        /// <summary>
        /// Create ini line with data with StringBuilder class
        /// </summary>
        /// <param name="stringBuilder">StringBuild that will include the line with the option</param>
        /// <param name="key">Key parameters name</param>
        /// <param name="values">Value option</param>
        /// <returns>New line inserted or null when no line was inseted</returns>
        public static string CreateIniLine(this StringBuilder stringBuilder, string key, params object[] values)
        {
            if (key == null)
                return null;

            if (values == null || values.Length <= 0)
                return null;

            var listValues = new List<string>();

            foreach (var value in values)
            {
                if (value is bool)
                    listValues.Add(ParseBool(value));
                else if (value?.GetType().IsEnum ?? false)
                    listValues.Add(ParseEnum(value));
                else
                    listValues.Add(value.ToString());
            }

            if (listValues.Count > 0 
                && listValues.Any(v => !string.IsNullOrWhiteSpace(v)))
            {
                var line = $"{key}={string.Join(",", listValues)}";
                stringBuilder.AppendLine(line);
                return line;
            }

            return null;
        }

        private static string ParseBool(object value)
        {
            return value.ToString().ToLower();
        }

        private static string ParseEnum(object value)
        {
            return Enum.GetName(value.GetType(), value).ToLower();
        }

        #endregion "Create Ini"

        #region "Get Values"

        /// <summary>
        /// Get boolean value
        /// </summary>
        /// <param name="value">Object bool value</param>
        /// <returns>bool value</returns>
        public static bool? GetBool(object value)
        {
            if (value == null)
                return null;

            if (value is bool)
                return (bool)value;

            if (bool.TryParse(value.ToString(), out bool result))
                return result;

            return null;
        }

        /// <summary>
        /// Get integer value
        /// </summary>
        /// <param name="value">Object int value</param>
        /// <returns>int value</returns>
        public static int? GetInt(object value)
        {
            if (value == null)
                return null;

            if (value is int)
                return (int)value;

            if (int.TryParse(value.ToString(), out int result))
                return result;

            return null;
        }

        /// <summary>
        /// Get unsigned integer value
        /// </summary>
        /// <param name="value">Object uint value</param>
        /// <returns>uint value</returns>
        public static uint? GetUInt(object value)
        {
            if (value == null)
                return null;

            if (value is uint)
                return (uint)value;

            if (uint.TryParse(value.ToString(), out uint result))
                return result;

            return null;
        }

        /// <summary>
        /// Get enumerator value
        /// </summary>
        /// <typeparam name="T">Enumerator type</typeparam>
        /// <param name="value">Object enum value</param>
        /// <returns>enum value</returns>
        public static T? GetEnum<T>(object value)
            where T : struct
        {
            if (value == null)
                return null;

            if (value is T)
                return (T)value;

            var fields = typeof(T).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

            foreach (var field in fields)
            {
                if (field.Name.ToLower() == value.ToString())
                    return (T)field.GetValue(null);

                var attribute = Attribute.GetCustomAttribute(field, typeof(System.ComponentModel.DescriptionAttribute)) as System.ComponentModel.DescriptionAttribute;

                if ((attribute != null) && attribute.Description.ToLower() == value.ToString())
                    return (T)field.GetValue(null);
            }

            if (Enum.TryParse<T>(value.ToString(), true, out T result))
                return result;

            return null;
        }

        #endregion "Get Values"

        #region "Read Ini"

        /// <summary>
        /// Read a string in INI format and convert to dictionary
        /// </summary>
        /// <param name="iniOptions">string in INI format</param>
        /// <returns>Dictionary</returns>
        public static Dictionary<string, object> ReadIniOptions(string iniOptions)
        {
            var iniDictionary = new Dictionary<string, object>();
            var sectionDictionary = iniDictionary;

            if (!string.IsNullOrWhiteSpace(iniOptions))
            {
                var linesOptions = iniOptions.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();

                while (linesOptions.Count > 0)
                {
                    var line = linesOptions[0].Trim();

                    if (CleanLineIniOptions(line))
                    {
                        if (TryGetSectionName(line, out string nameSection))
                        {
                            sectionDictionary = new Dictionary<string, object>();
                            iniDictionary.Add(nameSection, sectionDictionary);
                        }
                        else if (TryGetKeyAndValue(line, out string key, out object value))
                        {
                            sectionDictionary.Add(key, value);
                        }
                        else
                        {
                            sectionDictionary.Add("content", string.Join("\n", linesOptions));
                            linesOptions.Clear();
                            linesOptions.Add(line);
                        }
                    }

                    linesOptions.RemoveAt(0);
                }
            }

            return iniDictionary;
        }

        private static bool CleanLineIniOptions(string line)
        {
            if (line.Contains('#'))
                line = line.Substring(0, line.IndexOf('#'));

            if (line.Contains(';'))
                line = line.Substring(0, line.IndexOf(';'));

            return !string.IsNullOrWhiteSpace(line);
        }

        private static bool TryGetSectionName(string line, out string nameSection)
        {
            if (line.StartsWith("[") && line.EndsWith("]"))
            {
                var index1 = line.IndexOf('[') + 1;
                var index2 = line.IndexOf(']');
                nameSection = line.Substring(index1, index2 - index1);
                return true;
            }

            nameSection = null;
            return false;
        }

        private static bool TryGetKeyAndValue(string line, out string key, out object value)
        {
            if (line.Contains("="))
            {
                var keyValue = line.Split('=');
                key = keyValue[0].Trim();

                if (keyValue[1].Contains(","))
                    value = keyValue[1].Split(',').Select(a => a.Trim()).ToList();
                else
                    value = keyValue[1].Trim();

                return true;
            }

            key = null;
            value = null;
            return false;
        }

        #endregion "Read Ini"
    }
}
