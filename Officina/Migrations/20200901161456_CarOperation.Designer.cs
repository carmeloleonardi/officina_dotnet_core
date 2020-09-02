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
    [Migration("20200901161456_CarOperation")]
    partial class CarOperation
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
                    b.Property<string>("CarId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ClientId")
                        .HasColumnType("bigint");

                    b.Property<float>("Km")
                        .HasColumnType("real");

                    b.HasKey("CarId");

                    b.HasIndex("ClientId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Officina.Models.CertificateCar", b =>
                {
                    b.Property<string>("CertificateCarId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarId")
                        .HasColumnType("nvarchar(450)");

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

                    b.HasKey("CertificateCarId");

                    b.HasIndex("CarId")
                        .IsUnique()
                        .HasFilter("[CarId] IS NOT NULL");

                    b.ToTable("CertificateCar");
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

            modelBuilder.Entity("Officina.Models.Operation", b =>
                {
                    b.Property<long>("OperationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.HasKey("OperationId");

                    b.HasIndex("CarId");

                    b.ToTable("Operation");
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
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("Officina.Models.CertificateCar", b =>
                {
                    b.HasOne("Officina.Models.Car", "Car")
                        .WithOne("CertificateCar")
                        .HasForeignKey("Officina.Models.CertificateCar", "CarId");
                });

            modelBuilder.Entity("Officina.Models.ClientDetail", b =>
                {
                    b.HasOne("Officina.Models.Client", "Client")
                        .WithOne("ClientDetail")
                        .HasForeignKey("Officina.Models.ClientDetail", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Officina.Models.Operation", b =>
                {
                    b.HasOne("Officina.Models.Car", "Car")
                        .WithMany("Operations")
                        .HasForeignKey("CarId");
                });
#pragma warning restore 612, 618
        }
    }
}
