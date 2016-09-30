using Client.Interface;

namespace Client
{
    public class Configuration : IConfiguration
    {
        public string Url { get; set; }
        public string Branch { get; set; }
        public string Env { get; set; }
    }
}