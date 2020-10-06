using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models;

namespace TinyCollege.Data.Configurations
{
    public class ProfessorshipConfig : IEntityTypeConfiguration<Professorship>
    {
        public void Configure(EntityTypeBuilder<Professorship> builder)
        {
            builder.ToTable("Professorship");
            builder.HasKey(d => d.ProfessorShipId);
            builder.Property(d => d.ProfessorShipId).ValueGeneratedOnAdd();
        }
    }
}