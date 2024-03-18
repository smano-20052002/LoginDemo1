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
    [Migration("20240308100904_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LoginDemo1.Model.Manager", b =>
                {
                    b.Property<int>("ManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("ManagerId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("LoginDemo1.Model.Roles", b =>
                {
                    b.Property<string>("RolesId")
                        .HasColumnType("varchar(95)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("RolesId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LoginDemo1.Model.Trainee", b =>
                {
                    b.Property<int>("TraineeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.HasKey("TraineeId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("TrainerId");

                    b.ToTable("Trainee");
                });

            modelBuilder.Entity("LoginDemo1.Model.Trainer", b =>
                {
                    b.Property<int>("TrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("TrainerId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Trainer");
                });

            modelBuilder.Entity("LoginDemo1.Model.User", b =>
                {
                    b.Property<string>("UserId")
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

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LoginDemo1.Model.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(95)");

                    b.Property<string>("RolesId")
                        .IsRequired()
                        .HasColumnType("varchar(95)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(95)");

                    b.HasKey("Id");

                    b.HasIndex("RolesId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("LoginDemo1.Model.Trainee", b =>
                {
                    b.HasOne("LoginDemo1.Model.Manager", "Manager")
                        .WithMany("Trainees")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoginDemo1.Model.Trainer", "Trainer")
                        .WithMany("Trainee")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("LoginDemo1.Model.Trainer", b =>
                {
                    b.HasOne("LoginDemo1.Model.Manager", "Manager")
                        .WithMany("Trainers")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("LoginDemo1.Model.UserRole", b =>
                {
                    b.HasOne("LoginDemo1.Model.Roles", "Role")
                        .WithMany("userrole")
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoginDemo1.Model.User", "User")
                        .WithMany("userrole")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LoginDemo1.Model.Manager", b =>
                {
                    b.Navigation("Trainees");

                    b.Navigation("Trainers");
                });

            modelBuilder.Entity("LoginDemo1.Model.Roles", b =>
                {
                    b.Navigation("userrole");
                });

            modelBuilder.Entity("LoginDemo1.Model.Trainer", b =>
                {
                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("LoginDemo1.Model.User", b =>
                {
                    b.Navigation("userrole");
                });
#pragma warning restore 612, 618
        }
    }
}
