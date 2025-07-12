using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmasyaf.Domain.Entities
{
    public class Renting
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}
