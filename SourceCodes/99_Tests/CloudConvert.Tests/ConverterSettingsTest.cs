using Aliencube.CloudConvert.Wrapper;
using Aliencube.CloudConvert.Wrapper.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace Aliencube.CloudConvert.Tests
{
    [TestFixture]
    public class ConverterSettingsTest
    {
        private IConverterSettings _settings;

        [SetUp]
        public void Init()
        {
            this._settings = ConverterSettings.CreateInstance();
        }

        [TearDown]
        public void Cleanup()
        {
            if (this._settings != null)
            {
                this._settings.Dispose();
            }
        }

        [Test]
        public void GetConverterSettings_GivenConfig_ReturnConverterSettings()
        {
            var basic = this._settings.Basic;
            basic.Should().NotBeNull();

            var processUrl = basic.ProcessUrl;
            processUrl.Should().NotBeNullOrWhiteSpace();

            var useHeader = basic.UseHeader;
            useHeader.Should().BeTrue();

            var apiKey = basic.ApiKey;
            apiKey.Value.Should().NotBeNullOrWhiteSpace();
        }
    }
}
