using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Confiurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Titles>
    {
        public void Configure(EntityTypeBuilder<Titles> builder)
        {
            builder.HasMany(m => m.TitileGenre)
                .WithOne(g => g.title)
                .HasForeignKey(g => g.TitileId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.TitileDevs)
                .WithOne(a => a.Titles)
                .HasForeignKey(a => a.TitileId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.TitleReviews)
                .WithOne(c => c.titles)
                .HasForeignKey(c => c.TitileId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.TitileRatings)
                .WithOne(r => r.Titles)
                .HasForeignKey(r => r.TitileId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.UserFavorites)
                .WithOne(f => f.titles)
                .HasForeignKey(f => f.TitileId)
                .OnDelete(DeleteBehavior.Restrict);




            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasIndex(x => x.Link).IsUnique();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.Link).IsRequired();
            builder.Property(x => x.Image).IsRequired();
           
        }
    }
}
