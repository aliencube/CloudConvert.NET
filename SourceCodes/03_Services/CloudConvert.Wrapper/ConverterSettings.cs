using System;
using System.Configuration;
using Aliencube.CloudConvert.Wrapper.ConfigElements;
using Aliencube.CloudConvert.Wrapper.Interfaces;

namespace Aliencube.CloudConvert.Wrapper
{
    /// <summary>
    /// This represents the <c>ConfigurationSection</c> element entity for <c>ConverterSettings</c>.
    /// </summary>
    public class ConverterSettings : ConfigurationSection, IConverterSettings
    {
        private bool _disposed;

        /// <summary>
        /// Gets or sets the basic element.
        /// </summary>
        [ConfigurationProperty("basic", IsRequired = true)]
        public BasicElement Basic
        {
            get { return (BasicElement)this["basic"]; }
            set { this["basic"] = value; }
        }

        /// <summary>
        /// Gets the process URL.
        /// </summary>
        public string ProcessUrl
        {
            get { return this.Basic.ProcessUrl; }
            set
            {
                if (this.Basic != null)
                    this.Basic.ProcessUrl = value;
            }
        }

        /// <summary>
        /// Gets the value that specifies whether to include the API key in the header or not.
        /// </summary>
        public bool UseHeader
        {
            get { return this.Basic.UseHeader; }
            set
            {
                if (this.Basic != null)
                    this.Basic.UseHeader = value;
            }
        }

        /// <summary>
        /// Gets the ApiKey value
        /// </summary>
        public string ApiKey
        {
            get { return this.Basic?.ApiKey?.Value; }
            set
            {
                if (this.Basic != null)
                    this.Basic.ApiKey.Value = value;
            }
        }

        /// <summary>
        /// Creates a new instance of the <c>ConverterSettings</c> class.
        /// </summary>
        /// <returns>Returns the new instance of the <c>ConverterSettings</c> class.</returns>
        public static IConverterSettings CreateInstance()
        {
            var settings = GetFromConverterSettings();
            if (settings != null)
            {
                return settings;
            }

            settings = GetFromAppSettings();
            return settings;
        }

        /// <summary>
        /// Gets the <c>ConverterSettings</c> object from the converterSettings element.
        /// </summary>
        /// <returns>Returns the <c>ConverterSettings</c> object.</returns>
        private static IConverterSettings GetFromConverterSettings()
        {
            var settings = ConfigurationManager.GetSection("converterSettings") as IConverterSettings;
            return settings;
        }

        /// <summary>
        /// Gets the <c>ConverterSettings</c> object from the appSettings element.
        /// </summary>
        /// <returns>Returns the <c>ConverterSettings</c> object.</returns>
        private static IConverterSettings GetFromAppSettings()
        {
            var processUrl = ConfigurationManager.AppSettings["ProcessUrl"];
            bool result;
            var useHeader = Boolean.TryParse(ConfigurationManager.AppSettings["UseHeader"], out result) && result;
            var apiKey = ConfigurationManager.AppSettings["ApiKey"];
            if (String.IsNullOrWhiteSpace(processUrl) || String.IsNullOrWhiteSpace(apiKey))
            {
                return null;
            }

            var settings = new ConverterSettings
            {
                Basic = new BasicElement
                {
                    ProcessUrl = processUrl,
                    UseHeader = useHeader,
                    ApiKey = new ApiKeyElement
                    {
                        Value = apiKey,
                    },
                }
            };
            return settings;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}