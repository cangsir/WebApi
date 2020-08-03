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

            //配置跨域处理1
            services.AddCors(options =>
            {
                // Policy 名稱 CorsPolicy 是自訂的，可以自己改
                options.AddPolicy("getd", policy =>
                {
                    // 設定允許跨域的來源，有多個的話可以用 `,` 隔開
                    ////////////////////192.168.1.118
                    policy.WithOrigins("http://192.168.1.118:6688", "http://192.168.1.118:8866")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                });
            });

            ////配置跨域处理2
            //services.AddCors(options => options.AddPolicy("Domain",
            //builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
            //services.AddControllers();

            //配置跨域处理3
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
            //配置跨域处理1
            app.UseCors("getd");

            ////配置跨域处理2
            //app.UseCors("cor");

            ////配置跨域处理3
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
