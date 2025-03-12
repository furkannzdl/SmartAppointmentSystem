using System;

namespace SmartAppointmentBackend.Services
{
    public sealed class LoggerService
    {
        private static LoggerService _instance;
        private static readonly object _lock = new();

        private LoggerService() { }

        public static LoggerService GetInstance()
        {
            lock (_lock)
            {
                return _instance ??= new LoggerService();
            }
        }

        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.UtcNow}] {message}");
        }
    }
}
