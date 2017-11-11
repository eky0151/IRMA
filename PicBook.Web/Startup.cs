using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "PicBook", Description = "PicBook web API"});});
         
            services.AddDbContext<PicBookDbContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("PicBookDatabase")));

            services.AddIdentity<Account, ApplicationRole>()
            .AddEntityFrameworkStores<PicBookDbContext>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
              options.Password.RequireDigit = false;
              options.Password.RequiredLength = 4;
              options.Password.RequireNonAlphanumeric = false;
              options.Password.RequireUppercase = false;
              options.Password.RequireLowercase = false;
              options.Password.RequiredUniqueChars = 4;
              options.Password.RequireUppercase = false;

              options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
              options.Lockout.MaxFailedAccessAttempts = 5;
              options.Lockout.AllowedForNewUsers = true;

              options.User.RequireUniqueEmail = true;
            });

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
          app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "PicBook API"); });
          app.UseAuthentication();
          app.UseMvc();

    }
  }
}
