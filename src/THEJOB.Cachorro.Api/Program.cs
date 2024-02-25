using THEJOB.Cachorro.Api.Extensions.AppConfiguration;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using THEJOB.Cachorro.Api.Extensions.Database;
using THEJOB.Cachorro.Api.Extensions.Swagger;
using THEJOB.Cachorro.Api.Extensions.Telemetria;
using Microsoft.Extensions.Azure;
using Azure.Identity;
using THEJOB.Cachorro.Api.Extensions.KeyVault;
using THEJOB.Cachorro.Api.Extensions.Auth;

namespace THEJOB.Cachorro.Api
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        protected Program() { }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthExtension(builder.Configuration);

            builder.Services.AddControllers()
                            .AddJsonOptions(opt =>
                            {
                                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                                opt.JsonSerializerOptions.WriteIndented = true;
                                opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;

                            });

            builder.Services.AddRouting(opt =>
            {
                opt.LowercaseUrls = true;
                opt.LowercaseQueryStrings = true;
            });

            builder.Services.AddEndpointsApiExplorer();

            //Extensions
            builder.Services.AddKeyVaultExtension(builder.Configuration);
            builder.Logging.AddLogExtension(builder.Configuration);
            builder.Services.AddDatabaseExtension(builder.Configuration);
            builder.Services.AddTelemetriaExtension(builder.Configuration);
            builder.Services.AddSwaggerExtension();
            builder.Configuration.AddAppConfigurationExtension(builder.Services);

            var app = builder.Build();

            //Extensions
            app.UseSwaggerExtension();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseAzureAppConfiguration();

            app.Run();
        }
    }
}
