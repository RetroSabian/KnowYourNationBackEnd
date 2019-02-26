﻿// <auto-generated />
using System;
using Know_Your_Nation_Speedy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Know_Your_Nation_Speedy.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20190226091438_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.BaseProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverImageLocation");

                    b.Property<string>("Description");

                    b.Property<bool>("IsAlive");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("BaseProductEntries");
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Association");

                    b.Property<string>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("FileLocation");

                    b.Property<string>("ImageLocation");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ContentEntries");
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.Donation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DonatationAmount");

                    b.Property<DateTime>("DonationDate");

                    b.Property<int>("OrganisationId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId");

                    b.HasIndex("UserId");

                    b.ToTable("DonationEntries");
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<bool>("IsAlive");

                    b.Property<string>("Name");

                    b.Property<int>("OrganisationId");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Street");

                    b.Property<string>("Suburb");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId");

                    b.ToTable("EventEntries");
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.Membership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AllowAnimation");

                    b.Property<bool>("AllowArticle");

                    b.Property<bool>("AllowBook");

                    b.Property<bool>("AllowComic");

                    b.Property<string>("Description");

                    b.Property<int>("Duration");

                    b.Property<bool>("IsAlive");

                    b.Property<double>("Price");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("MembershipEntries");
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateExpected");

                    b.Property<DateTime>("DateOrdered");

                    b.Property<string>("DeliveryCity");

                    b.Property<string>("DeliveryCountry");

                    b.Property<string>("DeliveryPostalCode");

                    b.Property<string>("DeliveryStreet");

                    b.Property<string>("DeliverySuburb");

                    b.Property<bool>("IsBusiness");

                    b.Property<string>("OrderStatus");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("OrderEntries");
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("URL");

                    b.HasKey("Id");

                    b.ToTable("OrganisationEntries");
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseProductId");

                    b.Property<string>("Colour");

                    b.Property<string>("Size");

                    b.HasKey("Id");

                    b.HasIndex("BaseProductId");

                    b.ToTable("ProductEntries");
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.ProductOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOrderEntries");
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.SpeedyCharacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SpeedyCharacterEntries");
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<DateTime>("MembershipExpiration");

                    b.Property<int>("MembershipId");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Surname");

                    b.Property<string>("UserOrganisation");

                    b.HasKey("Id");

                    b.HasIndex("MembershipId");

                    b.ToTable("UserEntries");
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.UserBookmark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Bookmark");

                    b.Property<int>("ContentId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBookmarkEntries");
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.UserEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("UserEventEntries");
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.UserRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContentId");

                    b.Property<int?>("Rating");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRatingEntries");
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.Donation", b =>
                {
                    b.HasOne("Know_Your_Nation_Speedy.Models.Organisation", "Organisation")
                        .WithMany("Donations")
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Know_Your_Nation_Speedy.Models.User", "User")
                        .WithMany("Donations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.Event", b =>
                {
                    b.HasOne("Know_Your_Nation_Speedy.Models.Organisation", "Organisation")
                        .WithMany("Events")
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.Order", b =>
                {
                    b.HasOne("Know_Your_Nation_Speedy.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.Product", b =>
                {
                    b.HasOne("Know_Your_Nation_Speedy.Models.BaseProduct", "BaseProduct")
                        .WithMany("Products")
                        .HasForeignKey("BaseProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.ProductOrder", b =>
                {
                    b.HasOne("Know_Your_Nation_Speedy.Models.Order", "Order")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Know_Your_Nation_Speedy.Models.Product", "Product")
                        .WithMany("ProductOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.User", b =>
                {
                    b.HasOne("Know_Your_Nation_Speedy.Models.Membership", "Membership")
                        .WithMany("Users")
                        .HasForeignKey("MembershipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.UserBookmark", b =>
                {
                    b.HasOne("Know_Your_Nation_Speedy.Models.Content", "Content")
                        .WithMany("UserBookmark")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Know_Your_Nation_Speedy.Models.User", "User")
                        .WithMany("UserBookmark")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.UserEvent", b =>
                {
                    b.HasOne("Know_Your_Nation_Speedy.Models.Event", "Event")
                        .WithMany("UserEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Know_Your_Nation_Speedy.Models.User", "User")
                        .WithMany("UserEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Know_Your_Nation_Speedy.Models.UserRating", b =>
                {
                    b.HasOne("Know_Your_Nation_Speedy.Models.Content", "Content")
                        .WithMany("UserRating")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Know_Your_Nation_Speedy.Models.User", "User")
                        .WithMany("UserRating")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}