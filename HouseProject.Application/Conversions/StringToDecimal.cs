using System;

namespace Application.Conversions
{
    public static class StringToDecimal
    {
        public static decimal? ConvertStringToDecimal(string cost)
        {
            if (string.IsNullOrEmpty(cost)) return 0M;

            decimal result;
            var success = Decimal.TryParse(cost, out result);

            return success ? result : 0M;
        }
    }
}
