using Catering.Core;
using Catering.Core.Domain.Entities;
using Catering.Core.Enums;
using Catering.Core.Factories;
using Catering.Web.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CateringWeb
{
    public class Startup
    {
        public static User CurrentUser;

        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            CurrentUser = new User() { Id = 2 };
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPasswordHasher<User>, CustomPasswordHasher>();

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            Kernel.DB = DbFactory.Create(ServerType.SqlServer, connectionString);
            Kernel.CurrentUser = Kernel.DB.UserRepository.Get("admin");

            services.AddScoped(serviceProvider =>
            {
                return Kernel.DB;
            });

            services.AddTransient<IUserStore<User>, UserStore>();
            services.AddTransient<IRoleStore<Role>, RoleStore>();

            services.AddIdentity<User, Role>();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.LoginPath = "/Account/Index";
            }
            );

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Chief}/{action=Index}/{id?}");
            });
        }
    }
}
