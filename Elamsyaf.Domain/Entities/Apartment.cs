using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmasyaf.Domain.Entities
{
    class Apartment
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Space { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
