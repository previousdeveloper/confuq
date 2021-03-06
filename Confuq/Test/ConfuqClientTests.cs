﻿using Client;
using Client.Interface;
using Common.Interface;
using Common.Testing.NUnit;
using FluentAssertions;
using NUnit.Framework;

namespace Test
{
    public class ConfuqClientTests : TestBase
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
            bool result = _confuqClient.Get<bool>("isValid");

            result.Should().BeFalse();

        }

        [Test,ExpectedException(typeof(GithubKeyNotFoundException))]
        public void Config_Should_Not_Be_Exist_Test()
        {
            string result = _confuqClient.Get<string>("isValid2");

            result.Should().BeNull();
        }
    }
}
