using System;
using System.Threading.Tasks;
using Aliencube.CloudConvert.Wrapper.Options;
using Aliencube.CloudConvert.Wrapper.Requests;
using Aliencube.CloudConvert.Wrapper.Responses;

namespace Aliencube.CloudConvert.Wrapper.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>ConverterWrapper</c> class.
    /// </summary>
    public interface IConverterWrapper<T> : IDisposable where T : BaseConverterOptions
    {
        /// <summary>
        /// Converts the requested file to a designated format.
        /// </summary>
        /// <param name="input"><c>InputParameters</c> object.</param>
        /// <param name="output"><c>OutputParameters</c> object.</param>
        /// <param name="conversion"><c>ConversionParameters</c> object.</param>
        /// <returns>Returns the conversion response.</returns>
        Task<ConvertResponse> ConvertAsync(InputParameters input, OutputParameters output, ConversionParameters<T> conversion);

        /// <summary>
        /// Gets the <c>ProcessResponse</c> to be consumed in subsequent requests.
        /// </summary>
        /// <param name="inputFormat">Input file format.</param>
        /// <param name="outputFormat">Output file format.</param>
        /// <returns>Returns the <c>ProcessResponse</c> object to be consumed in subsequent requests.</returns>
        Task<ProcessResponse> GetProcessResponseAsync(string inputFormat, string outputFormat);

        /// <summary>
        /// Gets the <c>ConvertRequest</c> object.
        /// </summary>
        /// <param name="input"><c>InputParameters</c> object.</param>
        /// <param name="output"><c>OutputParameters</c> object.</param>
        /// <param name="conversion"><c>ConversionParameters</c> object.</param>
        /// <returns>Returns the <c>ConvertRequest</c> object.</returns>
        ConvertRequest GetConvertRequest(InputParameters input, OutputParameters output, ConversionParameters<T> conversion);

        /// <summary>
        /// Converts the requested file to a designated format.
        /// </summary>
        /// <param name="request"><c>ConvertRequest</c> object.</param>
        /// <param name="convertUrl">Process URL to convert.</param>
        /// <returns>Returns the conversion response.</returns>
        Task<ConvertResponse> ConvertAsync(ConvertRequest request, string convertUrl);

        /// <summary>
        /// Serialises the request object in JSON format.
        /// </summary>
        /// <typeparam name="TRequest">Request object type.</typeparam>
        /// <param name="request">Request object.</param>
        /// <returns>Returns the JSON-serialised string.</returns>
        string Serialise<TRequest>(TRequest request) where TRequest : BaseRequest;

        /// <summary>
        /// Deserialises the JSON serialised string into a designated type.
        /// </summary>
        /// <typeparam name="TResponse">Response object type.</typeparam>
        /// <param name="value">JSON serialised string.</param>
        /// <returns>Returns a deserialised object.</returns>
        TResponse Deserialise<TResponse>(string value) where TResponse : BaseResponse;
    }
}