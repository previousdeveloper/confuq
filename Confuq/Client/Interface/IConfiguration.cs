namespace Client.Interface
{
    public interface IConfiguration
    {
        string Url { get; set; }
        string Branch { get; set; }
        string Env { get; set; }
    }
}