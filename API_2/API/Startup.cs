using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Aplicacao;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API
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
            services.AddCors();
            Cross.IOC.IOCManager.Register(services);
            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddSwaggerGen(_ =>
            {
                _.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Desafio Softplan",
                        Description = "",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Rodrigo Hasse",
                            Email = "rodrigohasse1@gmail.com"
                        }
                    });

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //_.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(_ => { _.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Softplan"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.Run(async context => {
                context.Response.Redirect("swagger/index.html");
            });
        }
    }
}