using Domain.Entities.Abtractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UnitEntity : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
    }
}
