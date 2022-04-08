using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Logging
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        readonly CustomLoggerProviderConfiguration providerConfiguration;

        // armazena as informações
        readonly ConcurrentDictionary<string, CustomerLogger> loggers =
            new ConcurrentDictionary<string, CustomerLogger>();

        public CustomLoggerProvider(CustomLoggerProviderConfiguration Config)
        {
            providerConfiguration = Config;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, name => new CustomerLogger(name, providerConfiguration));
        }

        public void Dispose()
        {
            loggers.Clear();
        }
    }
}
