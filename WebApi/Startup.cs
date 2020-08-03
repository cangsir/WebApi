using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DAL;
using Microsoft.Extensions.Options;

namespace WebApi
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

            //���ÿ�����1
            services.AddCors(options =>
            {
                // Policy ���Q CorsPolicy ����ӆ�ģ������Լ���
                options.AddPolicy("getd", policy =>
                {
                    // �O�����S����ā�Դ���ж�����Ԓ������ `,` ���_
                    ////////////////////192.168.1.118
                    policy.WithOrigins("http://192.168.1.118:6688", "http://192.168.1.118:8866")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                });
            });

            ////���ÿ�����2
            //services.AddCors(options => options.AddPolicy("Domain",
            //builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
            //services.AddControllers();

            //���ÿ�����3
            //services.AddCors(options => options.AddPolicy("AllowSameDomain", p => p.AllowAnyOrigin()));
            //services.AddCors(options => options.AddPolicy("AllowSameDomain", builder =>
            //{
            //    builder.AllowAnyMethod()
            //    .AllowAnyHeader()
            //        .AllowAnyOrigin()
            //        .AllowCredentials();
            //}));

            services.AddSingleton<InterfaceMeeTingDal, MeeTingDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //���ÿ�����1
            app.UseCors("getd");

            ////���ÿ�����2
            //app.UseCors("cor");

            ////���ÿ�����3
            //app.UseCors("AllowSameDomain");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
