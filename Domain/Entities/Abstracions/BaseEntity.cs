using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Abstracions
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public BaseEntity()
        {
            Id = Guid.NewGuid();    
        }

        public BaseEntity(Guid existingId)
        {
            Id = existingId;
        }
    }
}
