namespace ApiSep.Library.Interfaces
{
    public interface ISenderEnvironment
    {
        string SenderComputerIp { get; set; }
        string SentFromUrl { get; set; }
        string UserAgent { get; set; }
        string Browser { get; set; }
        string BrowserVersion { get; set; }

    }
}
