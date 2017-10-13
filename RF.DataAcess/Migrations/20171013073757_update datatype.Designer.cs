﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RF.DataAcess;
using System;

namespace RF.DataAcess.Migrations
{
    [DbContext(typeof(ScvDbContext))]
    [Migration("20171013073757_update datatype")]
    partial class updatedatatype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RF.Models.OrderPartInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("TrackingNumber")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("OrderPartInfo","Order");
                });
#pragma warning restore 612, 618
        }
    }
}
