using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OmniSenseNetwork.GSP.DAL.Entities
{
    public partial class GSPEntities : DbContext
    {
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientSession> ClientSession { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientSession>(entity =>
            {
                entity.HasIndex(e => e.ClientId)
                    .HasName("FK_ClientSessionClientId_idx");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientSession)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientSession_ClientId");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasIndex(e => e.PartnerId)
                    .HasName("FK_ServicePartnerId_idx");

                entity.HasIndex(e => e.Type)
                    .HasName("FK_ServiceType_idx");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePartnerId");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceType");
            });
        }
    }
}
