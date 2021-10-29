using EcommerceWebsite.Data.Configurations;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Services.Interfaces.System;
using EcommerceWebsite.Services.Services.ExtraServices;
using EcommerceWebsite.Services.Services.Main;
using EcommerceWebsite.Services.Services.System;
using EcommerceWebsite.Utilities.Mapper;
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
using ValensBankCore.Services.Services;

namespace EcommerceWebsite.Api
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


            DependencyInjectionSystemConfig(services);

            

            services.AddSwaggerGen(s =>
           {
               s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Swagger EcommerceShop", Version = "v1" });
           });

            services.AddAutoMapper(typeof(AutoMapping));

            var emailConfig = Configuration
                .GetSection("EmailSenderConfig")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
        }


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

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Ecomshop V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
