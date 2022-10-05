using System;
using System.Collections.Generic;
using System.Text;

namespace _05.DateModifier
{
    public class DateModifier
    {
		public static int CalculateDaysSpan(string date1, string date2)
		{
			DateTime firstDate = DateTime.ParseExact(date1, "yyyy MM dd", null);
            DateTime secondDate = DateTime.ParseExact(date2, "yyyy MM dd", null);

			TimeSpan difference = firstDate - secondDate;

			return Math.Abs(difference.Days);
        }
	}
}
