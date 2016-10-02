namespace Common.Interface
{
    public interface IUrlBuilder
    {
        string Build();
    }

    public class UrlBuilder : IUrlBuilder
    {
        private readonly IConfiguration _configuration;
        public UrlBuilder(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Build()
        {
            string result = $"{_configuration.GetBaseUrl()}/{_configuration.GetBranch()}/{_configuration.GetApplicationName()}/configuration.yaml";

            return result;
        }
    }
}