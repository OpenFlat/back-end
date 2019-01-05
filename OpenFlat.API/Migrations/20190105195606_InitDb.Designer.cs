﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OpenFlat.API.Model;

namespace OpenFlat.API.Migrations
{
    [DbContext(typeof(FlatContext))]
    [Migration("20190105195606_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("OpenFlat.API.Models.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("ROLES");
                });

            modelBuilder.Entity("OpenFlat.API.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnName("BIRTH_DATE");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(100);

                    b.Property<int?>("Gender")
                        .HasColumnName("GENDER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(60);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("PASSWORD")
                        .HasMaxLength(60);

                    b.Property<string>("PhoneHome")
                        .HasColumnName("PHONE_HOME")
                        .HasMaxLength(10);

                    b.Property<string>("PhoneMobile")
                        .HasColumnName("PHONE_MOBILE")
                        .HasMaxLength(10);

                    b.Property<string>("PhoneOffice")
                        .HasColumnName("PHONE_OFFICE")
                        .HasMaxLength(10);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnName("SURNAME")
                        .HasMaxLength(60);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("USER_NAME")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("OpenFlat.API.Models.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int>("RoleId")
                        .HasColumnName("ROLE_ID");

                    b.Property<int>("UserId")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("USER_ROLES");
                });

            modelBuilder.Entity("OpenFlat.API.Models.Entities.UserRole", b =>
                {
                    b.HasOne("OpenFlat.API.Models.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OpenFlat.API.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}