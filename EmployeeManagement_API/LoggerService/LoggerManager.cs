using Contracts;
using NLog;

namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public async Task LogDebugAsync(string message) =>
            await Task.Run(() => logger.Debug(message)).ConfigureAwait(false);
        public async Task LogErrorAsync(string message) => 
            await Task.Run(() => logger.Error(message)).ConfigureAwait(false);
        public async Task LogInfoAsync(string message) =>
            await Task.Run(() => logger.Info(message)).ConfigureAwait(false);
        public async Task LogWarnAsync(string message) =>
            await Task.Run(() => logger.Warn(message)).ConfigureAwait(false);
    }
}
