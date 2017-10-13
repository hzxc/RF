using Microsoft.EntityFrameworkCore;
using RF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RF.DataAcess.Configurations
{
    public class OrderPartInfoConfigurations : IEntityTypeConfiguration<OrderPartInfo>
    {
        public void Configure(EntityTypeBuilder<OrderPartInfo> builder)
        {
            builder.ToTable("OrderPartInfo")
            .HasKey(s => s.Id);
            
            builder.Property(o => o.TrackingNumber).IsRequired().HasMaxLength(100);
            builder.Property(o => o.SerialNumber).IsRequired().HasMaxLength(100);
        }
    }
}
