using System;
using Aliencube.CloudConvert.Wrapper.ConfigElements;

namespace Aliencube.CloudConvert.Wrapper.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>ConverterSettings</c> class.
    /// </summary>
    public interface IConverterSettings : IDisposable
    {
        /// <summary>
        /// Gets the process URL.
        /// </summary>
        string ProcessUrl { get; }

        /// <summary>
        /// Gets the value that specifies whether to include the API key in the header or not.
        /// </summary>
        bool UseHeader { get; }

        /// <summary>
        /// Gets the ApiKey value
        /// </summary>
        string ApiKey { get; }
    }
}