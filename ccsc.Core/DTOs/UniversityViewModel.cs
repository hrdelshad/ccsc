using System;
using System.ComponentModel.DataAnnotations;

namespace ccsc.Core.DTOs
{
	public class UniversityViewModel
	{
		[Required]
		public int UniversityId { get; set; }
		[Required]
		public string Title { get; set; }
		public string Url { get; set; }
		public string Version { get; set; }
		public DateTime? VersionCheckDate { get; set; }
		public string SMSUser { get; set; }
		public string SMSPass { get; set; }
		public decimal SMSCredit { get; set; }
		public decimal MinSMSCredit { get; set; }
		public DateTime? SMSCreditCheckDate { get; set; }
		public bool IsActiveSms { get; set; }
		public int AfterXDay { get; set; }
		public DateTime? SendSmsDate { get; set; }
	}
}
