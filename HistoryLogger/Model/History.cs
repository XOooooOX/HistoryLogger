using HistoryLogger.Enums;

namespace HistoryLogger.Model
{
    public class History
    {
        public int Id { get; set; }
        public EventType EventType { get; set; }
        public string EntityName { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string IdentifierValue { get; set; }
        public string AliasValue { get; set; }
        public IEnumerable<ModifiedValue> ModifiedValues { get; set; }
    }
}
