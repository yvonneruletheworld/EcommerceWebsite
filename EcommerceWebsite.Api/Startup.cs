using EcommerceWebsite.Api.Mapper;
using EcommerceWebsite.Data.Configurations;
using EcommerceWebsite.Data.EF;
using EcommerceWebsite.Data.Identity;
using EcommerceWebsite.Services.Interfaces.ExtraServices;
using EcommerceWebsite.Services.Interfaces.Main;
using EcommerceWebsite.Services.Interfaces.System;
using EcommerceWebsite.Services.Services.ExtraServices;
using EcommerceWebsite.Services.Services.Main;
using EcommerceWebsite.Services.Services.System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
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
            services.AddControllers();

            // Database Connection
            services.AddControllersWithViews();
            var str = Configuration.GetConnectionString("EcommerceWebsiteDatabase");
            services.AddDbContext<EcomWebDbContext>(options =>
                options.UseSqlServer(str));

            // Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<EcomWebDbContext>()
               .AddClaimsPrincipalFactory<MyUserClaimsPrincipalFactoryService>()
               .AddDefaultTokenProviders();

            //DI
            DependencyInjectionSystemConfig(services);

            // Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Swagger EcommerceShop", Version = "v1" });
                s.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Sử dụng JWT Authorization header dựa trên Bearer scheme. Công dụng để Authorization cho các API viết trong hệ thống\r\n\r\n
                      Nhập 'Bearer' [khoảng trắng] và token nhận được sau khi chạy Login của User.
                      \r\n\r\nVí dụ: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });

            });

            //Email
            var emailConfig = Configuration
                .GetSection("EmailSenderConfig")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            //Mapper
            services.AddAutoMapper(typeof(AutoMapping));

        }

        private void DependencyInjectionSystemConfig(IServiceCollection services)
        {
            services.AddScoped<ISanPhamServices, SanPhamServices>();
            services.AddScoped<IKhachHangServices, KhachHangServices>();
            services.AddScoped<IEmailSenderServices, EmailSenderServices>();
            services.AddScoped<IHUIServices, HUIServices>();
            services.AddScoped<IDanhMucServices, DanhMucServices>();
            services.AddScoped<IBangGiaServices, BangGiaServices>();
            services.AddScoped<IKhuyenMaiServices, KhuyenMaiServices>();
            services.AddScoped<INhanHieuServices, NhanHieuServices>();
            services.AddScoped<IDinhLuongServices, DinhLuongServices>();
            services.AddScoped<IBinhLuanServices, BinhLuanServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger eShopSolution V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
