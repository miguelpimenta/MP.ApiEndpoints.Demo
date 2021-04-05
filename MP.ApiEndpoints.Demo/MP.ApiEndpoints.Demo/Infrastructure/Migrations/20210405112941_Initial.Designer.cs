﻿// <auto-generated />
using System;
using MP.ApiEndpoints.Demo.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MP.ApiEndpoints.Demo.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210405112941_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("MP.ApiEndpoints.Demo.Core.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<long>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Persons", "dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("688a4bab-15a2-4159-bdf8-83cd551995ba"),
                            BirthDate = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"),
                            Name = "Test Person 01",
                            UpdatedAt = new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"),
                            Version = 1L
                        },
                        new
                        {
                            Id = new Guid("aadf65a8-d14d-4f87-b25a-cc0b7741db60"),
                            BirthDate = new DateTime(1985, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"),
                            Name = "Test Person 02",
                            UpdatedAt = new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"),
                            Version = 1L
                        },
                        new
                        {
                            Id = new Guid("8befcb97-6cdf-4a40-9511-9197ba715379"),
                            BirthDate = new DateTime(1990, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"),
                            Name = "Test Person 02",
                            UpdatedAt = new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"),
                            Version = 1L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
