using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models;

namespace TinyCollege.Data.Configurations
{
    public class SchoolConfig : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("School");
            builder.HasKey(d => d.SchoolId);
            builder.Property(d => d.SchoolId).ValueGeneratedOnAdd();
        }
    }
}