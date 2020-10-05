using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models;

namespace TinyCollege.Data.Configurations
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            builder.HasKey(d => d.DepartmentId);
            builder.Property(d => d.DepartmentId).ValueGeneratedOnAdd();
            builder.HasOne(d => d.School)
                .WithMany(s => s.Departments)
                .HasForeignKey(x => x.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}