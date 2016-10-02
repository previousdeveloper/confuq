using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using Common.Interface;

namespace Common
{
    public class CacheProvider : ICacheProvider
    {
        private readonly Timer _timer;
        private readonly IFileReader _fileReader;
        private readonly IConfiguration _configuration;
        private readonly IUrlBuilder _builder;
        private static Dictionary<string, string> _configListResponse;


        public CacheProvider(IConfiguration configuration)
        {
            _configuration = configuration;

            _configListResponse = new Dictionary<string, string>();
            _builder = new UrlBuilder(_configuration);
            _fileReader = new FileReader(_builder);

            _timer = new Timer(_configuration.Interval ?? Constants.DefaultInterval);

            GetList();

            _timer.Elapsed += TimeElapsed;

            _timer.Start();
        }



        public string Get(string key)
        {
            string result = null;

            if (_configListResponse.Any() && _configListResponse.ContainsKey(key))
            {
                result = _configListResponse[key];
            }

            return result;
        }


        private void GetList()
        {

            using (StringReader input = new StringReader(_fileReader.Read()))
            {
                while (true)
                {
                    string readLine = input.ReadLine();

                    if (readLine != null)
                    {
                        _configListResponse.Add(readLine.SplitToKeyValue(Constants.FirstIndex), readLine.SplitToKeyValue(Constants.SecondIndex));
                    }
                    else
                    {
                        break;

                    }
                }
            }
        }

        private void TimeElapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();

            GetList();

            _timer.Start();
        }
    }
}