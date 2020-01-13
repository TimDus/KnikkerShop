﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnikkerShop.Context.Authentication;
using KnikkerShop.Context.IContext;
using KnikkerShop.Context.MemoryContext;
using KnikkerShop.Context.MSSQLContext;
using KnikkerShop.Models.Data;
using KnikkerShop.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KnikkerShop
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession();

            // Sql contexts
            services.AddScoped<IProductContext, MSSQLProductContext>();
            services.AddScoped<ICategorieContext, MSSQLCategorieContext>();
            services.AddScoped<IBestellingContext, MSSQLBestellingContext>();
            services.AddScoped<IKlantContext, MSSQLKlantContext>();

            // Repositories
            services.AddScoped<ProductRepository>();
            services.AddScoped<CategorieRepository>();
            services.AddScoped<BestellingRepository>();
            services.AddScoped<KlantRepository>();

            //Useraccounts and roles
            services.AddTransient<IUserStore<BaseAccount>, MSSQLUserContext>();
            services.AddTransient<IRoleStore<Role>, RoleMemoryContext>();
            services.AddIdentity<BaseAccount, Role>()
                .AddDefaultTokenProviders();    

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Home/AccesDenied";
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LoginPath = new PathString("/");
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            services.AddDistributedMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
