using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Data.Configurations.MotorPool
{
    public class ReportConfig : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Report");
            builder.HasKey(d => d.ReportId);
            builder.Property(d => d.ReportId).ValueGeneratedOnAdd();
        }
    }
}