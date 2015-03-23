using Aliencube.CloudConverter.Wrapper;
using Aliencube.CloudConverter.Wrapper.Interfaces;
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
            this._settings = ConverterSettings.CreateInstance();
            
            var basic = this._settings.Basic;
            basic.Should().NotBeNull();

            var processUrl = basic.ProcessUrl;
            processUrl.Should().NotBeNullOrWhiteSpace();

            var apiKey = basic.ApiKey;
            apiKey.Value.Should().NotBeNullOrWhiteSpace();
        }
    }
}
