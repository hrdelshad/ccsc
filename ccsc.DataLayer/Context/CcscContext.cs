using ccsc.DataLayer.Entities.ChangeSets;
using ccsc.DataLayer.Entities.Contacts;
using ccsc.DataLayer.Entities.Contracts;
using ccsc.DataLayer.Entities.Courses;
using ccsc.DataLayer.Entities.Customers;
using ccsc.DataLayer.Entities.Identity;
using ccsc.DataLayer.Entities.Requests;
using ccsc.DataLayer.Entities.Services;
using ccsc.DataLayer.Entities.Tutorials;
using ccsc.DataLayer.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using ccsc.DataLayer.Entities.Common;
using Faq = ccsc.DataLayer.Entities.Tutorials.Faq;

namespace ccsc.DataLayer.Context
{
	public class CcscContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
	{
		public CcscContext(DbContextOptions<CcscContext> options)
			:base(options)
		{
			
		}

		#region ModelBulder

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			#region Identity

			builder.Entity<Role>(modelBuilder =>
			{
				modelBuilder.ToTable("Roles");
			});

			builder.Entity<RoleClaim>(modelBuilder =>
			{
				modelBuilder.ToTable("RoleClaims");

				modelBuilder
					.HasOne(roleClaim => roleClaim.Role)
					.WithMany(role => role.Claims)
					.HasForeignKey(roleClaim => roleClaim.RoleId);
			});

			builder.Entity<User>(modelBuilder =>
			{
				modelBuilder.ToTable("Users");
			});

			builder.Entity<UserClaim>(modelBuilder =>
			{
				modelBuilder.ToTable("UserClaims");

				modelBuilder
					.HasOne(userClaim => userClaim.User)
					.WithMany(user => user.Claims)
					.HasForeignKey(userClaim => userClaim.UserId);
			});

			builder.Entity<UserLogin>(modelBuilder =>
			{
				modelBuilder.ToTable("UserLogins");

				modelBuilder
					.HasOne(userLogin => userLogin.User)
					.WithMany(user => user.Logins)
					.HasForeignKey(userLogin => userLogin.UserId);
			});

			builder.Entity<UserRole>(modelBuilder =>
			{
				modelBuilder.ToTable("UserRoles");

				modelBuilder
					.HasOne(userRole => userRole.User)
					.WithMany(user => user.Roles)
					.HasForeignKey(userRole => userRole.UserId);

				modelBuilder
					.HasOne(userRole => userRole.Role)
					.WithMany(role => role.Users)
					.HasForeignKey(userRole => userRole.RoleId);
			});

			builder.Entity<UserToken>(modelBuilder =>
			{
				modelBuilder.ToTable("UserTokens");

				modelBuilder
					.HasOne(userToken => userToken.User)
					.WithMany(user => user.Tokens)
					.HasForeignKey(userToken => userToken.UserId);
			});

			#endregion

			#region Services

			builder.Entity<ServiceType>()
				.HasIndex(e => e.Title)
				.IsUnique();

			#endregion

			#region Seeding

			//builder.Entity<Config>().HasData(new Config { Key = "MinVersion", Value = "7455", Description = "نسخه‌های کمتر از این باید آپدیت شوند." });

			#endregion

		}

		#endregion

		#region ChangeSets

		public DbSet<ChangeSet> ChangeSets { get; set; }
		public DbSet<ChangeType> ChangeTypes { get; set; }
		public DbSet<SubSystem> SubSystems { get; set; }

		#endregion

		#region Common

		public DbSet<Comment> Comments { get; set; }
		public DbSet<Config> Configs { get; set; }

		#endregion

		#region Contacts

		public DbSet<Post> Posts { get; set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Salutation> Salutations { get; set; }


		#endregion

		#region Contracts

		public DbSet<Contract> Contracts { get; set; }
		//public DbSet<ContractCours> ContractCourses { get; set; }
		public DbSet<ContractStatus> ContractStatuses { get; set; }
		public DbSet<ContractType> ContractTypes { get; set; }

		#endregion

		#region Courses

		//public DbSet<Course> Courses { get; set; }
		public DbSet<CourseLevel> CourseLevels { get; set; }

		#endregion

		#region Customers

		public DbSet<CustomerType> CustomerTypes { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<CustomerStatus> CustomerStatuses { get; set; }
		public DbSet<ServerType> ServerTypes { get; set; }
		public DbSet<Server> Servers { get; set; }
		public DbSet<Os> Oses { get; set; }

		public DbSet<SqlVersion> SqlVersions { get; set; }

		#endregion

		#region Requests

		public DbSet<Request> Requests { get; set; }
		public DbSet<RequestChannel> RequestChannels { get; set; }
		public DbSet<RequestStatus> RequestStatuses { get; set; }
		public DbSet<RequestType> RequestTypes { get; set; }

		#endregion

		#region Services

		public DbSet<Duty> Duties { get; set; }
		public DbSet<DutyStatus> DutyStatuses { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<ServiceStatus> ServiceStatuses { get; set; }
		public DbSet<ServiceType> ServiceTypes { get; set; }


		#endregion

		#region Tutorials

		public DbSet<Faq> Faqs { get; set; }
		public DbSet<UserType> UserTypes { get; set; }
		public DbSet<Video> Videos { get; set; }

		#endregion

		#region User

		public DbSet<AppUser> AppUsers { get; set; }

		public Task<Customer> SingleOrDefaultAsync(Func<object, bool> p)
		{
			throw new NotImplementedException();
		}

		#endregion


	}
}
