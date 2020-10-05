using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Data.Configurations.MotorPool
{
    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");
            builder.HasKey(d => d.ReservationId);
            builder.Property(d => d.ReservationId).ValueGeneratedOnAdd();
        }
    }
}