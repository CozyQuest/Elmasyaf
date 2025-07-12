using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmasyaf.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
