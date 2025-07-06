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
    class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Description).HasMaxLength(500);
            builder.Property(a => a.Price).HasColumnType("decimal(18,2)");
            builder.HasQueryFilter(a => !a.IsDeleted);
        }
    }
}
