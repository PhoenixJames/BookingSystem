﻿// <auto-generated />
using System;
using BookingSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookingSystem.Migrations
{
    [DbContext(typeof(BookingSystemContext))]
    partial class BookingSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BookingSystem.Entities.Class", b =>
                {
                    b.Property<long>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("class_id");

                    b.Property<DateTime>("ClassDateTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("class_date_time");

                    b.Property<string>("ClassName")
                        .HasColumnType("longtext")
                        .HasColumnName("class_name");

                    b.Property<string>("Country")
                        .HasColumnType("longtext")
                        .HasColumnName("country");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasColumnName("duration");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int")
                        .HasColumnName("max_capacity");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_date");

                    b.HasKey("ClassId");

                    b.ToTable("classes");
                });

            modelBuilder.Entity("BookingSystem.Entities.Package", b =>
                {
                    b.Property<long>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("package_id");

                    b.Property<string>("Country")
                        .HasColumnType("longtext")
                        .HasColumnName("country");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<int>("Credits")
                        .HasColumnType("int")
                        .HasColumnName("credits");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasColumnName("duration");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("PackageName")
                        .HasColumnType("longtext")
                        .HasColumnName("package_name");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_date");

                    b.HasKey("PackageId");

                    b.ToTable("packages");
                });

            modelBuilder.Entity("BookingSystem.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<string>("Country")
                        .HasColumnType("longtext")
                        .HasColumnName("country");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("Password")
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_date");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext")
                        .HasColumnName("user_name");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("BookingSystem.Entities.UserClass", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<long>("ClassId")
                        .HasColumnType("bigint")
                        .HasColumnName("class_id");

                    b.Property<DateTime>("BookingDateTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("booking_date_time");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_date");

                    b.HasKey("UserId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("user_classes");
                });

            modelBuilder.Entity("BookingSystem.Entities.UserPackage", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<long>("PackageId")
                        .HasColumnType("bigint")
                        .HasColumnName("package_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("expiry_date");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("purchase_date");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_date");

                    b.Property<int>("UserCredits")
                        .HasColumnType("int")
                        .HasColumnName("user_credits");

                    b.HasKey("UserId", "PackageId");

                    b.HasIndex("PackageId");

                    b.ToTable("user_packages");
                });

            modelBuilder.Entity("BookingSystem.Entities.UserProfile", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<string>("DOB")
                        .HasColumnType("longtext")
                        .HasColumnName("dob");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_date");

                    b.HasKey("UserId");

                    b.ToTable("user_profile");
                });

            modelBuilder.Entity("BookingSystem.Entities.Waitlist", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<long>("ClassId")
                        .HasColumnType("bigint")
                        .HasColumnName("class_id");

                    b.Property<DateTime>("BookingDateTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("booking_date_time");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_date");

                    b.HasKey("UserId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("waitlist");
                });

            modelBuilder.Entity("BookingSystem.Entities.UserClass", b =>
                {
                    b.HasOne("BookingSystem.Entities.Class", "Class")
                        .WithMany("UserClasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingSystem.Entities.User", "User")
                        .WithMany("Classes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookingSystem.Entities.UserPackage", b =>
                {
                    b.HasOne("BookingSystem.Entities.Package", "Package")
                        .WithMany("UserPackages")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingSystem.Entities.User", "User")
                        .WithMany("Packages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookingSystem.Entities.UserProfile", b =>
                {
                    b.HasOne("BookingSystem.Entities.User", null)
                        .WithOne("Profile")
                        .HasForeignKey("BookingSystem.Entities.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingSystem.Entities.Waitlist", b =>
                {
                    b.HasOne("BookingSystem.Entities.Class", "Class")
                        .WithMany("Waitlists")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingSystem.Entities.User", "User")
                        .WithMany("Waitlists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookingSystem.Entities.Class", b =>
                {
                    b.Navigation("UserClasses");

                    b.Navigation("Waitlists");
                });

            modelBuilder.Entity("BookingSystem.Entities.Package", b =>
                {
                    b.Navigation("UserPackages");
                });

            modelBuilder.Entity("BookingSystem.Entities.User", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Packages");

                    b.Navigation("Profile")
                        .IsRequired();

                    b.Navigation("Waitlists");
                });
#pragma warning restore 612, 618
        }
    }
}
