using DEPLOY.Cachorro.Api.Extensions.Swagger;
using Microsoft.EntityFrameworkCore;
using THEJOB.Cachorro.Api.Extensions.Telemetria;
using THEJOB.Cachorro.Repository;

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