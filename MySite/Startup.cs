using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySite.Domain;
using MySite.Domain.Repositories.Abstract;
using MySite.Domain.Repositories.EntityFramework;
using MySite.Service;

namespace MySite
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            //config appsettings.json
            Configuration.Bind("Project", new Config());

            //funcs as services
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<DataManager>();

            //connect context to DB
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionStrings));
             
            //option identity sys
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false; 
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //option authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "mySiteAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accesdenied";
                options.SlidingExpiration = true; 
            });

            //auth policy for admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            //MVC
            services.AddControllersWithViews( x=>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })                        //Support version asp.net core 3.0
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider(); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //js, css è ò.ä.
            app.UseStaticFiles();

            app.UseRouting();

            //auth connection
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}