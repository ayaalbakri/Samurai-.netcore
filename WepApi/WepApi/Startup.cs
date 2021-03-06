﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Linq;
using System.Text;
using WepApi.Domain_Models;
using WepApi.Services;

namespace WepApi
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
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
        });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AllowGet", policy =>
            //        policy.Requirements.Add(new AllowGet()));
            //});
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AllowGet", policy =>
                    policy.RequireAssertion(context =>
                    {
                        var yourvalue = context.User.Claims.FirstOrDefault(c => c.Type == "Email").Value;
                        policy.Requirements.Add(new AllowGet(yourvalue));
                        return yourvalue != null;

                    }
                       ));
            });
            services.AddScoped<IAuthorizationHandler, AllowGetHandler>();
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.RegisterServices();


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
