using Microsoft.Extensions.Logging;

namespace Phoneshop.Shared
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath = $@"Logs\{DateTime.Today.ToShortDateString()}.txt";
        private readonly string _name;

        public FileLogger(string name)
        {
            _name = name;
        }

        public IDisposable BeginScope<TState>(TState state) where TState : notnull
        {
            return default;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            try
            {
                using StreamWriter file = new(_filePath, append: true);

                file.WriteLine($"[{eventId.Id,2}: {logLevel,-12}] {_name} - {formatter(state, exception)}");
            }
            catch
            {
                string text = $"[{DateTime.Now} Information] Initializing Log file";

                File.WriteAllText(_filePath, text);
            }
        }
    }
}
