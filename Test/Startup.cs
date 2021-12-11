using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Test.Middlewares;
using Test.Services;
using Test.Services.Impl;

namespace Test
{
    public class Startup
    {
        private readonly IConfiguration _cfg;
        public Startup(IConfiguration cfg)
        {
            _cfg = cfg;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IHttpClient, DefaultHttpClient>();
            services.AddTransient<IHttpClient, CustomHttpClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandler>();
            app.UseRouting();

            app.UseMiddleware<LogMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
