using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.Property(x => x.Category)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.City)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Title)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Venue)
                   .HasMaxLength(100)
                   .IsRequired();
            
            builder.Property(x => x.Description)
                   .HasMaxLength(200)
                   .IsRequired();
        }
    }
}
