﻿// <auto-generated />
using System;
using Fermaloc.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fermaloc.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240601155447_AddPropClickInEquipamentEntity")]
    partial class AddPropClickInEquipamentEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Fermaloc.Domain.Administrator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("Fermaloc.Domain.Banner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AdministratorId")
                        .HasColumnType("char(36)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasMaxLength(5242880)
                        .HasColumnType("LONGBLOB");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("Fermaloc.Domain.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AdministratorId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Fermaloc.Domain.Equipament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AdministratorId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<int>("EquipamentCode")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasMaxLength(5242880)
                        .HasColumnType("LONGBLOB");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<long>("NumberOfClicks")
                        .HasColumnType("BIGINT");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Equipaments");
                });

            modelBuilder.Entity("Fermaloc.Domain.EquipamentClicks", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("DATE");

                    b.Property<Guid>("EquipamentId")
                        .HasColumnType("char(36)");

                    b.Property<int>("NumberOfClicks")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("EquipamentId");

                    b.ToTable("EquipamentClicks");
                });

            modelBuilder.Entity("Fermaloc.Domain.Banner", b =>
                {
                    b.HasOne("Fermaloc.Domain.Administrator", "Administrator")
                        .WithMany("Banners")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("Fermaloc.Domain.Category", b =>
                {
                    b.HasOne("Fermaloc.Domain.Administrator", "Administrator")
                        .WithMany("Categories")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("Fermaloc.Domain.Equipament", b =>
                {
                    b.HasOne("Fermaloc.Domain.Administrator", "Administrator")
                        .WithMany("Equipaments")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fermaloc.Domain.Category", "Category")
                        .WithMany("Equipaments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Fermaloc.Domain.EquipamentClicks", b =>
                {
                    b.HasOne("Fermaloc.Domain.Equipament", "Equipament")
                        .WithMany("EquipamentsClicks")
                        .HasForeignKey("EquipamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipament");
                });

            modelBuilder.Entity("Fermaloc.Domain.Administrator", b =>
                {
                    b.Navigation("Banners");

                    b.Navigation("Categories");

                    b.Navigation("Equipaments");
                });

            modelBuilder.Entity("Fermaloc.Domain.Category", b =>
                {
                    b.Navigation("Equipaments");
                });

            modelBuilder.Entity("Fermaloc.Domain.Equipament", b =>
                {
                    b.Navigation("EquipamentsClicks");
                });
#pragma warning restore 612, 618
        }
    }
}
