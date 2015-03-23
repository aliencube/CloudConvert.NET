namespace Aliencube.CloudConverter.Wrapper.Requests
{
    /// <summary>
    /// This represents the process request entity.
    /// </summary>
    public class ProcessRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the input format.
        /// </summary>
        public string InputFormat { get; set; }

        /// <summary>
        /// Gets or sets the output format.
        /// </summary>
        public string OutputFormat { get; set; }
    }
}