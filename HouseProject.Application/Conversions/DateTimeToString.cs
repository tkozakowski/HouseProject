using System;

namespace Application.Conversions
{
    public static class DateTimeToString
    {
        public static string ConvertNullableDateTimeToString(DateTime? date)
        {
            if (date is null) return String.Empty;
            return date.ToString();
        }
    }
}
