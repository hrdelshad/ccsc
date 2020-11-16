using System.Linq;
using ccsc.DataLayer.Entities.ChangeSets;

namespace ccsc.Core.DTOs
{
	public class VideoViewModel
	{
		public int VideoId { get; set; }

		public string Title { get; set; }

		public string Path { get; set; }

		public string Description { get; set; }

		#region Relations

		public virtual IQueryable<SubSystem> SubSystems { get; set; }

		#endregion
	}
}
