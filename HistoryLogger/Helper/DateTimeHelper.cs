using System.Globalization;

namespace HistoryLogger.Helper
{
    public static class DateTimeHelper
    {
        public static string UtcToPersian(this DateTime dateTime)
        {

            PersianCalendar pc = new PersianCalendar();
            return string.Format("{0}/{1}/{2}", pc.GetYear(dateTime), pc.GetMonth(dateTime), pc.GetDayOfMonth(dateTime));
        }
    }
}
