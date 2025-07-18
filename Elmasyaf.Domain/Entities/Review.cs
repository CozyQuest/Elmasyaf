﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmasyaf.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string ReviewText { get; set; }
        public int Rate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}
