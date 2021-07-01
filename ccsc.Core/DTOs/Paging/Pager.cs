
using System;

namespace ccsc.Core.DTOs.Paging
{
	public class Pager
	{
		public static BasePaging Build(int pageId, int allEntitiesCount, int take, int beforeAndAfterPageCount)
		{
			var pageCount = (int)Math.Ceiling(allEntitiesCount / (double)take);
			return new BasePaging
			{
				PageId = pageId,
				AllEntitiesCount = allEntitiesCount,
				Take = take,
				Skip = (pageId - 1) * take,
				Start = pageId - beforeAndAfterPageCount <= 0 ? 1 : pageId - beforeAndAfterPageCount,
				End = pageId + beforeAndAfterPageCount >= pageCount ? pageCount : pageId + beforeAndAfterPageCount,
				PageCount = pageCount,
				BeforeAndAfterPageCount = beforeAndAfterPageCount
			};
		}
	}
}
