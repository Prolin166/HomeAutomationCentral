using HomeAutomationCentral.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace Tests.HomeAutomationCentral
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]     
        public void Test1()
        {
            var _configuration = new Mock<IConfiguration>();
            var mockHueService = new Mock<HueEndpoint>(_configuration.Object);

            _configuration.SetupGet(x => x[It.Is<string>(s => s == "HueConfig:EndpointAddress")]).Returns("192.168.1.110");
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "HueConfig:ApiToken")]).Returns("iGDgtbj1dwYn5GYTSAgI7GqMPKq0QLbVnzOJQxWs");
         
        }
    }
}