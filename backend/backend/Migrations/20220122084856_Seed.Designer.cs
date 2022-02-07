﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Models;

namespace backend.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20220122084856_Seed")]
    partial class Seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("backend.Models.Employee", b =>
                {
                    b.Property<int>("empId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("empId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<float>("salary")
                        .HasColumnType("real");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("empId");

                    b.ToTable("employees");

                    b.HasData(
                        new
                        {
                            empId = 1,
                            Phone = "0837418189",
                            address = "Thôn Đông Sơn, xã Hòa Hiệp, Cư Kuin, Đắk Lắk",
                            age = 20,
                            birthday = new DateTime(2002, 11, 30, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            email = "dohai30112002@gmail.com",
                            firstName = "Đỗ Văn",
                            lastName = "Thanh Hải",
                            password = "111",
                            role = 1,
                            salary = 0f,
                            username = "thanhhai"
                        },
                        new
                        {
                            empId = 2,
                            Phone = "0837418189",
                            address = "Thôn Đông Sơn, xã Hòa Hiệp, Cư Kuin, Đắk Lắk",
                            age = 20,
                            birthday = new DateTime(2002, 11, 30, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            email = "haido30112002@gmail.com",
                            firstName = "Đỗ",
                            lastName = "Hải",
                            password = "222",
                            role = 2,
                            salary = 0f,
                            username = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
