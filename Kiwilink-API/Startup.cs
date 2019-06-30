using Kiwilink.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Entities;
using Newtonsoft.Json.Serialization;

namespace Kiwilink
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMongoDBEntities("kiwilink");
            services.AddCors();
            services.AddMvc()
                .AddJsonOptions(opt => opt.SerializerSettings.ContractResolver = new DefaultContractResolver())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = false); //set to true to disable automatic model error response 400
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            DB.Migrate();

            DefineIndexes();
        }

        private void DefineIndexes()
        {
            DB.Index<Client>()
              .Key(c => c.Name, KeyType.Text)
              .Key(c => c.Surname, KeyType.Text)
              .Create();
        }
    }
}
