﻿// <auto-generated />
using System;
using Elsa.Secrets.Persistence.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Elsa.Secrets.Persistence.EntityFrameworkCore.SqlServer.Migrations
{
    [DbContext(typeof(SecretsDbContext))]
    partial class SecretsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Elsa")
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Elsa.Secrets.Management.Secret", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EncryptedValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ExpiresAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<TimeSpan?>("ExpiresIn")
                        .HasColumnType("time");

                    b.Property<bool>("IsLatest")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LastAccessedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scope")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SecretId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpiresAt")
                        .HasDatabaseName("IX_Secret_ExpiresAt");

                    b.HasIndex("LastAccessedAt")
                        .HasDatabaseName("IX_Secret_LastAccessedAt");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Secret_Name");

                    b.HasIndex("Scope")
                        .HasDatabaseName("IX_Secret_Scope");

                    b.HasIndex("Status")
                        .HasDatabaseName("IX_Secret_Status");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("IX_Secret_TenantId");

                    b.HasIndex("Version")
                        .HasDatabaseName("IX_Secret_Version");

                    b.ToTable("Secrets", "Elsa");
                });
#pragma warning restore 612, 618
        }
    }
}