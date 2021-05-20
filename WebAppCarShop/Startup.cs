using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarShop.Database;
using WebAppCarShop.Models.Repo;
using WebAppCarShop.Models.Service;

namespace WebAppCarShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //------------------------- connection to database -----------------------------------------
            services.AddDbContext<CarShopDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //------------------------- Identity -------------------------------------------------------
            services.AddIdentity<IdentityUser, IdentityRole>()
                        .AddEntityFrameworkStores<CarShopDbContext>()
                        .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            //------------------------- services IoC ---------------------------------------------------
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IInsuranceService, InsuranceService>();

            //------------------------- repo IoC -------------------------------------------------------
            //services.AddSingleton<ICarRepo, InMemoryCarRepo>();
            services.AddScoped<ICarRepo, DatabaseCarRepo>();
            services.AddScoped<ISaleRepo, SaleRepo>();
            services.AddScoped<ICarBrandRepo, CarBrandRepo>();
            services.AddScoped<IInsuranceRepo, InsuranceRepo>();
            services.AddScoped<ICarInsuranceRepo, CarInsuranceRepo>();


            //services.AddControllersWithViews();
            services.AddMvc();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();//forces to use HTTPS
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();// Add this - are you login?
            app.UseAuthorization();// Add this too - do you have the right to do it?

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
