using Microsoft.EntityFrameworkCore;
using RevenueRecognitionSystem.Domain.Models.Client;
using RevenueRecognitionSystem.Domain.Models.SoftwareLicense;
using RevenueRecognitionSystem.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RevenueRecognitionSystem.Infrastructure
{
    public class ReveuneDbContext : DbContext
    {
        public ReveuneDbContext()
        {

        }
        public ReveuneDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<BaseClient> Clients { get; set; }
        public DbSet<CompanyClient> CompanyClients { get; set; }
        public DbSet<IndividualClient> IndividualClients { get; set; }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<SoftwareSystem> SoftwareSystems { get; set; }
        public DbSet<Update> Updates { get; set; }

        public DbSet<SubPayment> SubPayments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=local;Integrated Security=True;TrustServerCertificate=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BaseClient>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Adress).IsRequired();
                x.Property(x => x.Email).IsRequired();
                x.HasDiscriminator<string>("CustomerType")
                .HasValue<IndividualClient>("IndividualClient")
                .HasValue<CompanyClient>("CompanyClient");

            });

            modelBuilder.Entity<CompanyClient>(x =>
            {
                //x.HasKey(x => x.Id);
                x.Property(x => x.CompanyName).IsRequired();
                //x.Property(x => x.Adress).IsRequired();
                //x.Property(x => x.Email).IsRequired();
                x.Property(x => x.KRS).IsRequired();

                //x.HasData(new CompanyClient { Id = 1, Adress = "Warsaw", CompanyName = "IndiaInc", Email = "hehe@hehe.pl", KRS = 1234567 },
                //            new CompanyClient { Id = 2, Adress = "Warsaw", CompanyName = "HamerykaInc", Email = "Hameryka@hehe.pl", KRS = 7654321 });
            });
            modelBuilder.Entity<IndividualClient>(x =>
            {
                //x.HasKey(x => x.Id);
                x.Property(x => x.FirstName).IsRequired();
                x.Property(x => x.LastName).IsRequired();
                //x.Property(x => x.Adress).IsRequired();
                //x.Property(x => x.Email).IsRequired();
                x.Property(x => x.PhoneNumber).IsRequired();
                x.Property(x => x.PESEL).IsRequired();

                //x.HasData(
                //    new IndividualClient { Id = 3, FirstName = "Michał", LastName = "Kowalski", Adress = "Warsaw", Email = "michal@hehe.pl", PhoneNumber = "123456789", PESEL = 123456789, IsDeleted = false },
                //    new IndividualClient { Id = 4, FirstName = "Bartek", LastName = "KowalskiDuzy", Adress = "Warsaw", Email = "bartek@hehe.pl", PhoneNumber = "0987654321", PESEL = 123456789, IsDeleted = false },
                //    new IndividualClient { Id = 5, FirstName = "Franek", LastName = "KowalskiMaly", Adress = "Warsaw", Email = "franek@hehe.pl", PhoneNumber = "6478236471", PESEL = 123456789, IsDeleted = false }
                //);
            });

            modelBuilder.Entity<Contract>(x =>
            {
                x.HasKey(a => a.Id);
                x.HasOne(b => b.Client)
                .WithMany(c => c.Contracts)
                .HasForeignKey(d => d.IdClient);

                x.HasOne(e => e.SoftwareSystem)
                .WithMany(f => f.Contracts)
                .HasForeignKey(g => g.IdSoftware);
            });

            modelBuilder.Entity<Discount>(x =>
            {
                x.HasKey(x => x.Id);

                
            });

            modelBuilder.Entity<SoftwareSystem>(x =>
            {
                x.HasKey(x => x.Id);

            });
            modelBuilder.Entity<Update>(x =>
            {
                x.HasKey(x => x.Id);

                x.HasOne(a => a.SoftwareSystem)
                .WithMany(b => b.SoftwareUpdates)
                .HasForeignKey(c => c.IdSoftware);
            });

            modelBuilder.Entity<Subscription>(x =>
            {
                x.HasKey(a => a.Id);

                x.HasMany(b => b.SubPayments)
                .WithOne(c => c.Subscription)
                .HasForeignKey(d => d.IdSubscription);

                x.HasOne(e=>e.SoftwareSystem)
                .WithMany(f=>f.Subscriptions)
                .HasForeignKey(g=>g.IdSoftware);
            });

            modelBuilder.Entity<SubPayment>(x =>
            {
                x.HasKey(a => a.Id);

                x.HasOne(b => b.Subscription)
                .WithMany(c => c.SubPayments)
                .HasForeignKey(d => d.IdSubscription);
            });
        }
    }
}
