﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPIPayrollCSharp.Models;

#nullable disable

namespace WebAPIPayrollCSharp.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    partial class EmployeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("WebAPIPayrollCSharp.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Wage")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebAPIPayrollCSharp.Models.Folha", b =>
                {
                    b.Property<int>("folhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("employeeId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("employeeId");

                    b.Property<double>("impostoFGTS")
                        .HasColumnType("REAL");

                    b.Property<double>("impostoInss")
                        .HasColumnType("REAL");

                    b.Property<double>("impostoRenda")
                        .HasColumnType("REAL");

                    b.Property<double>("quantidadeHoras")
                        .HasColumnType("REAL");

                    b.Property<double>("salarioBruto")
                        .HasColumnType("REAL");

                    b.Property<double>("salarioLiquido")
                        .HasColumnType("REAL");

                    b.Property<double>("valorHora")
                        .HasColumnType("REAL");

                    b.HasKey("folhaId");

                    b.HasIndex("employeeId");

                    b.ToTable("Folha");
                });

            modelBuilder.Entity("WebAPIPayrollCSharp.Models.Folha", b =>
                {
                    b.HasOne("WebAPIPayrollCSharp.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
