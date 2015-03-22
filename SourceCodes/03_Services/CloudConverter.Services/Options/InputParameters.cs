namespace Aliencube.CloudConverter.Services.Options
{
    /// <summary>
    /// This represents the input parameters entity.
    /// </summary>
    public class InputParameters
    {
        /// <summary>
        /// Gets or sets the input format.
        /// </summary>
        public string InputFormat { get; set; }

        /// <summary>
        /// Gets or sets the input method dederived from <c>InputMethod</c> enum value.
        /// </summary>
        public string InputMethod { get; set; }

        /// <summary>
        /// Gets or sets the filepath. This is usualy a URL.
        /// </summary>
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
    }
}