using HistoryLogger.Model;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HistoryLogger.Helper
{
    public static class HistoryExplainer
    {
        public static IList<HistoryExplain> ToExplain<TEntity>(this IEnumerable<History> historyDTOs)
        {
            List<HistoryExplain> historyExplainDTO = new();

            if (!historyDTOs.Any())
                return historyExplainDTO;

            foreach (var item in historyDTOs)
                historyExplainDTO.Add(item.ToExplain<TEntity>());

            return historyExplainDTO;
        }

        public static HistoryExplain ToExplain<TEntity>(this History history)
        {
            string entityName = GetEntityDisplayName<TEntity>();

            return new HistoryExplain()
            {
                Id = history.Id,
                Date = history.Date,
                Description = history.Description,
                IdentifierValue = history.IdentifierValue,
                UserId = history.UserId,
                UserName = history.UserName,
                EntityPersianTitle = entityName,
                EventTypePersianTitle = history.EventType.DisplayName(),
                AliasValue = history.AliasValue,
                ModifiedValues = ToExplainModifiedValues<TEntity>(history)
            };
        }

        private static IList<string> ToExplainModifiedValues<TEntity>(History history)
        {
            List<string> result = new();

            if (!history.ModifiedValues.Any())
                return result;

            var props = typeof(TEntity).GetProperties().ToList();

            foreach (var item in history.ModifiedValues)
            {
                var prop = props.FirstOrDefault(o => o.Name == item.PropertyName);

                var oldValue = GetTitleByType(item.OldValue, prop);
                var newValue = GetTitleByType(item.NewValue, prop);

                result.Add($"{history.EventType.DisplayName()} {prop.GetPropertyDisplayName()} از {oldValue} به {newValue}");
            }

            return result;
        }

        private static string GetTitleByType(string value, PropertyInfo prop)
        {
            string result;

            if (prop.PropertyType.IsEnum)
                result = (Enum.ToObject(prop.PropertyType, int.Parse(value)) as Enum).DisplayName();
            else if (prop.PropertyType == typeof(bool))
                result = bool.Parse(value) ? prop.GetBoolDisplayName().ActiveTitle : prop.GetBoolDisplayName().DeActiveTitle;
            else if (prop.PropertyType == typeof(DateTime))
                result = Convert.ToDateTime(value).UtcToPersian();
            else
                result = value;

            return result;
        }


        private static string GetEntityDisplayName<TEntity>()
        {
            var entityName = typeof(TEntity).Name;

            object[] entityAttrs = typeof(TEntity).GetCustomAttributes(typeof(DisplayAttribute), false);

            if (entityAttrs.Length > 0)
                entityName = ((DisplayAttribute)entityAttrs[0]).Name;

            return entityName;
        }

        private static string GetPropertyDisplayName(this PropertyInfo propertyInfo)
        {
            var propName = propertyInfo.Name;

            object[] entityAttrs = GetCustomAttribute<DisplayAttribute>(propertyInfo);

            if (entityAttrs.Length > 0)
                propName = ((DisplayAttribute)entityAttrs[0]).Name;

            return propName;
        }

        private static (string ActiveTitle, string DeActiveTitle) GetBoolDisplayName(this PropertyInfo propertyInfo)
        {
            var activeTitle = string.Empty;
            var deActiveTitle = string.Empty;

            object[] entityAttrs = GetCustomAttribute<BoolDisplayAttribute>(propertyInfo);

            if (entityAttrs.Length > 0)
            {
                activeTitle = ((BoolDisplayAttribute)entityAttrs[0]).ActiveTitle;
                deActiveTitle = ((BoolDisplayAttribute)entityAttrs[0]).DeActiveTitle;
            }

            return (activeTitle, deActiveTitle);
        }

        private static object[] GetCustomAttribute<T>(PropertyInfo propertyInfo)
            => propertyInfo.GetCustomAttributes(typeof(T), false);
    }
}
