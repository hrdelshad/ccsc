using System;
using System.Collections.Generic;
using ccsc.Core.DTOs.Paging;
using ccsc.DataLayer.Entities.Requests;

namespace ccsc.Core.DTOs
{
	public class FilterRequestDTO : BasePaging
	{
		public int? CustomerId { get; set; }
		public int? RequestChanelId { get; set; }
		public int? RequestTypeId { get; set; }
		public int? SubSystemId { get; set; }
		public bool RequestState { get; set; }
		public string Title { get; set; }
		public FilterRequestOrder OrderBy { get; set; }
		public RequestStatus RequestStatus { get; set; }
		public List<Request> Requests { get; set; }


		public enum FilterRequestOrder
		{
			CreatedOnAsc,
			CreatedOnDesc
		}

		#region Methods

		public FilterRequestDTO SetRequest(List<Request> requests)
		{
			this.Requests = requests;
			return this;
		}

		public FilterRequestDTO SetPaging(BasePaging paging)
		{
			this.PageId = paging.PageId;
			this.AllEntitiesCount = paging.AllEntitiesCount;
			this.Start = paging.Start;
			this.End = paging.End;
			this.BeforeAndAfterPageCount = paging.BeforeAndAfterPageCount;
			this.Take = paging.Take;
			this.Skip = paging.Skip;
			this.PageCount = paging.PageCount;
			return this;
		}


		#endregion
	}
}