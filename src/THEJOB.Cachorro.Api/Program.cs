using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using THEJOB.Cachorro.Api.Extensions.Swagger;
using THEJOB.Cachorro.Api.Extensions.Telemetria;
using THEJOB.Cachorro.Repository;

namespace THEJOB.Cachorro.Api
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<CachorroContext>(options =>
            {
                options.UseInMemoryDatabase("Cachorros");
            });

            builder.Logging.AddLogExtensions(builder.Configuration);
            builder.Services.AddAppInsights(builder.Configuration);
            builder.Services.AddSwagger();

            var app = builder.Build();

            app.UseSwaggerTHEJOB();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}