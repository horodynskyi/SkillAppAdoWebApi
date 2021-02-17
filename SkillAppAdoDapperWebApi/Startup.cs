using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;


using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;


using Microsoft.AspNetCore.Identity;
using SkillManagement.DataAccess.Repositories;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using SkillManagement.DataAccess.UnitOfWork;
using SkillManagement.DataAccess.Services;
using SkillManagement.DataAccess;

namespace SkillAppAdoDapperWebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddControllers();
            #region SQL repositories
            services.AddTransient<ISQLProductRepository, SQLProductRepository>();
            services.AddTransient<ISQLCategoriesRepository, SQLCategoriesRepository>();
            services.AddTransient<ISQLValuesRepository, SQLValuesRepository>();
            services.AddTransient<ISQLAttributeRepository, SQLAttributeRepository>();

            #endregion

            #region SQL services
            services.AddTransient<ISQLProductService, SQLProductService>();
            services.AddTransient<ISQLCategoriesService, SQLCategoriesService>();
            services.AddTransient<ISQLValuesService, SQLValuesService>();
            services.AddTransient<ISQLAttributeService, SQLAttributeService>();

            #endregion

            services.AddTransient<ISQLUnitOfWork, SQLUnitOfWork>();

            services.AddTransient<IConnectionFactory, ConnectionFactory>();

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    },
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();    // подключение аутентификации
           
            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "weatherforecast";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
