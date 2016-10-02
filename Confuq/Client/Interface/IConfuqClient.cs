namespace Client.Interface
{
    public interface IConfuqClient
    {
        T Get<T>(string key);
    }
}