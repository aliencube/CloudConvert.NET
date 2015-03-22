using Aliencube.CloudConverter.Services;
using Aliencube.CloudConverter.Services.DataFormats;
using FluentAssertions;
using NUnit.Framework;

namespace Aliencube.CloudConvert.Tests
{
    [TestFixture]
    public class ConverterTest
    {
        [SetUp]
        public void Init()
        {
        }

        [TearDown]
        public void Cleanup()
        {
        }

        [Test]
        public async void GetProcessId_GivenApiKey_ReturnResult()
        {
            var service = new ConverterWrapper();
            var formats = new Formats();
            var response = await service.GetProcessResponseAsync(formats.Document.Md, formats.Document.Docx);
            response.Id.Should().NotBeNullOrEmpty();
        }
    }
}