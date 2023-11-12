﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TimeServer.Repository.Migrations
{
    [DbContext(typeof(TimeServerDbContext))]
    [Migration("20231112114019_LogRequestCurrentTimes")]
    partial class LogRequestCurrentTimes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("TimeServer.Repository.Entities.LogRequestCurrentTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RequestTimeStampUtc")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LogRequestCurrentTimes");
                });
#pragma warning restore 612, 618
        }
    }
}
