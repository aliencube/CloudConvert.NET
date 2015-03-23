using Aliencube.CloudConverter.Wrapper;
using Aliencube.CloudConverter.Wrapper.DataFormats;
using Aliencube.CloudConverter.Wrapper.Interfaces;
using Aliencube.CloudConverter.Wrapper.Options;
using FluentAssertions;
using NUnit.Framework;

namespace Aliencube.CloudConvert.Tests
{
    [TestFixture]
    public class ConverterWrapperTest
    {
        private IConverterSettings _settings;
        private IConverterWrapper<MarkdownConverterOptions> _wrapper;

        [SetUp]
        public void Init()
        {
            this._settings = ConverterSettings.CreateInstance();
            this._wrapper = new ConverterWrapper<MarkdownConverterOptions>(this._settings);
        }

        [TearDown]
        public void Cleanup()
        {
            if (this._wrapper != null)
            {
                this._wrapper.Dispose();
            }

            if (this._settings != null)
            {
                this._settings.Dispose();
            }
        }

        [Test]
        public async void GetProcessId_GivenApiKey_ReturnResult()
        {
            var formats = new Formats();
            var response = await this._wrapper.GetProcessResponseAsync(formats.Document.Md, formats.Document.Docx);
            response.Id.Should().NotBeNullOrEmpty();
        }
    }
}