﻿using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;
using System.Diagnostics.CodeAnalysis;

namespace THEJOB.Cachorro.Api.Extensions.Telemetria
{
    [ExcludeFromCodeCoverage]
    public static class AppInsightsExtensions
    {
        public static void AddTelemetriaExtension(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services
                .AddApplicationInsightsTelemetry(options =>
                {
                    options.ConnectionString = configuration.GetSection("ConnectionsString:ApplicationInsights").Value;
                })
                .ConfigureTelemetryModule<QuickPulseTelemetryModule>((module, o) =>
                {
                    module.AuthenticationApiKey = configuration.GetSection("ApplicationInsights:ApiKey").Value;
                });

            services
                .ConfigureTelemetryModule<DependencyTrackingTelemetryModule>((module, o) =>
                {
                    module.EnableSqlCommandTextInstrumentation = true;
                });
        }
    }
}