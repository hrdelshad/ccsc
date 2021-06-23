using System.Collections.Generic;
using System.Threading.Tasks;
using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using ccsc.DataLayer.Entities.Courses;
using Microsoft.EntityFrameworkCore;

namespace ccsc.Core.Services
{
	public class CourseService : ICourseService
	{
		private readonly CcscContext _context;

		public CourseService(CcscContext context)
		{
			_context = context;
		}

		public async Task<List<Course>> GetCourses()
		{
			return await _context.Courses.ToListAsync();
		}
	}
}