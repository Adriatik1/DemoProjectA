﻿using Domain.Entities.Abstracions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string UserEmail { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; } = default!;
    }
}
