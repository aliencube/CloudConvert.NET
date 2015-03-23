using System;

namespace Aliencube.CloudConverter.Wrapper.Extensions
{
    /// <summary>
    /// This represents the extension class for enum converter.
    /// </summary>
    public static class EnumConverterExtension
    {
        /// <summary>
        /// Converts the enum value into a lowercase string.
        /// </summary>
        /// <param name="value">Enum value.</param>
        /// <returns>Returns the lowercase string converted from the enum value.</returns>
        public static string ToLower(this object value)
        {
            if (!value.GetType().IsEnum)
            {
                throw new ArgumentException("Not enum value", "value");
            }

            var result = value.ToString().ToLower();
            return result;
        }
    }
}