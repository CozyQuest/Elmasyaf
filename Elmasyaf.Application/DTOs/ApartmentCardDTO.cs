using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmasyaf.Application.DTOs
{
    public class ApartmentCardDTO
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        [Range(20, 40)]
        public decimal Price { get; set; }
    }
}
