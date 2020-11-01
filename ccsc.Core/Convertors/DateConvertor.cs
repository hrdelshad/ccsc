using System;
using System.Globalization;

namespace ccsc.Core.Convertors
{
	public static class DateConvertor
	{
		public static string PersianDate(this DateTime value)
		{
			PersianCalendar pc = new PersianCalendar();

			return pc.GetYear(value) + "/" +
				   pc.GetMonth(value).ToString("00") + "/" +
				   pc.GetDayOfMonth(value).ToString("00");
		}

		public static string PersianDateDayOfWeek(this DateTime value)
		{
			PersianCalendar pc = new PersianCalendar();

			return string.Format("{0}, {1}/{2}/{3} {4}:{5}:{6}",
				pc.GetDayOfWeek(value).GetDayOfWeekPersian(),
				pc.GetMonth(value),
				pc.GetDayOfMonth(value),
				pc.GetYear(value),
				pc.GetHour(value),
				pc.GetMinute(value),
				pc.GetSecond(value)).Trim();
		}


		public static string GetDayOfWeekPersian(this DayOfWeek value)
		{
			PersianCalendar pc = new PersianCalendar();

			switch (value)
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

		public static string GetQuarterPersian(this DateTime value)
		{
			PersianCalendar pc = new PersianCalendar();
			var month = pc.GetMonth(value);
			switch (month)
			{
				case 1 : return "بهار";
				case 2 : return "بهار";
				case 3 : return "بهار";
				case 4 : return "تابستان";
				case 5 : return "تابستان";
				case 6 : return "تابستان";
				case 7 : return "پاییز ";
				case 8 : return "پاییز";
				case 9 : return "پاییز";
				case 10: return "زمستان";
				case 11: return "زمستان";
				case 12: return "زمستان";

				default: return "";
			}
		}
	}
}
