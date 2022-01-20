using System.ComponentModel.DataAnnotations;

namespace HistoryLogger.Model
{
    public class Foo
    {
        [Display(Name ="شناسه")]
        public int Id { get; set; }

        [Display(Name = "وضعیت")]
        [BoolDisplay(activeTitle:"فعال",deActiveTitle:"غیرفعال")]
        public bool State { get; set; }
    }
}
