namespace PayrollBudget.API.Models
{
    public class PayPeriod
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; } 
        public Employee Employee { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public DateTime StartDater { get; set; }
        public DateTime EndDater { get; set; }

        //ToDo : Change Names
        public decimal NumHrs { get; set; }
        public decimal HrSal { get; set; }
        public decimal SalTotal { get; set; }
        public decimal BenRate { get; set; }
        public decimal BenCost { get; set; }
        public decimal TotalCost { get; set; }

    }
}
