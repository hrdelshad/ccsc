
namespace ccsc.Core.DTOs.Paging
{
	public class BasePaging
	{
		public BasePaging()
		{
			PageId = 1;
			Take = 10;
			BeforeAndAfterPageCount = 3;
		}

		public int PageId { get; set; }
		public int PageCount { get; set; }
		public int AllEntitiesCount { get; set; }
		public int Start { get; set; }
		public int End { get; set; }
		public int Take { get; set; }
		public int Skip { get; set; }
		public int BeforeAndAfterPageCount { get; set; }

	}
}
