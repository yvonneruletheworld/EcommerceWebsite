using EcommerceWebsite.Api.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.WebAdmin
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
            DependencyInjectionSystemConfig(services);
        }
        private void DependencyInjectionSystemConfig(IServiceCollection services)
        {
            services.AddScoped<IHUIApiServices, HUIApiServices>();
            services.AddScoped<IDanhMucApiServices, DanhMucApiServices>();
            services.AddScoped<ISanPhamApiServices, SanPhamApiServices>();
            services.AddScoped<IKhuyenMaiApiServices, KhuyenMaiApiServices>();
            services.AddScoped<INhanHieuApiServices, NhanHieuApiServices>();
            //services.AddScoped<IKhachHangServices, KhachHangServices>();
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
