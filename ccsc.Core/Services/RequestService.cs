using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ccsc.Core.Services.Interfaces;
using ccsc.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using ccsc.Core.DTOs;
using ccsc.Core.DTOs.Paging;
using ccsc.Core.Extensions;

namespace ccsc.Core.Services
{
	public class RequestService : IRequestService
	{
		private readonly CcscContext _context;

		public RequestService(CcscContext context)
		{
			_context = context;
		}

		public async Task<FilterRequestDTO> FilterRequests(FilterRequestDTO filter)
		{
			var query = _context.Requests
				.Include(r => r.Contact).ThenInclude(c => c.Salutation)
				.Include(r => r.Customer)
				.Include(r => r.RequestChanel)
				.Include(r => r.RequestStatus)
				.Include(r => r.RequestType)
				.Include(r => r.SubSystem).AsQueryable();

			#region state

			switch (filter.RequestState)
			{
				case true:
					query = query.Where(s => s.RequestStatus.IsActive);
					break;
				case false:
					query = query.Where(s => !s.RequestStatus.IsActive);
					break;
			}

			switch (filter.OrderBy)
			{
				case FilterRequestDTO.FilterRequestOrder.CreatedOnAsc:
					query = query.OrderBy(s => s.RequestTime);
					break;
				case FilterRequestDTO.FilterRequestOrder.CreatedOnDesc:
					query = query.OrderByDescending(s => s.RequestTime);
					break;
			}
			#endregion

			#region filter

			if (filter.CustomerId.HasValue)
			{
				query = query.Where(s => s.CustomerId == filter.CustomerId);
			}

			if (filter.RequestTypeId.HasValue)
			{
				query = query.Where(s => s.RequestChanelId == filter.RequestChanelId);
			}

			if (!string.IsNullOrEmpty(filter.Title))
			{
				query = query.Where(s =>EF.Functions.Like(s.Title,$"%{filter.Title}%"));
			}
			#endregion

			#region Paging

			
			var pager = Pager.Build(filter.PageId, await query.CountAsync(), filter.Take, filter.BeforeAndAfterPageCount);
			var allRequest = await query.Paging(pager).ToListAsync();
			#endregion

			return filter.SetPaging(pager).SetRequest(allRequest);
		}

	}
}
