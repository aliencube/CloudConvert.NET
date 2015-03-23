namespace Aliencube.CloudConverter.Wrapper.Responses
{
    /// <summary>
    /// This represents the convert response entity.
    /// </summary>
    public class ConvertResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string Error { get; set; }
    }
}