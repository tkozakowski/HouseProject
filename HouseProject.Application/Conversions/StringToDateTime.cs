using System;

namespace Application.Conversions
{
    public static class StringToDateTime
    {
        public static DateTime? ConvertStringToDateTime(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return new DateTime();
            }

            DateTime result;

            var correct = DateTime.TryParse(date, out result);

            return correct ? result : new DateTime();
        }
    }
}
