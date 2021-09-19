using Domain.Enum;
using System;

namespace Application.Conversions
{
    public static class StringToEnum
    {
        public static Stage ConvertStringToEnumStage(string stage)
        {
            object result;
            return Enum.TryParse(typeof(Stage), stage, out result) ? (Stage)result : Stage.other;
        }
    }
}
