using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineExamProject.Application;
using OnlineExamProject.Application.Validators.Grade;
using OnlineExamProject.Infrastructure;
using OnlineExamProject.Persistence;
using OnlineExamProject.SignalR;
using OnlineExamProject.SignalR.Hubs;
using OnlineExamProject.UI.Filters;
using Serilog;

using System;

using System.Globalization;
using System.Net;

namespace OnlineExamProject.UI
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
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<RolePermissionFilter>();
               // options.Filters.Add<ValidationFilter>();
               
            })
                .AddFluentValidation(configuration => {
                    configuration.RegisterValidatorsFromAssemblyContaining<GradeAddValidator>();
                    configuration.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");

                    })
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

            services.AddPersistenceServices();
            services.AddInfrastructureServices();
            services.AddApplicationServices();
            services.AddSignalRServices();
            services.AddSession();
            services.ConfigureApplicationCookie(_ =>
            {
                _.LoginPath = new PathString("/Auth/Login");
                _.Cookie = new CookieBuilder
                {
                    Name = "AspNetCoreIdentityExampleCookie", //Olu�turulacak Cookie'yi isimlendiriyoruz.
                    HttpOnly = false, //K�t� niyetli insanlar�n client-side taraf�ndan Cookie'ye eri�mesini engelliyoruz.
                                      //Expiration = TimeSpan.FromMinutes(10), //Olu�turulacak Cookie'nin vadesini belirliyoruz.
                    SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin g�nderilmemesini belirtiyoruz.
                    SecurePolicy = CookieSecurePolicy.Always //HTTPS �zerinden eri�ilebilir yap�yoruz.
                };
                _.SlidingExpiration = true; //Expiration s�resinin yar�s� kadar s�re zarf�nda istekte bulunulursa e�er geri kalan yar�s�n� tekrar s�f�rlayarak ilk ayarlanan s�reyi tazeleyecektir.
                _.ExpireTimeSpan = TimeSpan.FromMinutes(10); //CookieBuilder nesnesinde tan�mlanan Expiration de�erinin varsay�lan de�erlerle ezilme ihtimaline kar��n tekrardan Cookie vadesi burada da belirtiliyor.
                _.AccessDeniedPath = new PathString("/Error/Error401/");                               
                // yetkili sayfaya eri�meye �al��an yetkisiz kullan�c�y� y�nlendirece�imiz sayfa

            });

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));        
            });
            services.AddNotyf(config =>
            {
                config.Position = NotyfPosition.TopRight;
                config.DurationInSeconds = 1000;
                config.HasRippleEffect = true;
                config.IsDismissable = true;
            });
            
         

            #region log
            /* ColumnOptions columnOpt = new ColumnOptions();

				Logger logger = new LoggerConfiguration()
						.WriteTo.Console()
						.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
						.WriteTo.MSSqlServer(Configuration.GetConnectionString("SQLServer"), sinkOptions: new MSSqlServerSinkOptions
							{
								AutoCreateSqlTable = true,
								TableName = "logs",
							},
									appConfiguration: null,
								columnOptions: columnOpt
			)

						.MinimumLevel.Information()
						.CreateLogger();
			*/
            #endregion
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseNotyf();
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseStatusCodePages(async context =>
            {
                var response = context.HttpContext.Response;

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized ||
                    response.StatusCode == (int)HttpStatusCode.Forbidden)
                    response.Redirect("/Error/Error401");
            });
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth}/{action=Login}/{id?}");
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


            });
            app.UseEndpoints(endpoints =>
            {
               endpoints.MapHub<GradeHub>("/GradeHub");
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });


        }
    }

}