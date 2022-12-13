using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.Identity.Web;
using System.Globalization;
using System.Net;
using System.Threading;
using EasyCaching.Interceptor.Castle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Talleres.Infraestructure.DataBase.Context;
using Talleres.Intefaces.UserStories;
using Talleres.UserStories;
using Talleres.Intefaces.DataBase.Context;
using Talleres.Infraestructure.Smtp;
using Microsoft.Extensions.Hosting;
using Talleres.Intefaces.Smtp;
using Talleres.Models;
using Hangfire;
using Hangfire.SqlServer;

namespace WebApiTalleres.Infraestructure
{
    internal static class IServiceCollectionExtend
    {
        private const string CnnString = "DBTalleres";
        private const string CnnStringIntelisis = "DBIntelisis";

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            IdentityModelEventSource.ShowPII = true;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                   | SecurityProtocolType.Tls11
                                                   | SecurityProtocolType.Tls12;
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiTalleres", Version = "v1" });
            });
            services.AddMicrosoftIdentityWebApiAuthentication(configuration);

            string corsDomains = "https://localhost:44394";
            string[] domains = corsDomains.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            services.AddCors(o => o.AddPolicy("AppCORSPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials()
                       .WithOrigins(domains);
            }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
            services.AddDbContext<talleresContext>(opt =>
            {
                opt.UseLazyLoadingProxies(true).ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));
                opt.UseSqlServer(configuration[CnnString], sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });
                opt.EnableSensitiveDataLogging();
            }, ServiceLifetime.Transient).BuildServiceProvider();
            services.AddScoped<DbContext, talleresContext>();

            services.AddDbContext<ColegioAlemanContext>(opt =>
            {
                opt.UseLazyLoadingProxies(true).ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));
                opt.UseSqlServer(configuration[CnnStringIntelisis], sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });
                opt.EnableSensitiveDataLogging();
            }, ServiceLifetime.Transient).BuildServiceProvider();

            services.AddScoped<DbContext, ColegioAlemanContext>();
            services.AddSingleton<EmailSenderHostedService>();
            services.AddSingleton<IHostedService>(serviceProvider => serviceProvider.GetService<EmailSenderHostedService>());
            services.AddSingleton<IEmailSender>(serviceProvider => serviceProvider.GetService<EmailSenderHostedService>());
            services.Configure<SmtpOptions>(configuration.GetSection("Smtp"));

            services.AddHangfire(config => config
              .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
              .UseSimpleAssemblyNameTypeSerializer()
              .UseRecommendedSerializerSettings()
              .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
              {
                  CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                  SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                  QueuePollInterval = TimeSpan.Zero,
                  UseRecommendedIsolationLevel = true,
                  DisableGlobalLocks = true,
                  SchemaName = "talleres"
              }));
            services.AddHangfireServer();
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            var mx = new CultureInfo("es-MX");
            Thread.CurrentThread.CurrentCulture = mx;

            Thread.CurrentThread.CurrentUICulture = mx;
            CultureInfo.DefaultThreadCurrentCulture = mx;
            CultureInfo.DefaultThreadCurrentUICulture = mx;
            services.Configure<ApiBehaviorOptions>(o => { o.SuppressModelStateInvalidFilter = true; });

            services.AddEasyCaching(opt =>
            {
                opt.UseInMemory("m1");
            });
            services.ConfigureCastleInterceptor(opt => opt.CacheProviderName = "m1");
            services.AddHttpContextAccessor();

            services.AddCors(opt =>
            {
                opt.AddPolicy("_AllowSpecificOrigins", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod().WithOrigins("*");
                    builder.WithMethods("GET, POST, PUT, DELETE, OPTIONS");
                });
            });
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }

        public static void RegisterInterfaces(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //UserStories
            services.AddTransient<IAlumnoUserStory<TblAlumno>, AlumnoUserStory>();
            services.AddTransient<INivelesAcademicoUStory<TblNivelesAcademico>, NivelesAcademicosUStory>();
            services.AddTransient<IProgramasUserStory<TblPrograma>, ProgramasUserStory>();
            services.AddTransient<IGenerosUserStory<TblGenero>, GenerosUserStory>();
            services.AddTransient<IIntelisisUserStory<Cealumno, Art, ListaPreciosTallere>, IntelisisUserStory>();
            services.AddTransient<ISyncUserStory<Cealumno>, SyncUserStory>();
            services.AddTransient<INotificationUserStory, NotificationsUserStory>();
            ////Context
            //services.AddTransient<IGlobalContext<TblAlumno>, DataContext<TblAlumno>>();
            //services.AddTransient<IGlobalContext<TblNivelesAcademico>, DataContext<TblNivelesAcademico>>();
            //services.AddTransient<IGlobalContext<TblPrograma>, DataContext<TblPrograma>>();
            //services.AddTransient<IGlobalContext<TblGenero>, DataContext<TblGenero>>();
            //services.AddTransient<IGlobalContext<TblCatAlumno>, SyncContext<TblCatAlumno>>();
            services.AddTransient<IGlobalContext<Cealumno>, IntelisisContext<Cealumno>>();
            services.AddTransient<IGlobalContext<Art>, IntelisisContext<Art>>();
            services.AddTransient<IGlobalContext<ListaPreciosTallere>, IntelisisContext<ListaPreciosTallere>>();
            services.AddTransient<IGlobalContext<CecicloEscolar>, IntelisisContext<CecicloEscolar>>();
        }
    }
}
