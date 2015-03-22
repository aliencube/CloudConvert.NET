namespace Aliencube.CloudConverter.Services.Options
{
    /// <summary>
    /// This represents the output parameters entity.
    /// </summary>
    public class OutputParameters
    {
        /// <summary>
        /// Gets or sets the value whether to send a email when conversion is completed.
        /// </summary>
        public bool Email { get; set; }

        /// <summary>
        /// Gets or sets the output storage dederived from <c>OutputStorage</c> enum value.
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Gets or sets the callback URL for notification when the conversion is finished.
        /// </summary>
        public string Callback { get; set; }

        /// <summary>
        /// Gets or sets the value whether to wait/block request until the conversion is over.
        /// </summary>
        public bool Wait { get; set; }

        /// <summary>
        /// Gets or sets the value whether to wailt/block request until the conversion is over.
        /// </summary>
        /// <remarks>If the value is <c>true</c>, the file download immediately starts, when the conversion is completed.</remarks>
        public string Download { get; set; }

        /// <summary>
        /// Gets or sets the value whether to save the converted file on CloudConvert.com or not.
        /// </summary>
        public bool Save { get; set; }
    }
}