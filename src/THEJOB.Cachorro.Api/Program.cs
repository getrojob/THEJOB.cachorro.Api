using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using THEJOB.Cachorro.Api.Extensions.Database;
using THEJOB.Cachorro.Api.Extensions.Swagger;
using THEJOB.Cachorro.Api.Extensions.Telemetria;
using Microsoft.Extensions.Azure;
using Azure.Identity;

namespace THEJOB.Cachorro.Api
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddRouting(opt =>
            {
                opt.LowercaseUrls = true;
                opt.LowercaseQueryStrings = true;
            });

            builder.Services.AddAzureClients(clientBuilder =>
            {
                clientBuilder.AddSecretClient(
                    builder.Configuration.GetSection("KeyVault"));
                clientBuilder.UseCredential(new DefaultAzureCredential());
            });

            //Extensions
            builder.Logging.AddLogExtension(builder.Configuration);
            builder.Services.AddDatabaseExtension(builder.Configuration);
            builder.Services.AddTelemetriaExtension(builder.Configuration);
            builder.Services.AddSwaggerExtension();

            var app = builder.Build();

            //Extensions
            app.UseSwaggerExtension();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}