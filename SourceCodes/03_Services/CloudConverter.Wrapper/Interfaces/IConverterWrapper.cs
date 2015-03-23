using System;
using System.Threading.Tasks;
using Aliencube.CloudConverter.Wrapper.Options;
using Aliencube.CloudConverter.Wrapper.Requests;
using Aliencube.CloudConverter.Wrapper.Responses;

namespace Aliencube.CloudConverter.Wrapper.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>ConverterWrapper</c> class.
    /// </summary>
    public interface IConverterWrapper : IDisposable
    {
        /// <summary>
        /// Converts the requested file to a designated format.
        /// </summary>
        /// <param name="input"><c>InputParameters</c> object.</param>
        /// <param name="output"><c>OutputParameters</c> object.</param>
        /// <param name="conversion"><c>ConversionParameters</c> object.</param>
        /// <returns>Returns the conversion response.</returns>
        Task<ConvertResponseExtended> ConvertAsync(InputParameters input, OutputParameters output, ConversionParameters conversion);

        /// <summary>
        /// Gets the <c>ProcessResponse</c> to be consumed in subsequent requests.
        /// </summary>
        /// <param name="inputFormat">Input file format.</param>
        /// <param name="outputFormat">Output file format.</param>
        /// <returns>Returns the <c>ProcessResponse</c> object to be consumed in subsequent requests.</returns>
        Task<ProcessResponse> GetProcessResponseAsync(string inputFormat, string outputFormat);

        /// <summary>
        /// Converts the requested file to a designated format.
        /// </summary>
        /// <param name="request"><c>ConvertRequest</c> object.</param>
        /// <param name="convertUrl">Process URL to convert.</param>
        /// <returns></returns>
        Task<ConvertResponseExtended> ConvertAsync(ConvertRequest request, string convertUrl);
    }
}