using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using alimentesebem.sesi.domain.Contracts;
using alimentesebem.sesi.repository.Context;
using alimentesebem.sesi.repository.Repositories;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;

namespace senai.ifood.webapi
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "V1",
                    Title = "AlimenteSeBem API",
                    Description = "Documentação de uso do projeto Alimente-se Bem API",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Renata Felix | Vinicius Viana", Email = "naty.bmth1@gmail.com", Url = "http://www.sesisp.org.br/qualidade-de-vida/" }
                });

                var basePath = AppContext.BaseDirectory;
                var xmlPath = System.IO.Path.Combine(basePath, "AlimenteSeBemAPI.xml");

                c.IncludeXmlComments(xmlPath);
            });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                }));


            services.AddDbContext<ISesiContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionServer")));

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
        }
    }
}
