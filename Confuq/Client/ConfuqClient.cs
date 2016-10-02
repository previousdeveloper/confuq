using System;
using Client.Interface;
using Common;
using Common.Interface;

namespace Client
{
    public class ConfuqClient : IConfuqClient
    {
        private readonly IConfigParser _configParser;

        private readonly IConfiguration _configuration;
        public ConfuqClient(IConfiguration configuration)
        {
            _configuration = configuration;

            _configParser = new ConfigParser(_configuration);
        }

        public T Get<T>(string key)
        {
            string value = _configParser.Get(key);

            if (string.IsNullOrEmpty(value))
            {
                throw new GithubKeyNotFoundException("Key Not Found");
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }
    }

    public class GithubKeyNotFoundException : Exception
    {
        public GithubKeyNotFoundException() : base()

        {

        }
        public GithubKeyNotFoundException(String message) : base(message)
        {

        }

        public GithubKeyNotFoundException(String message, Exception innerException) : base(message, innerException)
        {

        }
    }
}