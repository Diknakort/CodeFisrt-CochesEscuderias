﻿// <auto-generated />
using CodeFisrt_CochesEscuderias.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeFisrt_CochesEscuderias.Migrations
{
    [DbContext(typeof(CircuitosContexto))]
    [Migration("20240606101422_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodeFisrt_CochesEscuderias.Models.Coche", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EscuderiaId")
                        .HasColumnType("int");

                    b.Property<int>("Motor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EscuderiaId");

                    b.ToTable("Coches");
                });

            modelBuilder.Entity("CodeFisrt_CochesEscuderias.Models.Escuderia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Dinero")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Escuderias");
                });

            modelBuilder.Entity("CodeFisrt_CochesEscuderias.Models.Coche", b =>
                {
                    b.HasOne("CodeFisrt_CochesEscuderias.Models.Escuderia", null)
                        .WithMany("Coches")
                        .HasForeignKey("EscuderiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeFisrt_CochesEscuderias.Models.Escuderia", b =>
                {
                    b.Navigation("Coches");
                });
#pragma warning restore 612, 618
        }
    }
}
