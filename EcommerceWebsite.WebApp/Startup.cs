using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Services.Interfaces.System;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Services.Services.System;
using EcommerceWebsite.Services.Services.Main;
using EcommerceWebsite.WebApp.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebsite.Data.Identity;
using Microsoft.AspNetCore.Identity;
using ValensBankCore.Services.Services;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
using EcommerceWebsite.Services.Services.ExtraServices;
using EcommerceWebsite.Data.Configurations;

namespace EcommerceWebsite.WebApp
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
            services.AddControllersWithViews();


            var str = Configuration.GetConnectionString("EcommerceWebsiteDatabase");
            services.AddDbContext<EcomWebDbContext>(options =>
                options.UseSqlServer(str));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<EcomWebDbContext>()
                .AddClaimsPrincipalFactory<MyUserClaimsPrincipalFactoryService>()
                .AddDefaultTokenProviders();

            services.AddHttpContextAccessor();

            DependencyInjectionSystemConfig(services);
            services.AddAutoMapper(typeof(AutoMapping));

            var emailConfig = Configuration
                .GetSection("EmailSenderConfig")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
        }
        //Khai báo
        private void DependencyInjectionSystemConfig(IServiceCollection services)
        {
            services.AddScoped<ISanPhamServices, SanPhamServices>();
            services.AddScoped<IKhachHangServices, KhachHangServices>();
            services.AddScoped<IEmailSenderServices, EmailSenderServices>();
            services.AddScoped<IBoPhanServices, BoPhanServices>();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{type=Main}/{controller=Home}/{action=Index}/{id?}");
            });

        }


    }
}
