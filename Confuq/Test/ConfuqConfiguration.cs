using Common.Interface;

namespace Test
{
    public class ConfuqConfiguration : IConfiguration
    {
        public string GetBranch()
        {
            return "master";
        }

        public string GetApplicationName()
        {
            return "firstApp";
        }

        public string GetBaseUrl()
        {
            return "https://raw.githubusercontent.com/previousdeveloper/cfg4j-git-sample-config";
        }
    }
}