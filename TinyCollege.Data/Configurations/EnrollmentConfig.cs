using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models;

namespace TinyCollege.Data.Configurations
{
    public class EnrollmentConfig : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment");
            builder.HasKey(d => d.EnrollmentId);
            builder.Property(d => d.EnrollmentId).ValueGeneratedOnAdd();
        }
    }
}