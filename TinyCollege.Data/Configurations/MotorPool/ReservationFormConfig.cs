using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Data.Configurations.MotorPool
{
    public class ReservationFormConfig : IEntityTypeConfiguration<ReservationForm>
    {
        public void Configure(EntityTypeBuilder<ReservationForm> builder)
        {
            builder.ToTable("ReservationForm");
            builder.HasKey(d => d.ReservationFormId);
            builder.Property(d => d.ReservationFormId).ValueGeneratedOnAdd();
        }
    }
}