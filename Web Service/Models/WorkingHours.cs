

namespace Web_Service.Models
{
    public class WorkingHours
    {
        public int Id { get; set; }
        public string DayOfWeek { get; set; }
        public string Hours{ get; set; }

        public System.Collections.Generic.List<RestroomInfo> RestroomInfo { get; set; } = new System.Collections.Generic.List<RestroomInfo>();
    }
}