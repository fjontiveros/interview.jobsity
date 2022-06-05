﻿// <auto-generated />
using System;
using Jobsity.Chatroom.WebApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jobsity.Chatroom.WebApi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220605210738_AddDataAnnotations")]
    partial class AddDataAnnotations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Jobsity.Chatroom.WebApi.Model.Chatroom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chatrooms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dc7c9c85-b4af-42f9-9646-c7c7ee0d7324"),
                            Created = new DateTime(2022, 6, 5, 18, 7, 38, 266, DateTimeKind.Local).AddTicks(2289),
                            Name = "Chatroom 1"
                        });
                });

            modelBuilder.Entity("Jobsity.Chatroom.WebApi.Model.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatroomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ChatroomId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Jobsity.Chatroom.WebApi.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b995314b-2c49-4b87-919b-58cbb5cd3f91"),
                            Name = "user1",
                            Password = "123456"
                        },
                        new
                        {
                            Id = new Guid("8b2294a2-454f-45ea-b064-d39d1fbdfac4"),
                            Name = "user2",
                            Password = "123456"
                        });
                });

            modelBuilder.Entity("Jobsity.Chatroom.WebApi.Model.Message", b =>
                {
                    b.HasOne("Jobsity.Chatroom.WebApi.Model.Chatroom", "Chatroom")
                        .WithMany("Messages")
                        .HasForeignKey("ChatroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jobsity.Chatroom.WebApi.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chatroom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Jobsity.Chatroom.WebApi.Model.Chatroom", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
