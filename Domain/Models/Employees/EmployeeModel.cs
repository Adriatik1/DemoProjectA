namespace Domain.Models.Employees
{
    public class EmployeeModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? RoleId { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}
