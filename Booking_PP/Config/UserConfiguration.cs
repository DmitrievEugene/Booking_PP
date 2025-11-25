using Booking_PP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking_PP.Config
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.UserFirstName).IsRequired();
            builder.Property(x => x.UserSecondName).IsRequired();
            builder.Property(x => x.UserPhoneNumber).IsRequired();
        }
    }
}