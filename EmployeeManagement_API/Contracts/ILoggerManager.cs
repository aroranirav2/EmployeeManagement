namespace Contracts
{
    public interface ILoggerManager
    {
        Task LogInfoAsync(string message);
        Task LogWarnAsync(string message);
        Task LogDebugAsync(string message);
        Task LogErrorAsync(string message);
    }
}
