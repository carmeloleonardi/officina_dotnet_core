using Microsoft.EntityFrameworkCore;
using Officina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Officina.Context
{
    public class OfficinaContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<PrivateClient> PrivateClients { get; set; }
        public DbSet<ClientCompany> ClientCompanies { get; set; }
        public DbSet<ClientDetail> ClientDetails { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CertificateCar> CertificateCars { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<PieceOperation> PieceOperations { get; set; }
        public DbSet<Employement> Employements { get; set; }
        public DbSet<Workman> Workmen { get; set; }
        public DbSet<ServiceOperation> ServiceOperations { get; set; }
        public DbSet<Service> Services { get; set; }

        public OfficinaContext(DbContextOptions<OfficinaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasDiscriminator<string>("client_type")
                .HasValue<ClientCompany>("COMPANY")
                .HasValue<PrivateClient>("PRIVATE");

            modelBuilder.Entity<Client>()
                .HasOne(b => b.ClientDetail)
                .WithOne(b => b.Client)
                .HasForeignKey<ClientDetail>(b => b.ClientId);

            modelBuilder.Entity<Car>()
                .HasOne(b => b.Client)
                .WithMany(b => b.Cars);

            modelBuilder.Entity<Car>()
                .HasOne(b => b.CertificateCar)
                .WithOne(b => b.Car)
                .HasForeignKey<CertificateCar>(b => b.CarId);

            modelBuilder.Entity<Operation>()
                .HasOne(b => b.Car)
                .WithMany(b => b.Operations);

            modelBuilder.Entity<PieceOperation>()
                .HasKey(p => new { p.OperationId, p.PieceId });

            modelBuilder.Entity<PieceOperation>()
               .HasOne(b => b.Operation)
               .WithMany(b => b.PieceOperations)
               .HasForeignKey(b => b.OperationId);

            modelBuilder.Entity<PieceOperation>()
                .HasOne(b => b.Piece)
                .WithMany(b => b.PieceOperations)
                .HasForeignKey(p => p.PieceId);

            //--------------------------------------

            modelBuilder.Entity<Employement>()
                .HasKey(p => new { p.OperationId, p.WorkmanId });

            modelBuilder.Entity<Employement>()
               .HasOne(b => b.Operation)
               .WithMany(b => b.Employements)
               .HasForeignKey(p => p.OperationId);

            modelBuilder.Entity<Employement>()
               .HasOne(b => b.Workman)
               .WithMany(b => b.Employements)
               .HasForeignKey(b => b.WorkmanId);

            //--------------------------------------

            modelBuilder.Entity<ServiceOperation>()
                .HasKey(p => new { p.OperationId, p.ServiceId });

            modelBuilder.Entity<ServiceOperation>()
               .HasOne(b => b.Operation)
               .WithMany(b => b.ServiceOperations)
               .HasForeignKey(p => p.OperationId);

            modelBuilder.Entity<ServiceOperation>()
               .HasOne(b => b.Service)
               .WithMany(b => b.ServiceOperations)
               .HasForeignKey(b => b.ServiceId);

        }
    }
}
