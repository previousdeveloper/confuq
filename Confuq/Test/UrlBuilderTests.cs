using Common;
using Common.Interface;
using Common.Testing.NUnit;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Test
{
    public class UrlBuilderTests : TestBase
    {
        private Mock<IConfiguration> _configurationMock;
         
        private IUrlBuilder _urlBuilder;
        
        protected override void FinalizeSetUp()
        {
            _configurationMock = MockFor<IConfiguration>();

            _urlBuilder = new UrlBuilder(_configurationMock.Object);
        }

        [Test]
        public void Test()
        {
            string applicationName = FixtureRepository.Create<string>();
            string baseUrl = FixtureRepository.Create<string>();
            string branch = FixtureRepository.Create<string>();

            _configurationMock.Setup(item => item.GetApplicationName()).Returns(applicationName);
            _configurationMock.Setup(item => item.GetBaseUrl()).Returns(baseUrl);
            _configurationMock.Setup(item => item.GetBranch()).Returns(branch);

            string result = _urlBuilder.Build();

            result.Should().NotBeNull();
            result.Should().Contain(applicationName);
            result.Should().Contain(baseUrl);
            result.Should().Contain(branch);
        }
    }
}
