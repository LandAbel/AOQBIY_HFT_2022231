using AOQBIY_HFT_2022231.Endpoint.Services;
using AOQBIY_HFT_2022231.Logic.Classes;
using AOQBIY_HFT_2022231.Logic.Interfaces;
using AOQBIY_HFT_2022231.Models;
using AOQBIY_HFT_2022231.Repository.Data;
using AOQBIY_HFT_2022231.Repository.Interfaces;
using AOQBIY_HFT_2022231.Repository.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AOQBIY_HFT_2022231.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ProcessorListDbContext>();

            services.AddTransient<IRepository<Processor>, ProcessorRepository>();
            services.AddTransient<IRepository<Chipset>, ChipsetRepository>();
            services.AddTransient<IRepository<Brand>, BrandRepository>();

            services.AddTransient<IProcessorLogic, ProcessorLogic>();
            services.AddTransient<IChipsetLogic, ChipsetLogic>();
            services.AddTransient<IBrandLogic, BrandLogic>();


            services.AddSignalR();

            services.AddControllers();

            services.AddSwaggerGen(t =>
            {
                t.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "AOQBIY_HFT_2022231.Endpoint",
                    Version = "v1",
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(t => t.SwaggerEndpoint("/swagger/v1/swagger.json", "AOQBIY_HFT_2022231.Endpoint v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
