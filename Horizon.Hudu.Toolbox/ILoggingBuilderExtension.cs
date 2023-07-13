using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Hudu.Toolbox
{
    public static class ILoggingBuilderExtension
    {
        public static ILoggingBuilder AddInterceptor(this ILoggingBuilder builder)
        {
            builder.AddProvider(new LoggingInterceptorProvider());

            return builder;
        }
    }

    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddLoggingInterceptor(this IServiceCollection services)
        {
            return services.AddSingleton<LoggingInterceptor>(LoggingInterceptorProvider.LoggingInterceptor);
        }
    }

    public class LoggingInterceptorEventArgs
    {
        public readonly LogLevel LogLevel;
        public readonly EventId EventId;
        public readonly object? State;
        public readonly Exception? Exception;
        public readonly string FormattedMessage;

        public LoggingInterceptorEventArgs(LogLevel logLevel, EventId eventId, object? state, Exception? exception, string formattedMessage)
        {
            this.LogLevel = logLevel;
            this.EventId = eventId;
            this.State = state;
            this.Exception = exception;
            this.FormattedMessage = formattedMessage;
        }
    }

    public delegate void LoggingInterceptorEventHandler(Object? sender, LoggingInterceptorEventArgs e);

    public class LoggingInterceptor: ILogger
    {

        public LoggingInterceptorEventHandler? OnLog;

        IDisposable ILogger.BeginScope<TState>(TState state)
        {
            throw new NotImplementedException("Scoping not supported by LoggingInterceptor");
        }

        bool ILogger.IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if(OnLog!=null)
            {
                lock (OnLog)
                {
                    OnLog(null, new LoggingInterceptorEventArgs(logLevel, eventId, state, exception, formatter(state, exception)));
                }
            }            
        }
    }

    public class LoggingInterceptorProvider : ILoggerProvider
    {
        internal  readonly static LoggingInterceptor LoggingInterceptor = new LoggingInterceptor();
        public ILogger CreateLogger(string categoryName) => LoggingInterceptor;

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
