using System;
using Aliencube.CloudConverter.Wrapper.Options;
using Newtonsoft.Json;

namespace Aliencube.CloudConverter.Wrapper.Requests
{
    /// <summary>
    /// This represents the convert request entity.
    /// </summary>
    public partial class ConvertRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the input method.
        /// </summary>
        [JsonProperty(PropertyName = "Input")]
        public string InputMethod { get; set; }

        /// <summary>
        /// Gets or sets the filepath. This is usually a URL.
        /// </summary>
        [JsonProperty(PropertyName = "File")]
        public string Filepath { get; set; }

        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        /// <remarks>This value is the same as the last part of the <c>Filepath</c> property.</remarks>
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <remarks>This is a custom tag for conversion. It doesn't impact on any conversion.</remarks>
        public object Tag { get; set; }

        /// <summary>
        /// Gets or sets the output format.
        /// </summary>
        public string OutputFormat { get; set; }

        /// <summary>
        /// Gets or sets the converter options. This is conversion type specific.
        /// </summary>
        public object ConverterOptions { get; set; }

        /// <summary>
        /// Gets or sets the preset Id, which is predefined at the dashboard, https://cloudconvert.com/preset.
        /// </summary>
        [JsonProperty(PropertyName = "Preset")]
        public string PresetId { get; set; }

        /// <summary>
        /// Gets or sets the timeout value in second. As default, account wide timeout value is used.
        /// </summary>
        public int? Timeout { get; set; }

        /// <summary>
        /// Gets or sets the value whether to send a email when conversion is completed.
        /// </summary>
        public bool? Email { get; set; }

        /// <summary>
        /// Gets or sets the output storage dederived from <c>OutputStorage</c> enum value.
        /// </summary>
        [JsonProperty(PropertyName = "Output")]
        public string OutputStorage { get; set; }

        /// <summary>
        /// Gets or sets the callback URL for notification when the conversion is finished.
        /// </summary>
        [JsonProperty(PropertyName = "Callback")]
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Gets or sets the value whether to wait/block request until the conversion is over.
        /// </summary>
        public bool? Wait { get; set; }

        /// <summary>
        /// Gets or sets the value whether to wailt/block request until the conversion is over.
        /// </summary>
        /// <remarks>If the value is <c>true</c>, the file download immediately starts, when the conversion is completed.</remarks>
        [JsonProperty(PropertyName = "Download")]
        public string DownloadMethod { get; set; }

        /// <summary>
        /// Gets or sets the value whether to save the converted file on CloudConvert.com or not.
        /// </summary>
        [JsonProperty(PropertyName = "Save")]
        public bool? SaveToServer { get; set; }
    }
}