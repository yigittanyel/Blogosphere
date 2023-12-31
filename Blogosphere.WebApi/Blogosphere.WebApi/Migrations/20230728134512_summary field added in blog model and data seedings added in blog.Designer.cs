﻿// <auto-generated />
using System;
using Blogosphere.WebApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blogosphere.WebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230728134512_summary field added in blog model and data seedings added in blog")]
    partial class summaryfieldaddedinblogmodelanddataseedingsaddedinblog
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Blogosphere.WebApi.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LargeImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmallImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Blog 1 Description",
                            LargeImageUrl = "https://via.placeholder.com/350",
                            SmallImageUrl = "https://via.placeholder.com/150",
                            Summary = "summary",
                            Title = "Blog 1",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "Blog 2 Description",
                            LargeImageUrl = "https://via.placeholder.com/350",
                            SmallImageUrl = "https://via.placeholder.com/150",
                            Summary = "summary",
                            Title = "Blog 2",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Content = "Blog 3 Description",
                            LargeImageUrl = "https://via.placeholder.com/350",
                            SmallImageUrl = "https://via.placeholder.com/150",
                            Summary = "summary",
                            Title = "Blog 3",
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            Content = "Blog 4 Description",
                            LargeImageUrl = "https://via.placeholder.com/350",
                            SmallImageUrl = "https://via.placeholder.com/150",
                            Summary = "summary",
                            Title = "Blog 4",
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            Content = "Blog 5 Description",
                            LargeImageUrl = "https://via.placeholder.com/350",
                            SmallImageUrl = "https://via.placeholder.com/150",
                            Summary = "summary",
                            Title = "Blog 5",
                            UserId = 3
                        },
                        new
                        {
                            Id = 6,
                            Content = "Blog 6 Description",
                            LargeImageUrl = "https://via.placeholder.com/350",
                            SmallImageUrl = "https://via.placeholder.com/150",
                            Summary = "summary",
                            Title = "Blog 6",
                            UserId = 3
                        },
                        new
                        {
                            Id = 7,
                            Content = "Blog 7 Description",
                            LargeImageUrl = "https://via.placeholder.com/350",
                            SmallImageUrl = "https://via.placeholder.com/150",
                            Summary = "summary",
                            Title = "Blog 7",
                            UserId = 4
                        },
                        new
                        {
                            Id = 8,
                            Content = "Blog 8 Description",
                            LargeImageUrl = "https://via.placeholder.com/350",
                            SmallImageUrl = "https://via.placeholder.com/150",
                            Summary = "summary",
                            Title = "Blog 8",
                            UserId = 4
                        },
                        new
                        {
                            Id = 9,
                            Content = "Blog 9 Description",
                            LargeImageUrl = "https://via.placeholder.com/350",
                            SmallImageUrl = "https://via.placeholder.com/150",
                            Summary = "summary",
                            Title = "Blog 9",
                            UserId = 5
                        },
                        new
                        {
                            Id = 10,
                            Content = "Blog 10 Description",
                            LargeImageUrl = "https://via.placeholder.com/350",
                            SmallImageUrl = "https://via.placeholder.com/150",
                            Summary = "summary",
                            Title = "Blog 10",
                            UserId = 5
                        });
                });

            modelBuilder.Entity("Blogosphere.WebApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Admin",
                            LastName = "Admin",
                            Password = "admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "User",
                            LastName = "User",
                            Password = "user",
                            Username = "user"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "User2",
                            LastName = "User2",
                            Password = "user2",
                            Username = "user2"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "User3",
                            LastName = "User3",
                            Password = "user3",
                            Username = "user3"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "User4",
                            LastName = "User4",
                            Password = "user4",
                            Username = "user4"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "User5",
                            LastName = "User5",
                            Password = "user5",
                            Username = "user5"
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "User6",
                            LastName = "User6",
                            Password = "user6",
                            Username = "user6"
                        });
                });

            modelBuilder.Entity("Blogosphere.WebApi.Models.Blog", b =>
                {
                    b.HasOne("Blogosphere.WebApi.Models.User", "User")
                        .WithMany("Blogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Blogosphere.WebApi.Models.User", b =>
                {
                    b.Navigation("Blogs");
                });
#pragma warning restore 612, 618
        }
    }
}
