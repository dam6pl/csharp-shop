﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopDN.Data.Models;

namespace ShopDN.Data.Migrations
{
    [DbContext(typeof(ShopDNContext))]
    [Migration("20190706151754_v12")]
    partial class v12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopDN.Data.Models.CMS.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired();

                    b.Property<bool>("IsDraft");

                    b.Property<DateTime>("PublishDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("ShopDN.Data.Models.Shop.CartElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Count");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("ProductId");

                    b.Property<string>("SessionId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("CartElement");
                });

            modelBuilder.Entity("ShopDN.Data.Models.Shop.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdParentCategory");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("IdParentCategory");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ShopDN.Data.Models.Shop.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<decimal>("Sum");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ShopDN.Data.Models.Shop.OrderElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Count");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderElement");
                });

            modelBuilder.Entity("ShopDN.Data.Models.Shop.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCategory");

                    b.Property<string>("ImageURL")
                        .IsRequired();

                    b.Property<bool>("IsFeatured");

                    b.Property<decimal>("Price");

                    b.Property<decimal?>("PriceAudiobook")
                        .IsRequired();

                    b.Property<decimal?>("PriceEBook")
                        .IsRequired();

                    b.Property<int>("Rating");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("IdCategory");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ShopDN.Data.Models.Shop.CartElement", b =>
                {
                    b.HasOne("ShopDN.Data.Models.Shop.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopDN.Data.Models.Shop.Category", b =>
                {
                    b.HasOne("ShopDN.Data.Models.Shop.Category", "ParentCategory")
                        .WithMany("Categories")
                        .HasForeignKey("IdParentCategory");
                });

            modelBuilder.Entity("ShopDN.Data.Models.Shop.OrderElement", b =>
                {
                    b.HasOne("ShopDN.Data.Models.Shop.Order", "Order")
                        .WithMany("OrderElements")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopDN.Data.Models.Shop.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopDN.Data.Models.Shop.Product", b =>
                {
                    b.HasOne("ShopDN.Data.Models.Shop.Category", "Category")
                        .WithMany()
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}