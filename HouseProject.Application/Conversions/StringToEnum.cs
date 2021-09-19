using Domain.Enum;
using System;

namespace Application.Conversions
{
    public static class StringToEnum
    {
        public static Stage ConvertStringToEnumStage(string stage)
        {
            bool success = false;
            object result;

            var stages = EnumToIEnumerable.GetValues<Stage>();
            foreach (var item in stages)
            {
                if (item.ToString() == stage)
                {
                    success = Enum.TryParse(typeof(Stage), item.ToString(), out result);
                    return success ? (Stage)result : Stage.other;
                }
            }
            return Stage.other;
        }
    }
}
