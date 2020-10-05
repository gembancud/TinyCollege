using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models;

namespace TinyCollege.Data.Configurations
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(d => d.StudentId);
            builder.Property(d => d.StudentId).ValueGeneratedOnAdd();
            builder.HasOne<Advisory>(s => s.Advisory)
                .WithOne(a => a.Student)
                .HasForeignKey<Advisory>(a => a.StudentId);
        }
    }
}