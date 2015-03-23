using System;
using Aliencube.CloudConverter.Wrapper.ConfigElements;

namespace Aliencube.CloudConverter.Wrapper.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>ConverterSettings</c> class.
    /// </summary>
    public interface IConverterSettings : IDisposable
    {
        /// <summary>
        /// Gets or sets the basic element.
        /// </summary>
        BasicElement Basic { get; set; }
    }
}