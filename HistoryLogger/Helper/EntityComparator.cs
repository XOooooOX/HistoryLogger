using HistoryLogger.Model;

namespace HistoryLogger.Helper
{
    public static class EntityComparator
    {
        public static IEnumerable<ModifiedValue> Compare<TOldEntity, TNewEntity>(this TOldEntity tOldEntity, TNewEntity tNewEntity)
            where TOldEntity : class
            where TNewEntity : class
        {
            if (tOldEntity.GetType() != tNewEntity.GetType())
                throw new ArgumentException();

            List<ModifiedValue> modifiedValueDtos = new();

            var tOldProps = tOldEntity.GetType().GetProperties().ToList();
            var tNewProps = tNewEntity.GetType().GetProperties().ToList();

            foreach (var tOldProp in tOldProps)
                foreach (var tNewProp in tNewProps)
                    if (tOldProp.Name == tNewProp.Name)
                    {
                        if (!tNewProp.PropertyType.IsEnum
                            && !tOldProp.PropertyType.IsEnum
                            && (tOldProp.GetValue(tOldEntity)?.ToString() != tNewProp.GetValue(tNewEntity)?.ToString())
                            || tOldProp.PropertyType.IsEnum
                            && tNewProp.PropertyType.IsEnum
                            && ((int)tOldProp.GetValue(tOldEntity)).ToString() != ((int)tNewProp.GetValue(tNewEntity)).ToString())
                        {
                            modifiedValueDtos.Add(new ModifiedValue()
                            {
                                OldValue
                                = tOldProp.PropertyType.IsEnum
                                ? ((int)tOldProp.GetValue(tOldEntity)).ToString()
                                : tOldProp.GetValue(tOldEntity).ToString(),

                                NewValue
                                = tNewProp.PropertyType.IsEnum
                                ? ((int)tNewProp.GetValue(tNewEntity)).ToString()
                                : tNewProp.GetValue(tNewEntity).ToString(),

                                PropertyName = tOldProp.Name
                            });
                        }
                    }

            return modifiedValueDtos;
        }
    }
}
