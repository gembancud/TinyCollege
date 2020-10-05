using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models;

namespace TinyCollege.Data.Configurations
{
    public class ScheduleConfig : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule");
            builder.HasKey(d => d.ScheduleId);
            builder.Property(d => d.ScheduleId).ValueGeneratedOnAdd();
            builder.HasOne<Section>(s => s.Section)
                .WithOne(s => s.Schedule)
                .HasForeignKey<Section>(s => s.SectionId);
        }
    }
}