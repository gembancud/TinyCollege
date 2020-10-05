using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Data.Configurations.MotorPool
{
    public class PartUsageConfig : IEntityTypeConfiguration<PartUsage>
    {
        public void Configure(EntityTypeBuilder<PartUsage> builder)
        {
            builder.ToTable("PartUsage");
            builder.HasKey(d => d.PartUsageId);
            builder.Property(d => d.PartUsageId).ValueGeneratedOnAdd();
        }
    }
}