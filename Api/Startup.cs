using Api.Core;
using Application;
using Application.Interfaces;
using AutoMapper;
using Application.Interfaces.Queries;
using DataAccess;
using Implementation.Commands;
using Implementation.Queries;
using Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Implementation.Logging;
using Implementation.Email;
using Application.Interfaces.Email;
using Microsoft.OpenApi.Models;
using Application.Interfaces.Email;

namespace Api
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
            var appSettings = new AppSettings();

            Configuration.Bind(appSettings);

            services.AddControllers();
            services.AddDbContext<Context>();
            services.AddUsesCases();
            services.AddJwt(appSettings);
            services.AddHttpContextAccessor();
            services.AddApplicationUser();
            services.AddTransient<IUseCaseLogger, UseCaseLoggerDatabase>();
            services.AddTransient<IEmailSender, SMTPEmailSender>();
            /*services.AddAutoMapper(this.GetType().Assembly);*/
            services.AddAutoMapper(typeof(GetGamesQuery).Assembly);

      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });

           

        

            app.UseRouting();
            app.UseStaticFiles();
            app.UseMiddleware<ExceptionHandler>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
