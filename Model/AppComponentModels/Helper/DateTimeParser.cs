using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AppComponentModels.Helper
{
    public class DateTimeParser
    {
        private const string DateFormat = "dd.MM.yyyy HH:mm";
        /// <summary>
        /// Gets the Date in the desired format
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string GetDateString(DateTime dateTime)
        {
            return dateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
        }
    }
}
