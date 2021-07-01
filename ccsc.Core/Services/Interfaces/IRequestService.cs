using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ccsc.Core.DTOs;

namespace ccsc.Core.Services.Interfaces
{
	public interface IRequestService
	{
		Task<FilterRequestDTO> FilterRequests(FilterRequestDTO filter);
	}
}
