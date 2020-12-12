
using API_Remember.Business;
using API_Remember.Business.Interface;
using API_Remember.Models;
using API_Remember.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace API_Remember
{
    public class Startup
    {
     

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("text/json"));
                options.Conventions.Add(new ActionHiddingConvention());
            }).AddXmlSerializerFormatters();

           // var signingConfiguration = new SigningConfigurations();

            services.AddSwaggerGen(c =>
            {
               c.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo
               { 
                Title = "API REMEMBER",
                Version = "v1"
               });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            //Injeção de dependencias
            services.Configure<RememberDatabaseSettings>(
                Configuration.GetSection(nameof(RememberDatabaseSettings)));
            services.AddSingleton<IRememberDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<RememberDatabaseSettings>>().Value);
            services.AddScoped<ICadastroBusiness, CadastroBusiness>();
            services.AddSingleton<CadastroBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else 
            {
                app.UseHsts();
            }
            
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "API REMEMBER");
                c.RoutePrefix = string.Empty;
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
