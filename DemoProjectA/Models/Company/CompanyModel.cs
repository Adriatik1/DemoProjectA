using Domain.Models.Employees;

namespace DemoProjectA.Models.Company
{
    public class CompanyModel
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public List<EmployeeModel>? Employees { get; set; }
    }
}
