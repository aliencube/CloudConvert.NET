using Newtonsoft.Json.Serialization;

namespace Aliencube.CloudConvert.Wrapper
{
    /// <summary>
    /// This represents the lowercase contract resolver entity when serialising object to JSON.
    /// </summary>
    public class LowercaseContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// Resolves the name of the property to lowercase.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Returns the lowercase resolved property name.</returns>
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}