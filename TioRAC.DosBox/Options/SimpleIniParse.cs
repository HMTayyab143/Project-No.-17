using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TioRAC.DosBox.Options
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
                else if (value.GetType().IsEnum)
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

            if (Enum.TryParse<T>(value.ToString(), true, out T result))
                return result;

            return null;
        }

        #endregion "Get Values"

        #region "Read Ini"

        #endregion "Read Ini"
    }
}
