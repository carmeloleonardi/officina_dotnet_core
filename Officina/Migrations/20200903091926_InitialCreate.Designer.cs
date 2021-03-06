﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Officina.Context;

namespace Officina.Migrations
{
    [DbContext(typeof(OfficinaContext))]
    [Migration("20200903091926_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Officina.Models.Car", b =>
                {
                    b.Property<long>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint");

                    b.Property<float>("Km")
                        .HasColumnType("real");

                    b.HasKey("CarId");

                    b.HasIndex("ClientId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Officina.Models.CertificateCar", b =>
                {
                    b.Property<long>("CertificateCarID")
                        .HasColumnType("bigint");

                    b.Property<long>("CarId")
                        .HasColumnType("bigint");

                    b.Property<string>("CarPlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChassisNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("EmptyMass")
                        .HasColumnType("real");

                    b.Property<float>("EngineDisplacement")
                        .HasColumnType("real");

                    b.Property<float>("Kw")
                        .HasColumnType("real");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CertificateCarID");

                    b.ToTable("CertificateCars");
                });

            modelBuilder.Entity("Officina.Models.Client", b =>
                {
                    b.Property<long>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("client_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("client");

                    b.HasDiscriminator<string>("client_type").HasValue("Client");
                });

            modelBuilder.Entity("Officina.Models.ClientDetail", b =>
                {
                    b.Property<long>("ClientDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientDetailId");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("client_detail");
                });

            modelBuilder.Entity("Officina.Models.Employement", b =>
                {
                    b.Property<long>("OperationId")
                        .HasColumnType("bigint");

                    b.Property<long>("WorkmanId")
                        .HasColumnType("bigint");

                    b.HasKey("OperationId", "WorkmanId");

                    b.HasIndex("WorkmanId");

                    b.ToTable("Employements");
                });

            modelBuilder.Entity("Officina.Models.Operation", b =>
                {
                    b.Property<long>("OperationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CarId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.HasKey("OperationId");

                    b.HasIndex("CarId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("Officina.Models.Piece", b =>
                {
                    b.Property<long>("PieceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PieceId");

                    b.ToTable("Piece");
                });

            modelBuilder.Entity("Officina.Models.PieceOperation", b =>
                {
                    b.Property<long>("OperationId")
                        .HasColumnType("bigint");

                    b.Property<long>("PieceId")
                        .HasColumnType("bigint");

                    b.HasKey("OperationId", "PieceId");

                    b.HasIndex("PieceId");

                    b.ToTable("PieceOperations");
                });

            modelBuilder.Entity("Officina.Models.Service", b =>
                {
                    b.Property<long>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Officina.Models.ServiceOperation", b =>
                {
                    b.Property<long>("OperationId")
                        .HasColumnType("bigint");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.HasKey("OperationId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceOperations");
                });

            modelBuilder.Entity("Officina.Models.Workman", b =>
                {
                    b.Property<long>("WorkmanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkmanId");

                    b.ToTable("Workmen");
                });

            modelBuilder.Entity("Officina.Models.ClientCompany", b =>
                {
                    b.HasBaseType("Officina.Models.Client");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VATNumber")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("client");

                    b.HasDiscriminator().HasValue("COMPANY");
                });

            modelBuilder.Entity("Officina.Models.PrivateClient", b =>
                {
                    b.HasBaseType("Officina.Models.Client");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FiscalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("client");

                    b.HasDiscriminator().HasValue("PRIVATE");
                });

            modelBuilder.Entity("Officina.Models.Car", b =>
                {
                    b.HasOne("Officina.Models.Client", "Client")
                        .WithMany("Cars")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Officina.Models.CertificateCar", b =>
                {
                    b.HasOne("Officina.Models.Car", "Car")
                        .WithOne("CertificateCar")
                        .HasForeignKey("Officina.Models.CertificateCar", "CertificateCarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Officina.Models.ClientDetail", b =>
                {
                    b.HasOne("Officina.Models.Client", "Client")
                        .WithOne("ClientDetail")
                        .HasForeignKey("Officina.Models.ClientDetail", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Officina.Models.Employement", b =>
                {
                    b.HasOne("Officina.Models.Operation", "Operation")
                        .WithMany("Employements")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Officina.Models.Workman", "Workman")
                        .WithMany("Employements")
                        .HasForeignKey("WorkmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Officina.Models.Operation", b =>
                {
                    b.HasOne("Officina.Models.Car", "Car")
                        .WithMany("Operations")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Officina.Models.PieceOperation", b =>
                {
                    b.HasOne("Officina.Models.Operation", "Operation")
                        .WithMany("PieceOperations")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Officina.Models.Piece", "Piece")
                        .WithMany("PieceOperations")
                        .HasForeignKey("PieceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Officina.Models.ServiceOperation", b =>
                {
                    b.HasOne("Officina.Models.Operation", "Operation")
                        .WithMany("ServiceOperations")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Officina.Models.Service", "Service")
                        .WithMany("ServiceOperations")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
