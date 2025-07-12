using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elmasyaf.Domain.Interfaces;

namespace Elmasyaf.Domain.Entities
{
    public class User : ISoftDeletable
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UrlProfilePicture { get; set; }
        public string GoogleSubId { get; set; }
        public bool Role { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Renting> Rentings { get; set; }
    }
}
