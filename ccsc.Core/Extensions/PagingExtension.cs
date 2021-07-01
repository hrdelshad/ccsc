using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ccsc.Core.DTOs.Paging;

namespace ccsc.Core.Extensions
{
	public static class PagingExtension
	{
		public static IQueryable<T> Paging<T>(this IQueryable<T> query, BasePaging paging)
		{
			return query.Skip(paging.Skip).Take(paging.Take);
		}
	}
}
