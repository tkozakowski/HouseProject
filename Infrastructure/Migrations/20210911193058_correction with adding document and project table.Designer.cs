﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseProject.Api.Migrations
{
    [DbContext(typeof(HouseProjectDbContext))]
    [Migration("20210911193058_correction with adding document and project table")]
    partial class correctionwithaddingdocumentandprojecttable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HouseProject.Api.Entities.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ReceivedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Supplier")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("HouseProject.Api.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Application_Fk")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Project_Fk")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReceivedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Supplier")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("Application_Fk");

                    b.HasIndex("Project_Fk");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("HouseProject.Api.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ReceivedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Stage")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Supplier")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("HouseProject.Api.Entities.Document", b =>
                {
                    b.HasOne("HouseProject.Api.Entities.Application", "Application")
                        .WithMany()
                        .HasForeignKey("Application_Fk");

                    b.HasOne("HouseProject.Api.Entities.Project", "Project")
                        .WithMany("Documents")
                        .HasForeignKey("Project_Fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("HouseProject.Api.Entities.Project", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}