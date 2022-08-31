using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from my first middleware\n");
            //    await next();
            //    await context.Response.WriteAsync("Hello from my first middleware Responce\n");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from my Second middleware\n");
            //    await next();
            //    await context.Response.WriteAsync("Hello from my Second middleware Responce\n");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from my Third middleware\n");
            //    await next();
            //    await context.Response.WriteAsync("Hello from my Third middleware Responce\n");
            //});

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        if (env.IsDevelopment())
            //        {
            //            await context.Response.WriteAsync("Hello from dev");
            //        }
            //        else if (env.IsProduction())
            //        {
            //            await context.Response.WriteAsync("Hello from Prod");
            //        }
            //        else if (env.IsStaging())
            //        {
            //            await context.Response.WriteAsync("Hello from Stag");
            //        }
            //        else
            //            await context.Response.WriteAsync(env.EnvironmentName);
            //    });
            //});
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!\n");
            //    });
            //});
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/Yash", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello Yash!\n");
            //    });
            //});
        }
    }
}
