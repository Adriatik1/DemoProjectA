using Domain.Entities.Abtractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; } = default!;
        public int Stock { get; set; }
        public Guid UnitId { get; set; }
        public UnitEntity? Unit { get; set; }
        public string? CompanyOrigin { get; set; }
        public string? Description { get; set; }
    }
}
