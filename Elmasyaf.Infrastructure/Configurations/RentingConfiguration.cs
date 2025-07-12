using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elmasyaf.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Elmasyaf.Infrastructure.Configurations
{
    class RentingConfiguration : IEntityTypeConfiguration<Renting>
    {
        public void Configure(EntityTypeBuilder<Renting> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(a => a.TotalPrice)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(r => r.Property)
                   .WithMany(p => p.Rentings)
                   .HasForeignKey(r => r.PropertyId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.User)
                   .WithMany(u => u.Rentings)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(r => !r.IsDeleted);
        }
    }
}
