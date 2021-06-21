using System;

namespace ccsc.DataLayer.Entities.Courses
{
	public class Group
	{
		public Guid GroupId { get; set; }
		public string Title { get; set; }

		public bool IsMedical { get; set; }

		public bool IsActive { get; set; }

		#region Relations

		public Faculty Faculty { get; set; }

		public Guid FacultyId { get; set; }

		#endregion
	}
}