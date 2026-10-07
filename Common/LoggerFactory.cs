using System;

namespace Common
{
    public static class LoggerFactory
    {
        public static ILogger Create(LogType logType)
        {
            //return logType switch
            //{
            //    LogType.console => new ConoleLogger(),
            //    LogType.file => new FileLogger(),
            //    _ => throw new ArgumentException("The name of log type is invalid!", nameof(logType))
            //};

            switch (logType)
            {
                case LogType.console:
                    return new ConoleLogger();
                case LogType.file:
                    return new FileLogger();
                default:
                    throw new ArgumentException("The name of log type is invalid!", nameof(logType));
            }
        }
    }
}
