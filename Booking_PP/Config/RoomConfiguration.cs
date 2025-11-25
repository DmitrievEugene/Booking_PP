using Booking_PP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking_PP.Config
{
    class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.ID);

            builder.HasOne(x => x.User)
                    .WithMany(x => x.Rooms)
                    .HasForeignKey(x => x.UserID);

            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.NumberRoom).IsRequired();
            builder.Property(x => x.PriceRoom).HasPrecision(18,2)
                                              .IsRequired();
            builder.Property(x => x.DescriptionRoom).HasDefaultValue("Без описания");
        }
    }
}