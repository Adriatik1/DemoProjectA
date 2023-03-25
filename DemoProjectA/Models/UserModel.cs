using DemoProjectA.Models.Company;

namespace DemoProjectA.Models
{
    public class UserModel
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public int Age { get; set; }
        public CompanyModel? Company { get; set; }
    }
}
