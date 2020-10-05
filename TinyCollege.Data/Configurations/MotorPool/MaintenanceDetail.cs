using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Data.Configurations.MotorPool
{
    public class MaintenanceDetailConfig : IEntityTypeConfiguration<MaintenanceDetail>
    {
        public void Configure(EntityTypeBuilder<MaintenanceDetail> builder)
        {
            builder.ToTable("MaintenanceDetail");
            builder.HasKey(d => d.MaintenanceDetailId);
            builder.Property(d => d.MaintenanceDetailId).ValueGeneratedOnAdd();
        }
    }
}