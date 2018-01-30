using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Common.Logger
{
    public static class LoggerExtensions
    {
        public static ILoggerFactory AddESLogger(this ILoggerFactory factory, IServiceProvider serviceProvider, IConfigurationSection optionSection, string indexName = null)
        {
            factory.AddProvider(new ESLoggerProvider(serviceProvider, optionSection, indexName));
            return factory;
        }
    }
}
