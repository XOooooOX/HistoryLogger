namespace HistoryLogger.Model
{
    public class HistoryExplain
    {
        public int Id { get; set; }
        public string EventTypePersianTitle { get; set; }
        public string EntityPersianTitle { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string IdentifierValue { get; set; }
        public string AliasValue { get; set; }
        public IList<string> ModifiedValues { get; set; }
    }
}
