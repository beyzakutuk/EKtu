﻿// <auto-generated />
using System;
using EKtu.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EKtu.Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240502152102_migAttendancePermissionCheckColumnAdd")]
    partial class migAttendancePermissionCheckColumnAdd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EKtu.Domain.Entities.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AttendanceDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PermissionCheck")
                        .HasColumnType("bit");

                    b.Property<string>("ReasonForAbsence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentChooseLessonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentChooseLessonId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.ExamNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Exam1")
                        .HasColumnType("int");

                    b.Property<int>("Exam2")
                        .HasColumnType("int");

                    b.Property<string>("LetterGrade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentChooseLessonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentChooseLessonId")
                        .IsUnique();

                    b.ToTable("ExamNote");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<bool>("HasOptional")
                        .HasColumnType("bit");

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OptionalLessonId")
                        .HasColumnType("int");

                    b.Property<bool>("Term")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("OptionalLessonId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.OptionalLesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LessonType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OptionalLesson");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.Principal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TckNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Principal");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TckNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.StudentChooseLesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentChooseLessons");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TckNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.TeacherClassLesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("LessonId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherClassLesson");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.Attendance", b =>
                {
                    b.HasOne("EKtu.Domain.Entities.StudentChooseLesson", "StudentChooseLesson")
                        .WithMany("Attendances")
                        .HasForeignKey("StudentChooseLessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentChooseLesson");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.ExamNote", b =>
                {
                    b.HasOne("EKtu.Domain.Entities.StudentChooseLesson", "StudentChooseLesson")
                        .WithOne("ExamNote")
                        .HasForeignKey("EKtu.Domain.Entities.ExamNote", "StudentChooseLessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentChooseLesson");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.Lesson", b =>
                {
                    b.HasOne("EKtu.Domain.Entities.OptionalLesson", "OptionalLesson")
                        .WithMany("Lessons")
                        .HasForeignKey("OptionalLessonId");

                    b.Navigation("OptionalLesson");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.Student", b =>
                {
                    b.HasOne("EKtu.Domain.Entities.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.StudentChooseLesson", b =>
                {
                    b.HasOne("EKtu.Domain.Entities.Lesson", "Lesson")
                        .WithMany("StudentChooseLessons")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EKtu.Domain.Entities.Student", "Student")
                        .WithMany("StudentChooseLessons")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.TeacherClassLesson", b =>
                {
                    b.HasOne("EKtu.Domain.Entities.Class", "Class")
                        .WithMany("TeacherClassLessons")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EKtu.Domain.Entities.Lesson", "Lesson")
                        .WithMany("TeacherClassLessons")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EKtu.Domain.Entities.Teacher", "Teacher")
                        .WithMany("TeacherClassLessons")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Lesson");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.Class", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("TeacherClassLessons");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.Lesson", b =>
                {
                    b.Navigation("StudentChooseLessons");

                    b.Navigation("TeacherClassLessons");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.OptionalLesson", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.Student", b =>
                {
                    b.Navigation("StudentChooseLessons");
                });

            modelBuilder.Entity("EKtu.Domain.Entities.StudentChooseLesson", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("ExamNote")
                        .IsRequired();
                });

            modelBuilder.Entity("EKtu.Domain.Entities.Teacher", b =>
                {
                    b.Navigation("TeacherClassLessons");
                });
#pragma warning restore 612, 618
        }
    }
}
