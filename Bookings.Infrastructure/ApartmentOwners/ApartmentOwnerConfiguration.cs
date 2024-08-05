using Bookings.Domain.ApartmentOwners;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure.ApartmentOwners;
public class ApartmentOwnerConfiguration : IEntityTypeConfiguration<ApartmentOwner>
{
    public void Configure(EntityTypeBuilder<ApartmentOwner> builder)
    {
        builder.HasIndex(c => c.IdentityCardNumber).IsUnique();
    }
}
