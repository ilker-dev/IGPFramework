﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using IgpFramework.Api.Model;
using IgpFramework.Api.Repositories;
using AutoMapper;
using IgpFramework.Api.Security.Token;
using IgpFramework.Api.Security.Services;
using IgpFramework.Api.Common;
using Microsoft.Extensions.DependencyInjection;
using IgpFramework.Data;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace IgpFramework.Api
{
    public class BaseStartUp
    {

        public IConfiguration Configuration { get; }

        public BaseStartUp(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            //appsettings içindei bir sectionu getirecek ve bızım tipimize cevirecek
            var tokenManagement = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            services.AddMvc();
            services.AddDbContext<IGPCoreContext>(optionsAction: options => options.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICrypto, Crypto>();
            services.AddScoped<IResourceManagerIGP, ResourceManagerIGP>();

            //dependecy injection sayesinde automapperi proje içinde kullanmamızı sağlayacak
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors(cors => cors.AddDefaultPolicy(defaultCors => { defaultCors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SignHandler.GetSecurityKey(tokenManagement.Secret),
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidAudience = "mysite.com",
                    ValidIssuer = "mysite.com",

                };
            });

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseAuthentication();
        }
    }
}