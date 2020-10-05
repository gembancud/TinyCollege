using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models;

namespace TinyCollege.Data.Configurations
{
    public class ProfessorContractConfig : IEntityTypeConfiguration<ProfessorContract>
    {
        public void Configure(EntityTypeBuilder<ProfessorContract> builder)
        {
            builder.ToTable("ProfessorContract");
            builder.HasKey(d => d.ProfessorContractId);
            builder.Property(d => d.ProfessorContractId).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Professor)
                .WithMany(x => x.ProfessorContracts)
                .HasForeignKey(x => x.ProfessorId);
            builder.HasOne(x => x.Contract)
                .WithMany(x => x.ProfessorContracts)
                .HasForeignKey(x => x.ContractId);
        }
    }
}