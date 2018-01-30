using Change.Common.ElasticSearch;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Common.Logger
{
    public class ESLoggerProvider : ILoggerProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IConfigurationSection _optionSection;
        private readonly ESClientProvider _esClient;

        public ESLoggerProvider(IServiceProvider serviceProvider, IConfigurationSection optionSection, string indexName = null)
        {
            _httpContextAccessor = (IHttpContextAccessor)serviceProvider.GetService(typeof(IHttpContextAccessor));
            _optionSection = optionSection;
            _esClient = (ESClientProvider)serviceProvider.GetService(typeof(ESClientProvider));
            _esClient.EnsureIndexWithMapping<LogEntry>(indexName);
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new ESLogger(_esClient, _httpContextAccessor, categoryName, FindLevel(categoryName));
        }

        private LogLevel FindLevel(string categoryName)
        {
            var configLevel = _optionSection.GetSection("LogLevel")["ElasticSearch"] ?? _optionSection.GetSection("LogLevel")["Default"];
            if (!string.IsNullOrEmpty(configLevel))
            {
                return (LogLevel)Enum.Parse(typeof(LogLevel), configLevel);
            }
            return LogLevel.Debug;
        }

        public void Dispose()
        {
            // Nothing to do
        }
    }
}
