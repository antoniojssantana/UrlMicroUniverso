using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using sga.utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using url.api.Configurations;
using url.api.Extensions;
using url.api.HostedServices;
using url.data.Context;

namespace url.api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("Livre");
            }
            else
            {
                app.UseCors("Prod");
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "vila.api v1"));

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseHsts();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<EmailSettings>(Configuration.GetSection("EmailConfiguration"));

            services.Configure<FolderSettings>(Configuration.GetSection("FolderSettings"));
            services.AddDbContext<URLDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Postgresql"),
                             p => p.EnableRetryOnFailure(
                             maxRetryCount: 6,
                             maxRetryDelay: TimeSpan.FromSeconds(5),
                             errorCodesToAdd: null)));

            services.AddIdentityConfiguration(Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("Livre", builder => builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin());

                options.AddPolicy("Prod", builder => builder
                                        .AllowAnyMethod()
                                        .AllowAnyHeader()
                                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                                        .WithOrigins("https://vilaop.sgatec.com.br"));
                //.AllowCredentials()
                //.WithOrigins("https://vilaop.sgatec.com.br"));
            });

            services.Configure<IISOptions>(o =>
            {
                o.ForwardClientCertificate = false;
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "vila.api", Version = "v1" });
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddAutoMapper(typeof(Startup));

            services.ResolveDependecies();

            if (Configuration.GetValue<bool>("RunMigration"))
            {
                services.AddHostedService<MigrationHostedService>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

    }
}
