using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//Microsoft.Extensions.DependencyInjection
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Api.Data;
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
      services
         //.AddEntityFrameworkNpgsql()
         .AddDbContext<ApplicationDbContext>(options =>
         options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
      services.AddControllers();
      services.AddAuthentication("Bearer")
         .AddJwtBearer("Bearer", options =>
         {
           options.Authority = Configuration.GetValue<string>("Authority");
           options.RequireHttpsMetadata = false;

           options.Audience = "api1";
         });

        // Register the Swagger generator, defining 1 or more Swagger documents
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Portal-Api", Version = "v1" });
        });

            services.AddCors(options =>
      {
              // this defines a CORS policy called "default"
              options.AddPolicy("default", policy =>
              {
            policy.WithOrigins(Configuration.GetValue<string>("Origins"))
                      .AllowAnyHeader()
                      .AllowAnyMethod();
          });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
      // specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portal-Api V1");
      });

      //app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors("default");

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
