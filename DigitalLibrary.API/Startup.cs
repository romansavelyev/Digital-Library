using System.Text;
using DigitalLibrary.API.Services;
using DigitalLibrary.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DigitalLibrary
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
	        RegisterTypes(services);
			services.AddMvc();

	        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DigitalLibraryConnection")));

	        services.AddIdentity<ApplicationUser, IdentityRole>()
		        .AddEntityFrameworkStores<ApplicationDbContext>()
		        .AddDefaultTokenProviders();

	        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddAuthentication(options =>
	        {
		        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
	        }).AddJwtBearer(options =>
	        {
		        options.SaveToken = true;
		        options.RequireHttpsMetadata = false;
		        options.TokenValidationParameters = new TokenValidationParameters()
		        {
			        //ValidateAudience = true,
			        //ValidateIssuer = true,
			        //ValidIssuer = "http://oec.com",
			        //ValidAudience = "http://oec.com",
			        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DigitalLibraryKey"))
		        };
	        });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

	        SeedDatabase.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
		        .CreateScope().ServiceProvider);

	        app.UseAuthentication();

	        app.UseMvc();
        }

	    private static void RegisterTypes(IServiceCollection services)
	    {	
		    services.AddTransient<LoginService>();
		    services.AddTransient<ApplicationUserRepository>();
		    services.AddTransient<AuthorRepository>();
		    services.AddTransient<BookRepository>();
		    services.AddTransient<AuthorBookRepository>();
	    }
	}
}
