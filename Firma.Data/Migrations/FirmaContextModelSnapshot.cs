﻿// <auto-generated />
using Firma.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Firma.Data.Migrations
{
    [DbContext(typeof(FirmaContext))]
    partial class FirmaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Firma.Data.CMS.Aktualnosc", b =>
                {
                    b.Property<int>("IdAktualnosc")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LinkTytul")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Pozycja");

                    b.Property<string>("Tresc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("IdAktualnosc");

                    b.ToTable("Aktualnosc");
                });

            modelBuilder.Entity("Firma.Data.CMS.Strona", b =>
                {
                    b.Property<int>("IdStrony")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LinkTytul")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Pozycja");

                    b.Property<string>("Tresc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("IdStrony");

                    b.ToTable("Strona");
                });

            modelBuilder.Entity("Firma.Data.Sklep.Rodzaj", b =>
                {
                    b.Property<int>("IdRodzaju")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRodzaju");

                    b.ToTable("Rodzaj");
                });

            modelBuilder.Entity("Firma.Data.Sklep.Towar", b =>
                {
                    b.Property<int>("IdTowaru")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cena")
                        .HasColumnType("money");

                    b.Property<int>("IdRodzaju");

                    b.Property<string>("Kod")
                        .IsRequired();

                    b.Property<string>("Nazwa")
                        .IsRequired();

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Promocja");

                    b.Property<string>("ZdjecieUrl")
                        .IsRequired();

                    b.HasKey("IdTowaru");

                    b.HasIndex("IdRodzaju");

                    b.ToTable("Towar");
                });

            modelBuilder.Entity("Firma.Data.Sklep.Towar", b =>
                {
                    b.HasOne("Firma.Data.Sklep.Rodzaj", "Rodzaj")
                        .WithMany("Towar")
                        .HasForeignKey("IdRodzaju")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
