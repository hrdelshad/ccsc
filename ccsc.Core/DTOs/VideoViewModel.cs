using System.Linq;
using ccsc.DataLayer.Entities.Products;

namespace ccsc.Core.DTOs
{
	public class VideoViewModel
	{
		public int VideoId { get; set; }

		public string Title { get; set; }

		public string Path { get; set; }

		public string Description { get; set; }

		#region Relations

		public virtual IQueryable<Product> Products { get; set; }

		#endregion
	}
}
