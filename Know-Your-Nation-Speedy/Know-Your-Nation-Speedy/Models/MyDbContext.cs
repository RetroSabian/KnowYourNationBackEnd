using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Know_Your_Nation_Speedy.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        { }

        public DbSet<Content> ContentEntries { get; set; }
        public DbSet<UserContent> UserContentEntries { get; set; }
        public DbSet<User> UserEntries { get; set; }
        public DbSet<Donation> DonationEntries { get; set; }
        public DbSet<Event> EventEntries { get; set; }
        public DbSet<Order> OrderEntries { get; set; }
        public DbSet<Product> ProductEntries { get; set; }
        public DbSet<ProductOrder> ProductOrderEntries { get; set; }
        public DbSet<Membership> MembershipEntries { get; set; }
        public DbSet<Organisation> OrganisationEntries { get; set; }
        public DbSet<SpeedyCharacter> SpeedyCharacterEntries { get; set; }
        public DbSet<UserEvent> UserEventEntries { get; set; }
        public DbSet<BaseProduct> BaseProductEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserContent>()
                .HasOne(c => c.Content)
                .WithMany(a => a.UserContent)
                .HasForeignKey(aw => aw.ContentId);
            modelBuilder.Entity<UserContent>()
                .HasOne(aw => aw.User)
                .WithMany(c => c.UserContent)
                .HasForeignKey(aw => aw.UserId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(po => po.ProductId);
            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Order)
                .WithMany(o => o.ProductOrders)
                .HasForeignKey(po => po.OrderId);

            modelBuilder.Entity<UserEvent>()
                .HasOne(ue => ue.Event)
                .WithMany(u => u.UserEvents)
                .HasForeignKey(ue => ue.EventId);
            modelBuilder.Entity<UserEvent>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserEvents)
                .HasForeignKey(ue => ue.UserId);

            modelBuilder.Entity<User>()
           .HasMany(c => c.Orders)
           .WithOne(e => e.User);

            modelBuilder.Entity<User>()
           .HasMany(c => c.Donations)
           .WithOne(e => e.User);

            modelBuilder.Entity<Membership>()
            .HasMany(u => u.Users)
            .WithOne(m => m.Membership);

            modelBuilder.Entity<Organisation>()
            .HasMany(e => e.Events)
            .WithOne(o => o.Organisation);
            modelBuilder.Entity<Organisation>()
            .HasMany(d => d.Donations)
            .WithOne(o => o.Organisation);

            modelBuilder.Entity<BaseProduct>()
            .HasMany(p => p.Products)
            .WithOne(b => b.BaseProduct);
         }
    }
}

