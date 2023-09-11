
using Domain.Entities;
using Domain.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;
using System.Xml.Linq;

namespace Data.Maps
{
    internal class RenterMapper : IEntityTypeConfiguration<Renter>
    {
        public void Configure(EntityTypeBuilder<Renter> builder)
        {
            builder.ToTable("Renter");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Birth).HasColumnName("Birth");
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber");
            builder.Property(x => x.Address).HasColumnName("Address");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.CPF).HasColumnName("CPF");
            builder.Property(x => x.IdentityDocumentNumber).HasColumnName("IdentityDocumentNumber");
            builder.Property(x => x.DriverLicenseNumber).HasColumnName("DriverLicenseNumber");
            builder.Property(x => x.DocumentType).HasColumnName("DocumentType");

           // builder.HasMany(x => x.Cars).WithOne(x => x.Model).HasForeignKey(x => x.ModelId);
        }
    }
}
