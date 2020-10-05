using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models;

namespace TinyCollege.Data.Configurations
{
    public class TenureConfig : IEntityTypeConfiguration<Tenure>
    {
        public void Configure(EntityTypeBuilder<Tenure> builder)
        {
            builder.ToTable("Tenure");
            builder.HasKey(d => d.TenureId);
            builder.Property(d => d.TenureId).ValueGeneratedOnAdd();
        }
    }
}