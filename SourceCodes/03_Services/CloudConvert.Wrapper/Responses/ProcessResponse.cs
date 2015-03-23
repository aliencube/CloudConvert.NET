using System;

namespace Aliencube.CloudConvert.Wrapper.Responses
{
    /// <summary>
    /// This represents the process response entity.
    /// </summary>
    public class ProcessResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the process URL with one-time process Id.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the one-time process Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the hostname.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the date when the process Id expires.
        /// </summary>
        public DateTime Expires { get; set; }

        /// <summary>
        /// Gets or sets the maximum time for processing in seconds
        /// </summary>
        public int MaxTime { get; set; }

        /// <summary>
        /// Gets or sets the minutes for processing.
        /// </summary>
        public int Minutes { get; set; }
    }
}