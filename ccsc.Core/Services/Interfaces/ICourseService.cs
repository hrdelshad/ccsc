using System.Collections.Generic;
using System.Threading.Tasks;
using ccsc.DataLayer.Entities.Courses;

namespace ccsc.Core.Services.Interfaces
{
	public interface ICourseService
	{
		Task<List<Course>> GetCourses();
	}
}