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

        public DbSet<User> UserEntries { get; set; }
        public DbSet<Donation> DonationEntries { get; set; }
        public DbSet<Event> EventEntries { get; set; }
        public DbSet<Book> BookEntries { get; set; }
        public DbSet<Comic> ComicEntries { get; set; }
        public DbSet<Animation> AnimationEntries { get; set; }
        public DbSet<Article> ArticleEntries { get; set; }
        public DbSet<UserBook> UserBookEntries { get; set; }
        public DbSet<UserComic> UserComicEntries { get; set; }
        public DbSet<UserAnimation> UserAnimationEntries { get; set; }
        public DbSet<UserArticle> UserArticleEntries { get; set; }
        public DbSet<Order> OrderEntries { get; set; }
        public DbSet<Product> ProductEntries { get; set; }
        public DbSet<ProductOrder> ProductOrderEntries { get; set; }
        public DbSet<Nation> NationEntries { get; set; }
        public DbSet<Membership> MembershipEntries { get; set; }
        public DbSet<Organisation> OrganisationEntries { get; set; }
        public DbSet<SpeedyCharacter> SpeedyCharacterEntries { get; set; }
        public DbSet<UserEvent> UserEventEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAnimation>()
                .HasOne(aw => aw.Animation)
                .WithMany(a => a.UserAnimations)
                .HasForeignKey(aw => aw.AnimationId);
            modelBuilder.Entity<UserAnimation>()
                .HasOne(aw => aw.User)
                .WithMany(a => a.UserAnimations)
                .HasForeignKey(aw => aw.UserId);

            modelBuilder.Entity<UserArticle>()
                .HasOne(ar => ar.Article)
                .WithMany(a => a.UserArticles)
                .HasForeignKey(ar => ar.ArticleId);
            modelBuilder.Entity<UserArticle>()
                .HasOne(ar => ar.User)
                .WithMany(a => a.UserArticles)
                .HasForeignKey(ar => ar.UserId);
            
            modelBuilder.Entity<UserBook>()
                .HasOne(br => br.Book)
                .WithMany(b => b.UserBooks)
                .HasForeignKey(br => br.BookId);
            modelBuilder.Entity<UserBook>()
                .HasOne(br => br.User)
                .WithMany(b => b.UserBooks)
                .HasForeignKey(br => br.UserId);
            
            modelBuilder.Entity<UserComic>()
                .HasOne(cr => cr.Comic)
                .WithMany(c => c.UserComics)
                .HasForeignKey(cr => cr.ComicId);
            modelBuilder.Entity<UserComic>()
                .HasOne(cr => cr.User)
                .WithMany(c => c.UserComics)
                .HasForeignKey(cr => cr.UserId);

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

            modelBuilder.Entity<Nation>()
            .HasMany(a => a.Articles)
            .WithOne(n => n.Nation);

            modelBuilder.Entity<Membership>()
            .HasMany(u => u.Users)
            .WithOne(m => m.Membership);

            modelBuilder.Entity<Organisation>()
            .HasMany(e => e.Events)
            .WithOne(o => o.Organisation);
            modelBuilder.Entity<Organisation>()
            .HasMany(d => d.Donations)
            .WithOne(o => o.Organisation);         
        }
    }
}

