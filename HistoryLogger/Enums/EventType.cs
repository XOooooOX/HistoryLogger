using System.ComponentModel.DataAnnotations;

namespace HistoryLogger.Enums
{
    public enum EventType
    {
        [Display(Name = "ایجاد")]
        Add = 1,
        [Display(Name = "ویرایش")]
        Edit = 2,
        [Display(Name = "حذف")]
        Delete = 3
    }
}
