﻿// <auto-generated />
using System;
using BackEndApp.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEndApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250126131619_IdDepartamentEmployeeAdd")]
    partial class IdDepartamentEmployeeAdd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackEndApp.Core.Entities.Departament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NameDepartament")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubdivisionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubdivisionId");

                    b.ToTable("Departamentes");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartamentId")
                        .HasColumnType("int");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LevelEducation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.HistoryDepartament", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateChangeHistory")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartamentId")
                        .HasColumnType("int");

                    b.Property<string>("TypeEventDepSub")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DepartamentId");

                    b.ToTable("HistoryDepartamentes");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.HistorySubdivision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateChangeHistory")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubdivisionId")
                        .HasColumnType("int");

                    b.Property<string>("TypeEventDepSub")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SubdivisionId");

                    b.ToTable("HistorySubdivisions");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.JobTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameJobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasMaxLength(20)
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("JobTitles");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.PassportInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssuedBy")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar");

                    b.Property<string>("TypePassport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("WhenIssued")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("PassportsInfo");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.StaffingTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int");

                    b.Property<int>("SubdivisionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobTitleId");

                    b.HasIndex("SubdivisionId");

                    b.ToTable("StaffingTables");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.Subdivision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NameSubdivision")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subdivisions");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.WorkActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date_Event")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartamentId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int");

                    b.Property<int>("TypeEventEmployee")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("JobTitleId");

                    b.ToTable("WorkActivities");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.Departament", b =>
                {
                    b.HasOne("BackEndApp.Core.Entities.Subdivision", "Subdivision")
                        .WithMany("Departaments")
                        .HasForeignKey("SubdivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subdivision");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.Employee", b =>
                {
                    b.HasOne("BackEndApp.Core.Entities.Departament", "Departament")
                        .WithMany("Employees")
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Departament");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.HistoryDepartament", b =>
                {
                    b.HasOne("BackEndApp.Core.Entities.Departament", "Departament")
                        .WithMany("HistoryDepartaments")
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departament");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.HistorySubdivision", b =>
                {
                    b.HasOne("BackEndApp.Core.Entities.Subdivision", "Subdivision")
                        .WithMany("HistorySubdivisions")
                        .HasForeignKey("SubdivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subdivision");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.PassportInfo", b =>
                {
                    b.HasOne("BackEndApp.Core.Entities.Employee", "Employee")
                        .WithMany("PassportsInfo")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.StaffingTable", b =>
                {
                    b.HasOne("BackEndApp.Core.Entities.JobTitle", "JobTitle")
                        .WithMany("StaffingTables")
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndApp.Core.Entities.Subdivision", "Subdivision")
                        .WithMany("StaffingTables")
                        .HasForeignKey("SubdivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobTitle");

                    b.Navigation("Subdivision");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.WorkActivity", b =>
                {
                    b.HasOne("BackEndApp.Core.Entities.Departament", "Departament")
                        .WithMany("WorkActivities")
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndApp.Core.Entities.Employee", "Employee")
                        .WithMany("WorkActivities")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndApp.Core.Entities.JobTitle", "JobTitle")
                        .WithMany("WorkActivities")
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departament");

                    b.Navigation("Employee");

                    b.Navigation("JobTitle");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.Departament", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("HistoryDepartaments");

                    b.Navigation("WorkActivities");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.Employee", b =>
                {
                    b.Navigation("PassportsInfo");

                    b.Navigation("WorkActivities");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.JobTitle", b =>
                {
                    b.Navigation("StaffingTables");

                    b.Navigation("WorkActivities");
                });

            modelBuilder.Entity("BackEndApp.Core.Entities.Subdivision", b =>
                {
                    b.Navigation("Departaments");

                    b.Navigation("HistorySubdivisions");

                    b.Navigation("StaffingTables");
                });
#pragma warning restore 612, 618
        }
    }
}
