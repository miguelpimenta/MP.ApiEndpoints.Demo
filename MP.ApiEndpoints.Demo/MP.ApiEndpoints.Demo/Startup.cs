using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MP.ApiEndpoints.Demo.Core;
using MP.ApiEndpoints.Demo.Infrastructure;

namespace MP.ApiEndpoints.Demo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        //public ILifetimeScope AutofacContainer { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddControllers()
            //    // utf8json
            //    .AddMvcOptions(option =>
            //    {
            //        option.OutputFormatters.Clear();
            //        option.OutputFormatters.Add(
            //            new Utf8JsonOutputFormatter(StandardResolver.Default));
            //        option.InputFormatters.Clear();
            //        option.InputFormatters.Add(
            //            new Utf8JsonInputFormatter());
            //    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MP.ApiEndpoints.Demo",
                    Version = "v1"
                });
                //c.EnableFeatureFilter();
                c.EnableAnnotations();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //! Autofac container
            builder.RegisterModule(new CoreModule());
            builder.RegisterModule(new InfrastructureModule(Configuration));
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MP.ApiEndpoints.Demo v1"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}