namespace Common.Interface
{
    public interface IConfiguration
    {
        string GetBranch();
        string GetApplicationName();
        string GetBaseUrl();
    }
}