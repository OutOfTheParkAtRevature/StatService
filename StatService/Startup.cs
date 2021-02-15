using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatService
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<StatsContext>();
            services.AddScoped<Logic>();
            services.AddScoped<Repo>();
            services.AddControllers();
            services.AddDbContext<StatsContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("LocalDB")));

            //Add cors with any origin
            services.AddCors(options =>
            {
                options.AddPolicy("policy1",
                    builder =>
                    {
                        builder.WithOrigins(
                            "http://localhost:4200",
                            "https://localhost:4200",
                            "http://magic-match.azurewebsites.net",
                            "https://magic-match.azurewebsites.net"
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StatService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StatService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            //Inject cors
            app.UseCors("policy1");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
