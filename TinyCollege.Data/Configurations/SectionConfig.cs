using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models;

namespace TinyCollege.Data.Configurations
{
    public class SectionConfig : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("Section");
            builder.HasKey(d => d.SectionId);
            builder.Property(d => d.SectionId).ValueGeneratedOnAdd();
            builder.HasOne(s => s.Professor)
                .WithMany(p => p.Sections)
                .HasForeignKey(s => s.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Schedule)
                .WithOne(x => x.Section)
                .HasForeignKey<Schedule>(x => x.SectionId);
        }
    }
}