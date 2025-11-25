using Booking_PP.Models;
using Microsoft.OpenApi;

namespace Booking_PP
{
    class Program()
    {
        static void Main()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDbContext<ApplicationContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Booking_PP", Version = "v1" });
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking_PP V1");
            });
            app.MapSwagger();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}