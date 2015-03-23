using System;

namespace Aliencube.CloudConverter.Wrapper.Responses
{
    /// <summary>
    /// This represents the process response entity.
    /// </summary>
    public class ProcessResponse : BaseResponse
    {
        public string Url { get; set; }

        public string Id { get; set; }

        public string Host { get; set; }

        public DateTime Expires { get; set; }

        public int MaxTime { get; set; }

        public int Minutes { get; set; }
    }
}