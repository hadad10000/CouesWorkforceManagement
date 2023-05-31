namespace CouesWorkforceManagement.Models
{
    public class WorkingHours
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public decimal HoursWorked { get; set; }
    }
}


