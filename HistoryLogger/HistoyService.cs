using HistoryLogger.Enums;
using HistoryLogger.Helper;
using HistoryLogger.Model;

namespace HistoryLogger
{
    public class HistoryService
    {
        public HistoryService() { }

        public async Task<IEnumerable<EnumHelperModel>> GetAllEventTypeAsync()
            => await Task.Run(() => EnumHelper.EnumToList<EventType>());

        public async Task AddHistoryAsync<TEntity>(EventType eventType, string aliasValue)
            => await InsertAsync(new History()
            {
                EventType = eventType,
                EntityName = typeof(TEntity).Name,
                Date = DateTime.UtcNow,
                UserId = 1,
                UserName = "",
                AliasValue = aliasValue
            });

        public async Task AddHistoryAsync<TEntity>(EventType eventType, string aliasValue, string description)
            => await InsertAsync(new History()
            {
                EventType = eventType,
                EntityName = typeof(TEntity).Name,
                Date = DateTime.UtcNow,
                UserId = 1,
                UserName = "",
                Description = description,
                AliasValue = aliasValue
            });

        public async Task AddHistoryAsync<TEntity>(EventType eventType, string aliasValue, string description, string identifierValue)
            => await InsertAsync(new History()
            {
                EventType = eventType,
                EntityName = typeof(TEntity).Name,
                Date = DateTime.UtcNow,
                UserId = 1,
                UserName = "",
                IdentifierValue = identifierValue,
                AliasValue = aliasValue,
                Description = description
            });

        public async Task AddHistoryAsync<TEntity>(EventType eventType, string aliasValue, string identifierValue, IEnumerable<ModifiedValue> modifiedValues)
            => await InsertAsync(new History()
            {
                EventType = eventType,
                EntityName = typeof(TEntity).Name,
                Date = DateTime.UtcNow,
                UserId = 1,
                UserName = "",
                IdentifierValue = identifierValue,
                ModifiedValues = modifiedValues,
                AliasValue = aliasValue
            });

        public async Task AddHistoryAsync<TEntity>(EventType eventType, string aliasValue, string identifierValue, IEnumerable<ModifiedValue> modifiedValues, string description)
            => await InsertAsync(new History()
            {
                EventType = eventType,
                EntityName = typeof(TEntity).Name,
                Date = DateTime.UtcNow,
                UserId = 1,
                UserName = "",
                IdentifierValue = identifierValue,
                ModifiedValues = modifiedValues,
                Description = description,
                AliasValue = aliasValue
            });

        private async Task InsertAsync(History history)
            => await Task.Run(()
                => Task.Delay(100));
    }
}
