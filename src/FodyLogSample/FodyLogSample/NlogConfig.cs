using NLog;
using NLog.Layouts;
using NLog.Targets.Wrappers;
using System.Text;

namespace FodyLogSample
{
    internal class NlogConfig
    {
        public NlogConfig()
        {
            var logConfig = new NLog.Config.LoggingConfiguration();
            var fileName = $"{DateTime.Now:yyyy-MM-dd}.log";
            var path = Path.Combine("C:\\ProgramData\\Temp", "Logs");
            var minLevel = LogLevel.AllLoggingLevels.First();
            var maxLevel = LogLevel.AllLoggingLevels.Last();

            // Targets where to log to: File and Console
            var traceLoggerAsync = new AsyncTargetWrapper(new NLog.Targets.ColoredConsoleTarget("traceLoggerAsync")
            {
                Layout = new SimpleLayout(@"${level}|${logger}|${message}|${exception:format=toString,Data}")
            });

            var defaultLoggerAsync = new AsyncTargetWrapper(new NLog.Targets.FileTarget("defaultLoggerAsync")
            {
                Encoding = Encoding.UTF8,
                FileName = Path.Combine(path, fileName),
                Layout = new SimpleLayout(@"${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname} v${assembly-version}|${level}|${logger}|${message}|${exception:format=toString,Data}"),
                ArchiveAboveSize = 10240,
                MaxArchiveFiles = 10240
            });

            var fatalLoggerAsync = new AsyncTargetWrapper(new NLog.Targets.FileTarget("fatalLoggerAsync")
            {
                Encoding = Encoding.UTF8,
                FileName = Path.Combine(path, nameof(LogLevel.Fatal), fileName),
                Layout = new SimpleLayout(@"${date:format=yyyy-MM-dd HH\:mm\:ss}|${processname} v${assembly-version}|${level}|${logger}|||${message}|${exception:format=toString,Data:innerFormat=toString:maxInnerExceptionLevel=100:innerExceptionSeparator=\r\n:separator=\r\n:exceptionDataSeparator=\r\n}"),
                ArchiveAboveSize = 10240,
                MaxArchiveFiles = 10240
            });

            // Rules for mapping loggers to targets 
            logConfig.AddTarget(nameof(traceLoggerAsync), traceLoggerAsync);
            logConfig.AddTarget(nameof(defaultLoggerAsync), defaultLoggerAsync);
            logConfig.AddTarget(nameof(fatalLoggerAsync), fatalLoggerAsync);

            logConfig.AddRuleForAllLevels(traceLoggerAsync);
            logConfig.AddRule(minLevel, maxLevel, defaultLoggerAsync);
            logConfig.AddRule(LogLevel.Error, maxLevel, fatalLoggerAsync);

            // Apply config           
            LogManager.Configuration = logConfig;
        }
    }
}
