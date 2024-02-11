using System.Diagnostics.CodeAnalysis;

namespace THEJOB.Cachorro.Api.Extensions.Telemetria
{
    [ExcludeFromCodeCoverage]
    public static class LoggingExtensions
    {
        public static void AddLogExtension(
            this ILoggingBuilder logging,
            ConfigurationManager configuration)
        {
            logging.ClearProviders();
            logging.AddConsole();

            logging.AddApplicationInsights(
               configureTelemetryConfiguration: (config) =>
               {
                   config.ConnectionString = configuration.GetSection("ConnectionStrings:ApplicationInsights").Value;
               },
               configureApplicationInsightsLoggerOptions: (options) => { });
        }
    }
}