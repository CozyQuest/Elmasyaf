using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elmasyaf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elmasyaf.Infrastructure.Configurations
{
    class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.FName).IsRequired();
            builder.Property(a => a.LName).IsRequired();
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Password).IsRequired();
            builder.Property(a => a.Phone).IsRequired();
        }
    }
}
