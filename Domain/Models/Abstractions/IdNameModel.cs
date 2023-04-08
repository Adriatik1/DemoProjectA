using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Abstractions
{
    public class IdNameModel : IdModel
    {
        public string Name { get; set; } = default!;
    }
}
