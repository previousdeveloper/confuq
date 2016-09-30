using System.Collections.Generic;
using System.IO;

using Common.Interface;

using YamlDotNet.RepresentationModel;

namespace Common
{
    public class YamlParser : IYamlParser
    {
        public Dictionary<string, string> Parse(string doc)
        {
            StringReader input = new StringReader(doc);
            YamlStream yaml = new YamlStream();

            yaml.Load(input);
            YamlMappingNode mapping = (YamlMappingNode)yaml.Documents[0].RootNode;


            return new Dictionary<string, string>();
        }
    }
}