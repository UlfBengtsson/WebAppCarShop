using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebAppCarShop.Database;
using WebAppCarShop.Models.Repo;
using WebAppCarShop.Models.Service;
using WebAppCarShop.Swagger;

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
                // Cookie settings  
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login  
                options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout  
                options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied  
                options.SlidingExpiration = true;
            });


            //------------------------- JWT -------------------------------------------------------------

            services.AddAuthentication()
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtOption => 
                {
                    jwtOption.SaveToken = true;
                    jwtOption.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(5),
                        ValidIssuer = Configuration["JWTConfiguration:Issuer"],
                        ValidAudience = Configuration["JWTConfiguration:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["JWTConfiguration:SigningKey"]))
                    };
                }
            );


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

            //------------------------- CORS -----------------------------------------------------------

            services.AddCors(options =>
            {
                options.AddPolicy("ReactPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")// "*" is like saying any and all are okay
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            //------------------------ Swagger ----------------------------------------------------------
            //Made a class to contain the bigger part of the settings to lessen bloting
            SwaggerModel.SwaggerSetup(services, new OpenApiInfo()
            {
                Version = "v1",
                Title = "Car Shop API",
                Description = "ASP.NET Core 3.1 with API"
            });

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

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cars API V1");
            });

            app.UseRouting();

            app.UseCors();

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
