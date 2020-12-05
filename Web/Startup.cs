﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using ccsc.Core.Services;
using ccsc.Core.Services.Identity;
using ccsc.Core.Services.Identity.Stores;
using ccsc.Core.Services.Identity.Validators;
using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Identity;
using ccsc.DataLayer.Entities.Messages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace ccsc.Web
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
            // Add framework services.
            services
                .AddControllersWithViews()
				// نمایش تغییرات در ویو بدون نیاز به کامپایل
				//install the NuGET package: Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
				.AddRazorRuntimeCompilation()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                // Maintain property names during serialization. See:
                // https://github.com/aspnet/Announcements/issues/194
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            // Add Kendo UI services to the services container
            services.AddKendo();

			//services.AddControllersWithViews();

			// برای جلوگیری از لوپهای انکلود
			// install the NuGET package: Microsoft.AspNetCore.Mvc.NewtonsoftJson
			services.AddControllers().AddNewtonsoftJson(options =>
			{
				options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			});

			#region Database Contexts

			services.AddDbContext<CcscContext>(options=>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
				);

			#endregion

			#region Identity

			services.AddIdentity<User, Role>(options =>
				{
					options.User.RequireUniqueEmail = true;
					options.Password.RequireNonAlphanumeric = false;

					options.SignIn.RequireConfirmedEmail = true;
					options.SignIn.RequireConfirmedPhoneNumber = true;


				})
				//.AddEntityFrameworkStores<>()
				.AddUserStore<MyUserStore>()
				.AddRoleStore<MyRoleStore>()
				.AddUserValidator<MyUserValidator>()
				.AddRoleValidator<MyRoleValidatore>()
				//.AddUserManager<MyUserManager>()
				//.AddRoleManager<MyRoleManager>()
				//.AddSignInManager<MySignInManager>()
				.AddErrorDescriber<MyErrorDescriber>()
				.AddClaimsPrincipalFactory<MyUserClaimsPrincipalFactory>()
				.AddDefaultTokenProviders();

			#endregion

			#region DI

			services.AddTransient<IMyMailService, MyMailService>();
			services.AddTransient<ICustomerService, CustomerService>();
			services.AddTransient<ITfsService, TfsService>();
			services.AddTransient<IChangeSetService, ChangeSetService>();
			services.AddTransient<IVideoService, VideoService>();


			#endregion

			services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			//if (env.IsDevelopment())
			//{
			//	app.UseDeveloperExceptionPage();
			//}
			//else
			//{
			//	app.UseExceptionHandler("/Home/Error");
			//	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			//	app.UseHsts();
			//}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});

		}
	}
}
