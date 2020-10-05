using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Data.Configurations
{
    public class AdvisoryConfig : IEntityTypeConfiguration<Advisory>
    {
        public void Configure(EntityTypeBuilder<Advisory> builder)
        {
            builder.ToTable("Advisory");
            builder.HasKey(d => d.AdvisoryId);
            builder.Property(d => d.AdvisoryId).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Professor)
                .WithMany(x => x.Advisories)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}