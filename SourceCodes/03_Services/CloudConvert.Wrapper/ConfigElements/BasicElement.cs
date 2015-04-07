using System.Configuration;

namespace Aliencube.CloudConvert.Wrapper.ConfigElements
{
    /// <summary>
    /// This represents the <c>ConfigurationElement</c> entity for <c>Basic</c> element.
    /// </summary>
    public class BasicElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the process URL.
        /// </summary>
        [ConfigurationProperty("processUrl", IsRequired = true)]
        public string ProcessUrl
        {
            get { return (string)this["processUrl"]; }
            set { this["processUrl"] = value; }
        }

        /// <summary>
        /// Gets or sets the value that specifies whether to include the API key in the header or not.
        /// </summary>
        [ConfigurationProperty("useHeader", IsRequired = false, DefaultValue = true)]
        public bool UseHeader
        {
            get { return (bool)this["useHeader"]; }
            set { this["useHeader"] = value; }
        }

        /// <summary>
        /// Gets or sets the API key element.
        /// </summary>
        [ConfigurationProperty("apiKey", IsRequired = true)]
        public ApiKeyElement ApiKey
        {
            get { return (ApiKeyElement)this["apiKey"]; }
            set { this["apiKey"] = value; }
        }
    }
}