using System.Configuration;

namespace Aliencube.CloudConvert.Wrapper.ConfigElements
{
    /// <summary>
    /// This represents the <c>ConfigurationElement</c> entity for <c>ApiKey</c> element.
    /// </summary>
    public class ApiKeyElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }
}