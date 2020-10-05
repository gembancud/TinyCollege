using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Data.Configurations.MotorPool
{
    public class PartConfig : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.ToTable("Part");
            builder.HasKey(d => d.PartId);
            builder.Property(d => d.PartId).ValueGeneratedOnAdd();
        }
    }
}