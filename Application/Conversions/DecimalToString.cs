using System;

namespace Application.Conversions
{
    public static class DecimalToString
    {
        public static string ConvertNullableDecimalToString(decimal? value)
        {
            if (value is null) return String.Empty;
            return value.ToString();
        }
    }
}
