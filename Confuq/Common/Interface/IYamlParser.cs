using System.Collections.Generic;

namespace Common.Interface
{
    public interface IYamlParser
    {
        Dictionary<string, string> Parse(string doc);
    }
}