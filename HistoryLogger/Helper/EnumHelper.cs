using HistoryLogger.Model;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HistoryLogger.Helper
{
    public static partial class EnumHelper
    {
        public static IEnumerable<EnumHelperModel> EnumToList<TEmum>() where TEmum : Enum
        {
            foreach (var item in Enum.GetValues(typeof(TEmum)))
                yield return new()
                {
                    Code = (int)item,
                    EnglishTitle = ((TEmum)item).ToString(),
                    PersianTitle = ((TEmum)item).DisplayName()?.ToString()
                };
        }

        public static string DisplayName<T>(this T enums) where T : Enum
        {
            Type enumType = enums.GetType();

            string enumValue = Enum.GetName(enumType, enums);

            MemberInfo member = enumType.GetMember(enumValue)[0];

            object[] attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);

            string outString = "";

            if (attrs.Length > 0)
            {
                outString = ((DisplayAttribute)attrs[0]).Name;

                if (((DisplayAttribute)attrs[0]).ResourceType != null)
                    outString = ((DisplayAttribute)attrs[0]).GetName();
            }
            return outString;
        }
    }
}
