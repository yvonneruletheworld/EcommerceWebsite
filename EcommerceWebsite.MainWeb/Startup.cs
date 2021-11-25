using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EcommerceWebsite.Api.Interface;
using EcommerceWebsite.Data.Identity;
using Microsoft.AspNetCore.Identity;
using EcommerceWebsite.Api.Mapper;

namespace EcommerceWebsite.MainWeb
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
            services.AddHttpClient();

            services.AddHttpContextAccessor();
            services.AddControllersWithViews();

            //var str = Configuration.GetConnectionString("EcommerceWebsiteDatabase");
            //services.AddDbContext<EcomWebDbContext>(options =>
            //    options.UseSqlServer(str));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<EcomWebDbContext>()
            //    .AddClaimsPrincipalFactory<MyUserClaimsPrincipalFactoryService>()
            //    .AddDefaultTokenProviders();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            //DI
            DependencyInjectionSystemConfig(services);
            services.AddAutoMapper(typeof(AutoMapping));

            //var emailConfig = Configuration
            //    .GetSection("EmailSenderConfig")
            //    .Get<EmailConfiguration>();
            //services.AddSingleton(emailConfig);
        }

        private void DependencyInjectionSystemConfig(IServiceCollection services)
        {
            services.AddScoped<IHUIApiServices, HUIApiServices>();
            services.AddScoped<IDanhMucApiServices, DanhMucApiServices>();
            services.AddScoped<ISanPhamApiServices, SanPhamApiServices>();
            services.AddScoped<IKhuyenMaiApiServices, KhuyenMaiApiServices>();
            services.AddScoped<INhanHieuApiServices, NhanHieuApiServices>();
            services.AddScoped<IKhachHangApiServices, KhachHangApiServices>();
            //services.AddScoped<IEmailSenderServices, EmailSenderServices>();
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

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{type=Main}/{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
