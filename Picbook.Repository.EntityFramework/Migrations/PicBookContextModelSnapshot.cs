﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Picbook.Repository.EntityFramework.Entities;
using System;

namespace Picbook.Repository.EntityFramework.Migrations
{
    [DbContext(typeof(PicBookContext))]
    partial class PicBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Picbook.Repository.EntityFramework.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<string>("MobilNumber")
                        .HasMaxLength(21)
                        .IsUnicode(false);

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("ProfileImageUrl")
                        .HasMaxLength(1024);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(24)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Picbook.Repository.EntityFramework.Entities.Album", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId")
                        .HasColumnName("AccountID");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description")
                        .HasColumnType("ntext");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Picbook.Repository.EntityFramework.Entities.Image", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("AlbumId");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool>("Deleted");

                    b.Property<int?>("Height");

                    b.Property<string>("MobileSizeUrl")
                        .HasColumnName("MobileSizeURL")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512);

                    b.Property<string>("OriginalSizeUrl")
                        .IsRequired()
                        .HasColumnName("OriginalSizeURL")
                        .HasMaxLength(1024);

                    b.Property<bool>("Public");

                    b.Property<string>("WebSizeUrl")
                        .HasColumnName("WebSizeURL")
                        .HasMaxLength(1024);

                    b.Property<int?>("Width");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Picbook.Repository.EntityFramework.Entities.Rating", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool>("Deleted");

                    b.Property<long>("ImageId");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ImageId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("Picbook.Repository.EntityFramework.Entities.Album", b =>
                {
                    b.HasOne("Picbook.Repository.EntityFramework.Entities.Account", "Account")
                        .WithMany("Album")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_Album_Account");
                });

            modelBuilder.Entity("Picbook.Repository.EntityFramework.Entities.Image", b =>
                {
                    b.HasOne("Picbook.Repository.EntityFramework.Entities.Album", "Album")
                        .WithMany("Image")
                        .HasForeignKey("AlbumId")
                        .HasConstraintName("FK_Image_Album");
                });

            modelBuilder.Entity("Picbook.Repository.EntityFramework.Entities.Rating", b =>
                {
                    b.HasOne("Picbook.Repository.EntityFramework.Entities.Account", "Account")
                        .WithMany("Rating")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_Rating_Account");

                    b.HasOne("Picbook.Repository.EntityFramework.Entities.Image", "Image")
                        .WithMany("Rating")
                        .HasForeignKey("ImageId")
                        .HasConstraintName("FK_Rating_Image");
                });
#pragma warning restore 612, 618
        }
    }
}
