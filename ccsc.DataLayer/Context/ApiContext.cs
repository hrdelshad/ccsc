using Microsoft.EntityFrameworkCore;

namespace ccsc.DataLayer.Context
{
	public class ApiContext : DbContext
	{
		public ApiContext()
		{

		}

		public ApiContext(DbContextOptions<CcscContext> options):base(options)
		{
			
		}


		
	}
}
