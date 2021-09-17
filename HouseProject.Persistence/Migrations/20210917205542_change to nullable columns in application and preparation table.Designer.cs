﻿// <auto-generated />
using System;
using HouseProject.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HouseProject.Api.Migrations
{
    [DbContext(typeof(HouseProjectDbContext))]
    [Migration("20210917205542_change to nullable columns in application and preparation table")]
    partial class changetonullablecolumnsinapplicationandpreparationtable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HouseProject.Domain.Entities.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReceivedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SendAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("SendBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SendTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("SendTypeId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("PreparationId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReceivedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SendTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("PreparationId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SendTypeId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.LoanTranche", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoanTranches");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.Preparation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Advance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ExecutedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Payment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Supplier")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Preparations");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Payment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReceivedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Supplier")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.SendType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SendTypes");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.WorkStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkStages");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.Application", b =>
                {
                    b.HasOne("HouseProject.Domain.Entities.Post", "Post")
                        .WithMany("Applications")
                        .HasForeignKey("PostId");

                    b.HasOne("HouseProject.Domain.Entities.SendType", "SendType")
                        .WithMany("Applications")
                        .HasForeignKey("SendTypeId");

                    b.Navigation("Post");

                    b.Navigation("SendType");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.Attachment", b =>
                {
                    b.HasOne("HouseProject.Domain.Entities.Application", "Application")
                        .WithMany("Attachments")
                        .HasForeignKey("ApplicationId");

                    b.Navigation("Application");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.Document", b =>
                {
                    b.HasOne("HouseProject.Domain.Entities.Post", "Post")
                        .WithMany("Documents")
                        .HasForeignKey("PostId");

                    b.HasOne("HouseProject.Domain.Entities.Preparation", "Preparation")
                        .WithMany("Documents")
                        .HasForeignKey("PreparationId");

                    b.HasOne("HouseProject.Domain.Entities.Project", "Project")
                        .WithMany("Documents")
                        .HasForeignKey("ProjectId");

                    b.HasOne("HouseProject.Domain.Entities.SendType", "SendType")
                        .WithMany("Documents")
                        .HasForeignKey("SendTypeId");

                    b.Navigation("Post");

                    b.Navigation("Preparation");

                    b.Navigation("Project");

                    b.Navigation("SendType");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.Application", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.Post", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Documents");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.Preparation", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.Project", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("HouseProject.Domain.Entities.SendType", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}