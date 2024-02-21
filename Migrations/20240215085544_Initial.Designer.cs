﻿// <auto-generated />
using System;
using LoginDemo1.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoginDemo1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240215085544_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LoginDemo1.Model.Roles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(95)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LoginDemo1.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(95)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LockoutEnd")
                        .HasColumnType("datetime");

                    b.Property<long>("MobileNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LoginDemo1.Model.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(95)");

                    b.Property<string>("RolesId")
                        .HasColumnType("varchar(95)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(95)");

                    b.HasKey("Id");

                    b.HasIndex("RolesId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("LoginDemo1.Model.UserRole", b =>
                {
                    b.HasOne("LoginDemo1.Model.Roles", null)
                        .WithMany("userrole")
                        .HasForeignKey("RolesId");

                    b.HasOne("LoginDemo1.Model.User", null)
                        .WithMany("userrole")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("LoginDemo1.Model.Roles", b =>
                {
                    b.Navigation("userrole");
                });

            modelBuilder.Entity("LoginDemo1.Model.User", b =>
                {
                    b.Navigation("userrole");
                });
#pragma warning restore 612, 618
        }
    }
}
