using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Aliencube.CloudConverter.Wrapper.Interfaces;
using Aliencube.CloudConverter.Wrapper.Options;
using Aliencube.CloudConverter.Wrapper.Requests;
using Aliencube.CloudConverter.Wrapper.Responses;
using Newtonsoft.Json;

namespace Aliencube.CloudConverter.Wrapper
{
    /// <summary>
    /// This represents the converter wrapper entity.
    /// </summary>
    public class ConverterWrapper : IConverterWrapper
    {
        private readonly IConverterSettings _settings;

        private bool _disposed;

        /// <summary>
        /// Initialises a new instance of the <c>ConverterWrapper</c> class.
        /// </summary>
        /// <param name="settings"></param>
        public ConverterWrapper(IConverterSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            this._settings = settings;
        }

        /// <summary>
        /// Converts the requested file to a designated format.
        /// </summary>
        /// <param name="input"><c>InputParameters</c> object.</param>
        /// <param name="output"><c>OutputParameters</c> object.</param>
        /// <param name="conversion"><c>ConversionParameters</c> object.</param>
        /// <returns>Returns the conversion response.</returns>
        public async Task<ConvertResponseExtended> ConvertAsync(InputParameters input, OutputParameters output, ConversionParameters conversion)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (output == null)
            {
                throw new ArgumentNullException("output");
            }

            if (conversion == null)
            {
                throw new ArgumentNullException("conversion");
            }

            var processResponse = await this.GetProcessResponseAsync(input.InputFormat, conversion.OutputFormat);
            var convertRequest = new ConvertRequest()
                                 {
                                     Input = input.InputMethod,
                                     File = input.Filepath,
                                     Filename = input.Filename,
                                     OutputFormat = conversion.OutputFormat,
                                     ConverterOptions = conversion.ConverterOptions,
                                     Download = output.Download,
                                 };
            var convertResponse = await this.ConvertAsync(convertRequest, String.Format("https:{0}", processResponse.Url));
            return convertResponse;
        }

        /// <summary>
        /// Gets the <c>ProcessResponse</c> to be consumed in subsequent requests.
        /// </summary>
        /// <param name="inputFormat">Input file format.</param>
        /// <param name="outputFormat">Output file format.</param>
        /// <returns>Returns the <c>ProcessResponse</c> object to be consumed in subsequent requests.</returns>
        public async Task<ProcessResponse> GetProcessResponseAsync(string inputFormat, string outputFormat)
        {
            if (String.IsNullOrWhiteSpace(inputFormat))
            {
                throw new ArgumentNullException("inputFormat");
            }

            if (String.IsNullOrWhiteSpace(outputFormat))
            {
                throw new ArgumentNullException("outputFormat");
            }

            var apiKey = this._settings.Basic.ApiKey.Value;
            var processUrl = this._settings.Basic.ProcessUrl;

            ProcessResponse deserialised;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                var request = new ProcessRequest()
                              {
                                  InputFormat = inputFormat,
                                  OutputFormat = outputFormat
                              };
                var serialised = this.Serialise(request);

                using (var content = new StringContent(serialised, Encoding.UTF8, "application/json"))
                using (var response = await client.PostAsync(processUrl, content))
                {
                    var result = await response.Content.ReadAsStringAsync();
                    deserialised = this.Deserialise<ProcessResponse>(result);
                }
            }

            return deserialised;
        }

        /// <summary>
        /// Converts the requested file to a designated format.
        /// </summary>
        /// <param name="request"><c>ConvertRequest</c> object.</param>
        /// <param name="convertUrl">Process URL to convert.</param>
        /// <returns></returns>
        public async Task<ConvertResponseExtended> ConvertAsync(ConvertRequest request, string convertUrl)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (String.IsNullOrWhiteSpace(convertUrl))
            {
                throw new ArgumentNullException("convertUrl");
            }

            var serialised = this.Serialise(request);
            ConvertResponseExtended deserialised;

            using (var client = new HttpClient())
            using (var content = new StringContent(serialised, Encoding.UTF8, "application/json"))
            using (var response = await client.PostAsync(convertUrl, content))
            {
                var result = await response.Content.ReadAsStringAsync();
                deserialised = this.Deserialise<ConvertResponseExtended>(result);
            }

            return deserialised;
        }

        /// <summary>
        /// Serialises the request object in JSON format.
        /// </summary>
        /// <typeparam name="T">Request object type.</typeparam>
        /// <param name="request">Request object.</param>
        /// <returns>Returns the JSON-serialised string.</returns>
        private string Serialise<T>(T request) where T : BaseRequest
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            var settings = new JsonSerializerSettings()
                           {
                               ContractResolver = new LowercaseContractResolver()
                           };
            var serialised = JsonConvert.SerializeObject(request, Formatting.None, settings);
            return serialised;
        }

        /// <summary>
        /// Deserialises the JSON serialised string into a designated type.
        /// </summary>
        /// <typeparam name="T">Response object type.</typeparam>
        /// <param name="value">JSON serialised string.</param>
        /// <returns>Returns a deserialised object.</returns>
        private T Deserialise<T>(string value) where T : BaseResponse
        {
            var deserialised = JsonConvert.DeserializeObject<T>(value);
            return deserialised;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}