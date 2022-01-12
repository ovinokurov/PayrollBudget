namespace PayrollBudget.API.Models
{
    public class Accession
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public int OfficeId { get; set; }   
        public Office? Office { get; set; }
        public int PayrollDetailId { get; set; }    
        public PayrollDetail? PayrollDetail { get; set; }
    }
}
