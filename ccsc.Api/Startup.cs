using ccsc.DataLayer.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using System;

namespace ccsc.Api
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
			services
				.AddControllers()
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
			services.AddResponseCaching();
			#region Database Contexts

			services.AddDbContext<CcscContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
			);

			#endregion

			#region DI


			#endregion
			// برای جلوگیری از لوپهای انکلود
			// install the NuGET package: Microsoft.AspNetCore.Mvc.NewtonsoftJson
			services.AddControllers().AddNewtonsoftJson(options =>
			{
				options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			});

			#region JWT
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters()
					{
						
						ValidateIssuer = true,
						ValidateAudience = false,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = "http://localhost/api", 
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DelVerifyApiEnicoKey"))
					};
					
				}
				)
				.AddCookie(options =>
				{
					options.Cookie.Name = "Enico-Cookie";
				})
				;

			services.AddCors(options =>
			{
				options.AddPolicy("EnicoCorsPolicy", builder =>
				{
					builder
					.AllowAnyOrigin()
					.AllowAnyHeader()
					.AllowAnyMethod()
					//.AllowCredentials()
					.Build();
				});
			});

		
			#endregion



		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseResponseCaching();

			app.UseCors("EnicoCorsPolicy");

		}
	}
}
