using Domain.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProductModel : IdNameModel
    {
        public int Stock { get; set; }
        public Guid UnitId { get; set; }
        public string UnitName { get; set; } = default!;
        public string? CompanyOrigin { get; set; }
        public string? Description { get; set; }
    }
}
