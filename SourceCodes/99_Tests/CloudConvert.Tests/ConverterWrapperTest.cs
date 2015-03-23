using System;
using Aliencube.CloudConvert.Wrapper;
using Aliencube.CloudConvert.Wrapper.DataFormats;
using Aliencube.CloudConvert.Wrapper.Exceptions;
using Aliencube.CloudConvert.Wrapper.Extensions;
using Aliencube.CloudConvert.Wrapper.Interfaces;
using Aliencube.CloudConvert.Wrapper.Options;
using Aliencube.CloudConvert.Wrapper.Responses;
using FluentAssertions;
using NUnit.Framework;

namespace Aliencube.CloudConvert.Tests
{
    [TestFixture]
    public class ConverterWrapperTest
    {
        private IConverterSettings _settings;
        private IFormats _formats;
        private IConverterWrapper<MarkdownConverterOptions> _wrapper;
        private InputParameters _input;
        private OutputParameters _output;
        private ConversionParameters<MarkdownConverterOptions> _conversion;

        [SetUp]
        public void Init()
        {
            // MAKE SURE before you run this test, you MUST change the API key to yours; otherwise the test fails.
            this._settings = ConverterSettings.CreateInstance();
            this._formats = new Formats();
            this._wrapper = new ConverterWrapper<MarkdownConverterOptions>(this._settings);

            this._input = new InputParameters()
                          {
                              InputFormat = this._formats.Document.Md,
                              InputMethod = InputMethod.Download,
                              Filepath = "https://raw.githubusercontent.com/aliencube/CloudConvert.NET/dev/README.md",
                              Filename = "README.md",
                          };
            this._output = new OutputParameters()
                           {
                               DownloadMethod = DownloadMethod.False,
                               OutputStorage = OutputStorage.OneDrive,
                           };
            this._conversion = new ConversionParameters<MarkdownConverterOptions>()
                               {
                                   OutputFormat = this._formats.Document.Docx,
                                   ConverterOptions = new MarkdownConverterOptions()
                                                      {
                                                          InputMarkdownSyntax = MarkdownSyntaxType.Auto
                                                      },
                               };
        }

        [TearDown]
        public void Cleanup()
        {
            if (this._wrapper != null)
            {
                this._wrapper.Dispose();
            }

            if (this._formats != null)
            {
                this._formats.Dispose();
            }

            if (this._settings != null)
            {
                this._settings.Dispose();
            }
        }

        [Test]
        public async void GetProcessId_GivenApiKey_ReturnResult()
        {
            try
            {
                var response = await this._wrapper.GetProcessResponseAsync(this._formats.Document.Md, this._formats.Document.Docx);
                response.Id.Should().NotBeNullOrEmpty();
            }
            catch (Exception ex)
            {
                var error = ex as ErrorResponseException;
                error.Should().NotBeNull();

                var response = error.Error;
                response.Should().BeOfType<ErrorResponse>();
                response.Code.Should().NotBe(200);
            }
        }

        [Test]
        public void GetConvertRequest_GivenParameters_ReturnConvertRequest()
        {
            var request = this._wrapper.GetConvertRequest(this._input, this._output, this._conversion);
            request.InputMethod.Should().Be(InputMethod.Download.ToLower());
            request.OutputStorage.Should().Be(OutputStorage.OneDrive.ToLower());

            var serialised = this._wrapper.Serialise(request);
            serialised.Should().Contain("input_markdown_syntax");
        }

        [Test]
        public async void GetConverted_GivenParameters_ReturnConverted()
        {
            try
            {
                var response = await this._wrapper.ConvertAsync(this._input, this._output, this._conversion);
                response.Code.Should().Be(200);
            }
            catch (Exception ex)
            {
                var error = ex as ErrorResponseException;
                error.Should().NotBeNull();

                var response = error.Error;
                response.Should().BeOfType<ErrorResponse>();
                response.Code.Should().NotBe(200);
            }
        }
    }
}