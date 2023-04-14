﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using hc_ef_custom;

#nullable disable

namespace hcefcustom.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("hc_ef_custom.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("InstructorId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("hc_ef_custom.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("hc_ef_custom.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lessons");

                    b.HasDiscriminator<string>("Type").HasValue("Lesson");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("hc_ef_custom.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<byte>("Stars")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("hc_ef_custom.ArticleLesson", b =>
                {
                    b.HasBaseType("hc_ef_custom.Lesson");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("article");
                });

            modelBuilder.Entity("hc_ef_custom.VideoLesson", b =>
                {
                    b.HasBaseType("hc_ef_custom.Lesson");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("video");
                });

            modelBuilder.Entity("hc_ef_custom.Course", b =>
                {
                    b.HasOne("hc_ef_custom.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("hc_ef_custom.Video", "PreviewVideo", b1 =>
                        {
                            b1.Property<int>("CourseId")
                                .HasColumnType("integer");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.HasKey("CourseId");

                            b1.ToTable("Courses");

                            b1.WithOwner()
                                .HasForeignKey("CourseId");

                            b1.OwnsOne("hc_ef_custom.Image", "Thumbnail", b2 =>
                                {
                                    b2.Property<int>("VideoCourseId")
                                        .HasColumnType("integer");

                                    b2.Property<string>("Blurhash")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uuid");

                                    b2.HasKey("VideoCourseId");

                                    b2.ToTable("Courses");

                                    b2.WithOwner()
                                        .HasForeignKey("VideoCourseId");
                                });

                            b1.Navigation("Thumbnail")
                                .IsRequired();
                        });

                    b.Navigation("Instructor");

                    b.Navigation("PreviewVideo")
                        .IsRequired();
                });

            modelBuilder.Entity("hc_ef_custom.Lesson", b =>
                {
                    b.HasOne("hc_ef_custom.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("hc_ef_custom.Rating", b =>
                {
                    b.HasOne("hc_ef_custom.Course", "Course")
                        .WithMany("Ratings")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("hc_ef_custom.VideoLesson", b =>
                {
                    b.OwnsOne("hc_ef_custom.Video", "Video", b1 =>
                        {
                            b1.Property<int>("VideoLessonId")
                                .HasColumnType("integer");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.HasKey("VideoLessonId");

                            b1.ToTable("Lessons");

                            b1.WithOwner()
                                .HasForeignKey("VideoLessonId");

                            b1.OwnsOne("hc_ef_custom.Image", "Thumbnail", b2 =>
                                {
                                    b2.Property<int>("VideoLessonId")
                                        .HasColumnType("integer");

                                    b2.Property<string>("Blurhash")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uuid");

                                    b2.HasKey("VideoLessonId");

                                    b2.ToTable("Lessons");

                                    b2.WithOwner()
                                        .HasForeignKey("VideoLessonId");
                                });

                            b1.Navigation("Thumbnail")
                                .IsRequired();
                        });

                    b.Navigation("Video")
                        .IsRequired();
                });

            modelBuilder.Entity("hc_ef_custom.Course", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("hc_ef_custom.Instructor", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
