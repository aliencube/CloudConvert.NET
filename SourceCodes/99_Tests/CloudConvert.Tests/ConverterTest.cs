using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            using (var client = new HttpClient())
            {
                var apiKey = ConfigurationManager.AppSettings["ApiKey"];
                var processUrl = ConfigurationManager.AppSettings["Url.Process"];

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                var json = "{ \"inputformat\": \"md\", \"outputformat\": \"docx\" }";
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(processUrl, content);
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var result = await response.Content.ReadAsStringAsync();
                var jresult = JObject.Parse(result);
                jresult["url"].ToString().Should().NotBeNullOrEmpty();
            }
        }
    }
}
