using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models;

namespace TinyCollege.Data.Configurations
{
    public class ProfessorConfig : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professor");
            builder.HasKey(d => d.ProfessorId);
            builder.Property(d => d.ProfessorId).ValueGeneratedOnAdd();
        }
    }
}