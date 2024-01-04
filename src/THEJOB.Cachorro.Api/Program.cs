using DEPLOY.Cachorro.Api.Extensions.Swagger;
using THEJOB.Cachorro.Api.Extensions.Telemetria;

namespace THEJOB.Cachorro.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

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