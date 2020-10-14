using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using static System.String;

namespace ccsc.Core.Convertors
{
	public static class DateConvertor
	{
		public static string PersianDate(this DateTime Value)
		{
			PersianCalendar pc = new PersianCalendar();

			return pc.GetYear(Value) + "/" +
				   pc.GetMonth(Value).ToString("00") + "/" +
			       pc.GetDayOfMonth(Value).ToString("00");
		}

		public static string PersianDateDayOfWeek(this DateTime Value)
		{
			PersianCalendar pc = new PersianCalendar();

			return string.Format("{0}, {1}/{2}/{3} {4}:{5}:{6}", 
				pc.GetDayOfWeek(Value).GetDayOfWeekPersian(),
				pc.GetMonth(Value),
				pc.GetDayOfMonth(Value),
				pc.GetYear(Value),
				pc.GetHour(Value),
				pc.GetMinute(Value),
				pc.GetSecond(Value)).Trim();
		}


		public static string GetDayOfWeekPersian(this DayOfWeek Value)
		{
			PersianCalendar pc = new PersianCalendar();

			switch (Value)
			{
				case DayOfWeek.Saturday:
					return "شنبه";
				case DayOfWeek.Sunday:
					return "یک‌شنبه";
				case DayOfWeek.Monday:
					return "دوشنبه";
				case DayOfWeek.Tuesday:
					return "سه‌شنبه";
				case DayOfWeek.Wednesday:
					return "چهارشنبه";
				case DayOfWeek.Thursday:
					return "پنح‌شنبه";
				case DayOfWeek.Friday:
					return "جمعه";
				
				default:
					return "";
			}
		}
	}
}
