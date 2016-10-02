using System.Net;
using Common;
using Common.Interface;
using Common.Testing.NUnit;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Test
{
    public class FileReaderTests : TestBase
    {
        private IFileReader _fileReader;
        private Mock<IUrlBuilder> _urlBuilderMock;

        protected override void FinalizeSetUp()
        {
            _urlBuilderMock = MockFor<IUrlBuilder>();

            _fileReader = new FileReader(_urlBuilderMock.Object);
        }


        [Test,ExpectedException(typeof(WebException))]
        public void WebException_Test()
        {
            string url = FixtureRepository.Create<string>();

            _urlBuilderMock.Setup(item => item.Build()).Returns(url);

            string result = _fileReader.Read();

            result.Should().BeNull();
        }

        [Test]
        public void FileReader_Should_Not_Be_Null_Test()
        {
            string url = "https://raw.githubusercontent.com/previousdeveloper/cfg4j-git-sample-config/master/firstApp/dev/feature/configuration.yaml";

            _urlBuilderMock.Setup(item => item.Build()).Returns(url);

            string result = _fileReader.Read();

            result.Should().NotBeNull();
        }
    }
}
