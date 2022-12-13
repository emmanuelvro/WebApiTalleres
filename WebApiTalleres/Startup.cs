using Autofac;
using EasyCaching.Interceptor.Castle;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiTalleres.Filters;
using WebApiTalleres.Infraestructure;

namespace WebApiTalleres
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.ConfigureServices();
            services.RegisterInterfaces();
            services.AddDbContext(Configuration);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.ConfigureCastleInterceptor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiTalleres v1"));
            }
            app.UseCors("AppCORSPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware(typeof(GlobalExceptionFilter));

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseHangfireDashboardCustomOptions(new HangfireDashboardCustomOptions
            {
                DashboardTitle = () => "<img src='https://humboldt.edu.mx/wp-content/uploads/2017/10/LogoWeb226-1.png' width='180px' style='position:relative;top:-13px'>"
            });

            app.UseHangfireDashboard("/servicios", new DashboardOptions()
            {
                Authorization = new[] { new CustomAuthorizeFilter() }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
