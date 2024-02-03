using System.Diagnostics.CodeAnalysis;

namespace THEJOB.Cachorro.Api.Extensions.Telemetria
{
    [ExcludeFromCodeCoverage]
    public static class LoggingExtensions
    {
        public static void AddLogExtensions(
            this ILoggingBuilder logging,
            IConfiguration configuration)
        {
            logging.ClearProviders();
            logging.AddConsole();
            logging.AddApplicationInsights(configureTelemetryConfiguration: (config) =>
            {
                config.ConnectionString = configuration.GetSection("ConnectionString:ApplicationInsights").Value;
            }, configureApplicationInsightsLoggerOptions: (options) => { });
        }
    }
}