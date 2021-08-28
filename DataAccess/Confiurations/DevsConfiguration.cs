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
    public class DevsConfiguration : IEntityTypeConfiguration<Devs>
    {
        public void Configure(EntityTypeBuilder<Devs> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            

            builder.HasMany(a => a.TitileDevs)
                .WithOne(m => m.Devs)
                .HasForeignKey(m => m.DevsId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
