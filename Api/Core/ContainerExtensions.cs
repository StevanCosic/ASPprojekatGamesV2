using Application;
using Application.Interfaces;
using DataAccess;
using Implementation.Commands;
using Implementation.Commands.MovieCommands;

using Implementation.Queries;
using Implementation.Validators;
using Implementation.Validators.Game;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUsesCases(this IServiceCollection services)
        {
            services.AddTransient<UseCaseExecutor>();

            //create commands
            services.AddTransient<InsertDevCmd>();
            services.AddTransient<CreateGenreCommand>();
            services.AddTransient<InsertGameCmd>();
            services.AddTransient<CreateUserCommand>();
            services.AddTransient<ReviewTitleCmd>();
            services.AddTransient<RateGameCmd>();
            services.AddTransient<FavoriteGameCmd>();

            //update commands
            services.AddTransient<UpdateGameCmd>();
            services.AddTransient<UpdateDevCmd>();
            services.AddTransient<UpdateGenreCmd>();
            services.AddTransient<UpdateUserCmd>();
            

            //delete commands
            services.AddTransient<DeleteGameCmd>();
            services.AddTransient<DelDevCmd>();
            services.AddTransient<DeleteGenreCmd>();
            services.AddTransient<DeleteUserCmd>();
            services.AddTransient<DeleteFavoriteGameCmd>();

            //create validators
            services.AddTransient<InsertDevsValidator>();
            services.AddTransient<CreateGenreValidator>();
            services.AddTransient<InsertTitileValidator>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<ReviewValidator>();
            services.AddTransient<RatingValidator>();
            services.AddTransient<FavValidator>();

            //update validators
            services.AddTransient<UpdateGameValidator>();
            services.AddTransient<UpdateDevsValidator>();
            services.AddTransient<UpdateGenreValidator>();
            services.AddTransient<UpdateUserValidator>();
            

            //queries
            services.AddTransient<GetGamesQuery>();
            services.AddTransient<GetDevsQuery>();
            services.AddTransient<GetGenreQuery>();
            services.AddTransient<GetUserQuery>();
            services.AddTransient<GetLoggetQuery>();
            services.AddTransient<GetFavoriteQuery>();
        }

        public static void AddApplicationUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;

                if (user.FindFirst("UserData") == null)
                {
                    return new UnregisteredUser();
                }

                var userString = user.FindFirst("UserData").Value;

                var userJwt = JsonConvert.DeserializeObject<JwtUser>(userString);

                return userJwt;
            });
        }

        public static void AddJwt(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<Context>();

                return new JwtManager(context, appSettings.JwtIssuer, appSettings.JwtSecretKey);
            });
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = appSettings.JwtIssuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

    }
}
