using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Data.Configurations.MotorPool
{
    public class MaintenanceConfig : IEntityTypeConfiguration<Maintenance>
    {
        public void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            builder.ToTable("Maintenance");
            builder.HasKey(d => d.MaintenanceId);
            builder.Property(d => d.MaintenanceId).ValueGeneratedOnAdd();
        }
    }
}