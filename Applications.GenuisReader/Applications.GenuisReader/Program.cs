using GeniusReader.WebApp;

namespace Applications.GenuisReader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var allowedOrigins = "_allowedOrigins";
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: allowedOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200", "https://localhost:4200");
                        policy.WithHeaders("content-type");
                        policy.WithMethods("GET", "POST", "PUT");
                    });
            });
            // Add services to the container.
            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(allowedOrigins);

            startup.Configure(app, builder.Environment);
        }
    }
}
