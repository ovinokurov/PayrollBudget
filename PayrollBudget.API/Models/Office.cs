using System.ComponentModel.DataAnnotations;

namespace PayrollBudget.API.Models
{
    public class Office
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Title { get; set; } = string.Empty;
        public int StaffCount { get; set; }
    }
}
