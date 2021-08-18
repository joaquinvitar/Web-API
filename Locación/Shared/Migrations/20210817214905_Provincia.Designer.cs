﻿// <auto-generated />
using Locación.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Locación.Shared.Migrations
{
    [DbContext(typeof(dataContext))]
    [Migration("20210817214905_Provincia")]
    partial class Provincia
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Locación.Shared.Data.Entidades.País", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PaísCódigo")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("PaísNombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "PaísCódigo" }, "UQ_País_PaísCódigo")
                        .IsUnique();

                    b.ToTable("Países");
                });

            modelBuilder.Entity("Locación.Shared.Data.Entidades.Provincia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PaísID")
                        .HasColumnType("int");

                    b.Property<string>("ProvCódigo")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("ProvNombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("PaísID");

                    b.HasIndex(new[] { "ProvCódigo" }, "UQ_País_ProvCódigo")
                        .IsUnique();

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("Locación.Shared.Data.Entidades.Provincia", b =>
                {
                    b.HasOne("Locación.Shared.Data.Entidades.País", "País")
                        .WithMany("Provincias")
                        .HasForeignKey("PaísID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("País");
                });

            modelBuilder.Entity("Locación.Shared.Data.Entidades.País", b =>
                {
                    b.Navigation("Provincias");
                });
#pragma warning restore 612, 618
        }
    }
}
