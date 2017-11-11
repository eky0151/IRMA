using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PicBook.Web.ServerSide;
using PicBook.Web.ServerSide.Entities;
using PicBook.Web.ServerSide.Repository.IRepositores;
using PicBook.Web.ServerSide.Repository.Repositories;
using Swashbuckle.AspNetCore.Swagger;

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
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "PicBook"});});
            services.AddIdentity<Account, ApplicationRole>(opts => { opts.Password.RequiredLength = 6; });
            services.AddDbContext<PicBookDbContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("PicBookDatabase")));
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          app.UseSwagger();
          app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "PicBook"); });
          app.UseMvc();
        }
    }
}
