using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps
{
    public class CarMapper : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Car");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Photo).HasColumnName("Photo");
            builder.Property(x => x.Brand).HasColumnName("Brand");
            builder.Property(x => x.Color).HasColumnName("Color");
            builder.Property(x => x.Doors).HasColumnName("Doors");
            builder.Property(x => x.Steering).HasColumnName("Steering");
            builder.Property(x => x.PowerWindow).HasColumnName("PowerWindow");
            builder.Property(x => x.PowerDoorLocks).HasColumnName("PowerDoorLocks");
            builder.Property(x => x.AirConditioner).HasColumnName("AirConditioner");
            builder.Property(x => x.Trunk).HasColumnName("Trunk");
            builder.Property(x => x.Price).HasColumnName("Price");
            builder.Property(x => x.Available).HasColumnName("Available");

            builder.HasOne(x => x.Model).WithMany(x => x.Cars).HasForeignKey(x => x.ModelId);
        }
    }
}
