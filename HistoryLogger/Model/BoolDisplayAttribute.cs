namespace HistoryLogger.Model
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BoolDisplayAttribute : Attribute
    {
        public string ActiveTitle { get; set; }
        public string DeActiveTitle { get; set; }

        public BoolDisplayAttribute(string activeTitle, string deActiveTitle)
        {
            ActiveTitle = activeTitle;
            DeActiveTitle = deActiveTitle;
        }
    }
}
