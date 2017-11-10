using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PicBook.Web.ServerSide;
using PicBook.Web.ServerSide.Entities;

namespace PicBook.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            SerilogConfiguration.ConfigureSerilog();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            
          services.AddIdentity<Account, ApplicationRole>(opts =>
          {
            opts.Password.RequiredLength = 6;
          });
          services.AddDbContext<PicBookDbContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("PicBookDatabase")));
          services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
