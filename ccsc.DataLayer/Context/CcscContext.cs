using ccsc.DataLayer.Entities.Contacts;
using ccsc.DataLayer.Entities.Contracts;
using ccsc.DataLayer.Entities.Courses;
using ccsc.DataLayer.Entities.Customers;
using ccsc.DataLayer.Entities.Products;
using ccsc.DataLayer.Entities.Requests;
using ccsc.DataLayer.Entities.Tutorials;
using ccsc.DataLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Contract = ccsc.DataLayer.Entities.Contracts.Contract;

namespace ccsc.DataLayer.Context
{
	public class CcscContext:DbContext
	{
		public CcscContext()
		{

		}

		public CcscContext(DbContextOptions<CcscContext> options):base(options)
		{
			
		}

		#region ModelBulder


		#endregion

		#region Contacts

		public DbSet<Post> Posts { get; set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Salutation> Salutations { get; set; }


		#endregion

		#region Contracts

		public DbSet<Contract> Contracts { get; set; }
		public DbSet<ContractCours> ContractCourses { get; set; }
		public DbSet<ContractProduct> ContractProducts { get; set; }
		public DbSet<ContractType> ContractTypes { get; set; }

		#endregion

		#region Courses

		public DbSet<Course> Courses { get; set; }
		public DbSet<CourseLevel> CourseLevels { get; set; }

		#endregion

		#region Customers

		public DbSet<CustomerType> CustomerTypes { get; set; }
		public DbSet<Customer> Customers { get; set; }

		public DbSet<ServerType> ServerTypes { get; set; }
		public DbSet<Server> Servers { get; set; }
		public DbSet<Os> Oses { get; set; }

		#endregion

		#region Products

		public DbSet<Product> Products { get; set; }

		#endregion

		#region Requests

		public DbSet<Request> Requests { get; set; }
		public DbSet<RequestChanel> RequestChanels { get; set; }
		public DbSet<RequestStatus> RequestStatuses { get; set; }
		public DbSet<RequestType> RequestTypes { get; set; }

		#endregion

		#region Tutorials

		public DbSet<PublishedVideo> PublishedVideos { get; set; }
		public DbSet<Video> Videos { get; set; }

		#endregion

		#region User

		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }

		#endregion

		
	}
}
