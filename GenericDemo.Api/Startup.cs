namespace GenericDemo.Api
{
    using GenericDemo.Api.Extensions;
    using GenericDemo.Api.Middlewares;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    using Swashbuckle.AspNetCore.SwaggerUI;

    public class Startup
    {
        private readonly OpenApiInfo openApiInfo;

        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.openApiInfo = new OpenApiInfo { Title = "Generic Demo Api", Description = "", Version = "v1" };
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                c =>
                    {
                        c.SwaggerDoc(
                            "v1",
                            openApiInfo);
                    });

            services.RegisterWebLayerDependencies(this.configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseHttpsRedirection();

            app.UseSwagger().UseSwaggerUI(
                c =>
                    {
                        c.SwaggerEndpoint($"/swagger/{openApiInfo.Version}/swagger.json", openApiInfo.Title);
                        c.DocExpansion(DocExpansion.None);
                    });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
