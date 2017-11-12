using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PicBook.Web.ServerSide.Entities;
using PicBook.Web.ServerSide.Misc;
using PicBook.Web.ServerSide.Repository.IRepositores;
using PicBook.Web.ServerSide.Repository.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace PicBook.Web
{
    public class Startup
    {

    private const string SecretKey = "iieBK?SHhi2973978289hdHBÉLP"; 
    private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

    public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            SerilogConfiguration.ConfigureSerilog();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
      //    services.AddSingleton<IJwtFactory, JwtFactory>();
      //    var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

      //   services.Configure<JwtIssuerOptions>(options =>
      //   {
      //        options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
      //        options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
      //        options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
      //   });


      //  services.AddAuthentication(options =>
      //{
      //  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      //  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      //});

          //services.AddAuthentication(options =>
          //{
          //  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          //  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
          //}).AddJwtBearer(o =>
          //{
          //  // You also need to update /wwwroot/app/scripts/app.js
          //  o.Authority = Configuration["jwt:authority"];
          //  o.Audience = Configuration["jwt:audience"];
          //});



            services.AddSwaggerGen(c =>
              {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "PicBook",
                    Description = "PicBook web API"
                });
              });
         
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

            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = Configuration["Authentication:Facebook:AppId"];
                options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
              if (env.IsDevelopment())
              {
                  app.UseDeveloperExceptionPage();
                  app.UseBrowserLink();
                  app.UseDatabaseErrorPage();
              }


              app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
              c.SwaggerEndpoint("/swagger/v1/swagger.json", "PicBook API");
            });

            

            app.UseMvc();

    }
  }
}
