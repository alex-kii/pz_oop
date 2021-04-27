
namespace Web_Service.Models
{
    public class RestroomInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AdmArea { get; set; }

        public string District { get; set; }

        public string Location { get; set; }

        public string CloseFlag { get; set; }

        public System.Collections.Generic.List<WorkingHours> WorkingHours { get; set; } = new System.Collections.Generic.List<WorkingHours>();

        public string PaidService { get; set; }

        public string BalanceHolderName { get; set; }
    }
}