namespace Aliencube.CloudConvert.Wrapper.Options
{
    /// <summary>
    /// This represents the conversion parameters entity.
    /// </summary>
    public class ConversionParameters
    {
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
        public string PresetId { get; set; }

        /// <summary>
        /// Gets or sets the timeout value in second. As default, account wide timeout value is used.
        /// </summary>
        public int Timeout { get; set; }
    }
}