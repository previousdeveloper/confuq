using Client;
using Client.Interface;
using Common.Interface;
using Common.Testing.NUnit;
using FluentAssertions;
using NUnit.Framework;

namespace Test
{
    public class FileReaderTests : TestBase
    {
        private IConfuqClient _confuqClient;
        private IConfiguration _configuration;

        protected override void FinalizeSetUp()
        {
            _configuration = new ConfuqConfiguration();
            _confuqClient = new ConfuqClient(_configuration);

        }

        [Test]
        public void Config_Should_Be_Exist_Test()
        {
            bool result = _confuqClient.Get<bool>("isValid2");

            result.Should().BeFalse();

        }
    }

    public class ConfuqConfiguration : IConfiguration
    {
        public string GetBranch()
        {
            return "master";
        }

        public string GetApplicationName()
        {
            return "firstApp";
        }

        public string GetBaseUrl()
        {
            return "https://raw.githubusercontent.com/previousdeveloper/cfg4j-git-sample-config";
        }
    }
}
