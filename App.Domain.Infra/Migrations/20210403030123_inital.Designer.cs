﻿// <auto-generated />
using System;
using App.Domain.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Domain.Infra.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210403030123_inital")]
    partial class inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("App.Domain.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("COURSES");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6cae6747-c6c7-45eb-8081-b4833e16b713"),
                            Name = "IT Development"
                        },
                        new
                        {
                            Id = new Guid("2ce86027-efa8-44b9-8b3b-b3fd96642247"),
                            Name = "Software Egineering"
                        },
                        new
                        {
                            Id = new Guid("c2c4b3ea-7869-440a-8236-c6d42bb77f42"),
                            Name = "Biology"
                        });
                });

            modelBuilder.Entity("App.Domain.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("NAME");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PERIOD");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PHOTO");

                    b.Property<string>("Register")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("REGISTER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("STATUS");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("STUDENTS");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f781d43c-2ad2-46af-bbdb-d2cb849c2df9"),
                            CourseId = new Guid("6cae6747-c6c7-45eb-8081-b4833e16b713"),
                            Name = "Matheus Angelo",
                            Period = "Night",
                            Photo = "https://via.placeholder.com/150",
                            Register = "D06JGF",
                            Status = "Active"
                        });
                });

            modelBuilder.Entity("App.Domain.Models.StudentSubject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<double>("Average")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentSubjects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b580b915-ea60-4725-8615-4ae417849d5e"),
                            Average = 8.0,
                            StudentId = new Guid("f781d43c-2ad2-46af-bbdb-d2cb849c2df9"),
                            SubjectId = new Guid("9d8d776e-6a6f-49e0-b1ed-0546d50efece")
                        });
                });

            modelBuilder.Entity("App.Domain.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("MinAverageApproval")
                        .HasColumnType("float")
                        .HasColumnName("MIN_AVERAGE_APPROVAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("NAME");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("SUBJECTS");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9d8d776e-6a6f-49e0-b1ed-0546d50efece"),
                            CourseId = new Guid("6cae6747-c6c7-45eb-8081-b4833e16b713"),
                            MinAverageApproval = 7.0999999999999996,
                            Name = "Phisics"
                        },
                        new
                        {
                            Id = new Guid("6d70cff6-09d8-4a16-b487-296462538f69"),
                            CourseId = new Guid("6cae6747-c6c7-45eb-8081-b4833e16b713"),
                            MinAverageApproval = 7.0999999999999996,
                            Name = "Math"
                        },
                        new
                        {
                            Id = new Guid("e7ddcd09-25a1-4791-853b-4742c9166e5d"),
                            CourseId = new Guid("c2c4b3ea-7869-440a-8236-c6d42bb77f42"),
                            MinAverageApproval = 7.0999999999999996,
                            Name = "HealthCare"
                        },
                        new
                        {
                            Id = new Guid("cede3eb3-b251-4ce5-b8c4-fef9838cf76d"),
                            CourseId = new Guid("2ce86027-efa8-44b9-8b3b-b3fd96642247"),
                            MinAverageApproval = 7.0999999999999996,
                            Name = "OOP"
                        });
                });

            modelBuilder.Entity("App.Domain.Models.Student", b =>
                {
                    b.HasOne("App.Domain.Models.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("App.Domain.Models.StudentSubject", b =>
                {
                    b.HasOne("App.Domain.Models.Student", "Student")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Models.Subject", "Subject")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("App.Domain.Models.Subject", b =>
                {
                    b.HasOne("App.Domain.Models.Course", "Course")
                        .WithMany("Subjects")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("App.Domain.Models.Course", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("App.Domain.Models.Student", b =>
                {
                    b.Navigation("StudentSubjects");
                });

            modelBuilder.Entity("App.Domain.Models.Subject", b =>
                {
                    b.Navigation("StudentSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
