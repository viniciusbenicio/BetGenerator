﻿// <auto-generated />
using System;
using GeradorDeApostas.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeradorDeApostas.Migrations
{
    [DbContext(typeof(ApostasDBContext))]
    [Migration("20231122223444_Relacionamento de varios resultado com uma bet")]
    partial class Relacionamentodevariosresultadocomumabet
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GeradorDeApostas.Models.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Error")
                        .HasColumnType("bit")
                        .HasColumnName("Error");

                    b.Property<int>("NumberOfGames")
                        .HasColumnType("INTEGER")
                        .HasColumnName("NumberOfGames");

                    b.Property<int>("TotalNumbers")
                        .HasColumnType("INTEGER")
                        .HasColumnName("TotalNumbers");

                    b.HasKey("Id");

                    b.ToTable("Bet", (string)null);
                });

            modelBuilder.Entity("GeradorDeApostas.Models.BetResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BetId")
                        .HasColumnType("int");

                    b.Property<int?>("IdBet")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BetId");

                    b.ToTable("BetResult");
                });

            modelBuilder.Entity("GeradorDeApostas.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("GeradorDeApostas.Models.BetResult", b =>
                {
                    b.HasOne("GeradorDeApostas.Models.Bet", "Bet")
                        .WithMany("BetResults")
                        .HasForeignKey("BetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bet");
                });

            modelBuilder.Entity("GeradorDeApostas.Models.Bet", b =>
                {
                    b.Navigation("BetResults");
                });
#pragma warning restore 612, 618
        }
    }
}