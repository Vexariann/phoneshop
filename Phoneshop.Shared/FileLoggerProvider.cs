using Microsoft.Extensions.Logging;

namespace Phoneshop.Shared
{
    public class FileLoggerProvider : ILoggerProvider
    {
        //private readonly ConcurrentDictionary<string, FileLogger> _loggers =
        //    new(StringComparer.OrdinalIgnoreCase);

        private string path = $@"Logs\{DateTime.Today.ToShortDateString()}.txt";

        public FileLoggerProvider(string _path)
        {
            path = _path;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(path);
        }

        public void Dispose()
        {
        }
    }
}
