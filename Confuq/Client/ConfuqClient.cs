using System;
using Client.Interface;
using Common;
using Common.Interface;

namespace Client
{
    public class ConfuqClient : IConfuqClient
    {
        private readonly ICacheProvider _cacheProvider;

        public ConfuqClient(IConfiguration configuration)
        {
            _cacheProvider = new CacheProvider(configuration);
        }

        public T Get<T>(string key)
        {
            string value = _cacheProvider.Get(key);

            if (string.IsNullOrEmpty(value))
            {
                throw new GithubKeyNotFoundException("Key Not Found");
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}