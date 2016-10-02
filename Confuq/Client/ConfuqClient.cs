using System;
using Client.Interface;
using Common;
using Common.Interface;

namespace Client
{
    public class ConfuqClient : IConfuqClient
    {
        private readonly IConfigParser _configParser;

        public ConfuqClient(IConfiguration configuration)
        {
            _configParser = new ConfigParser(configuration);
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
}