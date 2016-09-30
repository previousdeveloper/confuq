using System.Collections.Generic;
using Common;
using Common.Exception;
using Common.Interface;
using Common.Testing.NUnit;
using FluentAssertions;
using NUnit.Framework;

namespace Test
{
    public class FileReaderTests : TestBase
    {
        private IFileReader _fileReader;
        private IYamlParser _yamlParser;

        protected override void FinalizeSetUp()
        {
            _fileReader = new FileReader();
            _yamlParser = new YamlParser();
        }

        [Test]
        public void FileReader_Should_Not_Be_Null_Test()
        {
            string result = _fileReader.Read(Constants.TextUrl);

            result.Should().NotBeNull();
        }


        [Test,ExpectedException(typeof(FileUrlException))]
        public void FileReader_Url_Should_Be_Empty_Test()
        {
            string result = _fileReader.Read("");

            result.Should().BeEmpty();

        }

        [Test]
        public void YamlParser_Test()
        {
            string result = _fileReader.Read(Constants.TextUrl);

            Dictionary<string, string> s = _yamlParser.Parse(result);

            s.Should().NotBeEmpty();
        }
    }
}
