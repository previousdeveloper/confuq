using System.Collections.Generic;
using System.IO;

using Common.Interface;

namespace Common
{
    public class ConfigParser : IConfigParser
    {
        private readonly IFileReader _fileReader;
        private readonly IConfiguration _configuration;
        private readonly IUrlBuilder _builder;
        
        public ConfigParser(IConfiguration configuration)
        {
            _configuration = configuration;
            _builder = new UrlBuilder(_configuration);

            _fileReader = new FileReader(_builder);
        }

        public string Get(string key)
        {
            string result = null;

            Dictionary<string, string> configKeyList = new Dictionary<string, string>();

            using (StringReader input = new StringReader(_fileReader.Read()))
            {
                while (true)
                {
                    string readLine = input.ReadLine();

                    if (readLine != null)
                    {
                        configKeyList.Add(readLine.SplitToKeyValue(Constants.FirstIndex), readLine.SplitToKeyValue(Constants.SecondIndex));
                    }
                    else
                    {
                        break;
                        
                    }
                }
            }

            if (configKeyList.ContainsKey(key))
            {
                result = configKeyList[key];
            }

            return result;
        }
    }
}