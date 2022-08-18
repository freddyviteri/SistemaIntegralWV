using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;
using WordVision.ec.Application.DTOs.Settings;
using WordVision.ec.Application.Interfaces.Shared;
using WordVision.ec.Infrastructure.Data.Contexts;
using WordVision.ec.Infrastructure.Data.Identity.Models;
using WordVision.ec.Infrastructure.Shared.Services;
using WordVision.ec.Web.Services;
using WordVision.ec.Web.Services.Email;

namespace WordVision.ec.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMultiLingualSupport(this IServiceCollection services)
        {
            #region Registering ResourcesPath

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            #endregion Registering ResourcesPath

            services.AddMvc()
               .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
               .AddDataAnnotationsLocalization(options =>
               {
                   options.DataAnnotationLocalizerProvider = (type, factory) =>
                       factory.Create(typeof(SharedResource));
               });
            services.AddRouting(o => o.LowercaseUrls = true);
            services.AddHttpContextAccessor();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var cultures = new List<CultureInfo> {
                    new CultureInfo("es"),
                    new CultureInfo("en"),
                    new CultureInfo("ar"),
                    new CultureInfo("fr"),
                    new CultureInfo("fa"),
                    new CultureInfo("pt-BR"),
                };
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("es");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
        }

        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddPersistenceContexts(configuration);
            services.AddAuthenticationScheme(configuration);
        }

        private static void AddAuthenticationScheme(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //}).AddCookie(options =>
            //{
            //    options.LoginPath = new PathString("/Index");
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
            //});

            //services.AddMvc().AddRazorPagesOptions(options =>
            //{
            //    options.Conventions.AuthorizeFolder("/");
            //    options.Conventions.AllowAnonymousToPage("/Index");
            //});

            services.AddMvc(o =>
            {
                //Add Authentication to all Controllers by default.
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                o.Filters.Add(new AuthorizeFilter(policy));
            });


        }

        private static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {

                services.AddDbContext<RegistroDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
                services.AddDbContext<IdentityContext>(options =>
                    options.UseInMemoryDatabase("IdentityDb"));
            }
            else
            {
                services.AddDbContext<RegistroDbContext>(options => {
                    options.UseSqlServer(configuration.GetConnectionString("RegistroConnection"),
    sqlServerOptions => sqlServerOptions.CommandTimeout(60));  options.EnableSensitiveDataLogging(true);
                });
                services.AddDbContext<IdentityContext>(options => { options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")); 
                    options.EnableSensitiveDataLogging(true);
            });
                //services.AddDbContext<ActiveContext>(options => options.UseSqlServer(configuration.GetConnectionString("ActiveConnection")));
            }
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<IdentityContext>().AddDefaultUI().AddDefaultTokenProviders();


        }

        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.Configure<CacheSettings>(configuration.GetSection("CacheSettings"));
            services.Configure<EmailSenderOptions>(configuration.GetSection("EmailSenderOptions"));
            services.AddTransient<IDateTimeService, SystemDateTimeService>();
            services.AddTransient<IEmailSender, EmailSender>();
            //services.AddTransient<IMailService, SMTPMailService>();
            services.AddTransient<IAuthenticatedUserService, AuthenticatedUserService>();
        }
    }
}
