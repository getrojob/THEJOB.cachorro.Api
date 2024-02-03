using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;
using System.Diagnostics.CodeAnalysis;

namespace THEJOB.Cachorro.Api.Extensions.Telemetria
{
    [ExcludeFromCodeCoverage]
    public static class AppInsightsExtensions
    {
        public static void AddAppInsights(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddApplicationInsightsTelemetry(configuration.GetSection("ConnectionString:ApplicationInsights").Value)
                .ConfigureTelemetryModule<QuickPulseTelemetryModule>((module, o) => module.AuthenticationApiKey = configuration.GetSection("ApplicationInsights:ApiKey").Value);
        }
    }
}