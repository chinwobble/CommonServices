namespace WebAccessService.Common
{
    public interface IConfigurationProvider
    {
        /// <summary>
        /// Hostname including protocol and port of the EVE XML API
        /// </summary>
        string EveAPIHost { get; }
        /// <summary>
        /// max number of calls per second 
        /// </summary>
        int EveAPIRateLimit { get; }
    }
}
