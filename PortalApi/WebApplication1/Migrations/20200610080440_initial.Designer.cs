﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Database;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(PortalContext))]
    [Migration("20200610080440_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.About", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Tekst");

                    b.HasKey("Id");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("WebApplication1.Models.Attachment", b =>
                {
                    b.Property<Guid>("AttachmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AboutId");

                    b.Property<string>("AttachmentFileName");

                    b.Property<string>("AttachmentFileReference");

                    b.Property<Guid?>("LiteratureId");

                    b.Property<Guid?>("MessageId");

                    b.HasKey("AttachmentId");

                    b.HasIndex("AboutId");

                    b.HasIndex("LiteratureId");

                    b.HasIndex("MessageId");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("WebApplication1.Models.Comment", b =>
                {
                    b.Property<Guid>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CurrentDateTime");

                    b.Property<string>("Email");

                    b.Property<int?>("MessageId");

                    b.Property<Guid?>("MessageId1");

                    b.Property<string>("TextComment");

                    b.HasKey("CommentId");

                    b.HasIndex("MessageId1");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("WebApplication1.Models.Documentation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Group");

                    b.Property<string>("Link");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("WebApplication1.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Department");

                    b.Property<string>("Email");

                    b.Property<Guid?>("EmployeePictureAttachmentId");

                    b.Property<DateTime>("EndOfWork");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<string>("Position");

                    b.Property<DateTime>("StartOfWork");

                    b.Property<string>("Telephone");

                    b.HasKey("Id");

                    b.HasIndex("EmployeePictureAttachmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebApplication1.Models.Literature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Group");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Link");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Literatures");
                });

            modelBuilder.Entity("WebApplication1.Models.Meetings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("WebApplication1.Models.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CurrentDate");

                    b.Property<string>("Email");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LikeCounter");

                    b.Property<string>("TextMessage");

                    b.HasKey("Id");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("WebApplication1.Models.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateNow");

                    b.Property<DateTime>("DateOfEvent");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("WebApplication1.Models.UserLike", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<bool>("Liked");

                    b.Property<Guid?>("MessageId");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("UserLike");
                });

            modelBuilder.Entity("WebApplication1.Models.Attachment", b =>
                {
                    b.HasOne("WebApplication1.Models.About")
                        .WithMany("Files")
                        .HasForeignKey("AboutId");

                    b.HasOne("WebApplication1.Models.Literature")
                        .WithMany("Files")
                        .HasForeignKey("LiteratureId");

                    b.HasOne("WebApplication1.Models.Message")
                        .WithMany("Attachments")
                        .HasForeignKey("MessageId");
                });

            modelBuilder.Entity("WebApplication1.Models.Comment", b =>
                {
                    b.HasOne("WebApplication1.Models.Message")
                        .WithMany("ListOfComments")
                        .HasForeignKey("MessageId1");
                });

            modelBuilder.Entity("WebApplication1.Models.Employee", b =>
                {
                    b.HasOne("WebApplication1.Models.Attachment", "EmployeePicture")
                        .WithMany()
                        .HasForeignKey("EmployeePictureAttachmentId");
                });

            modelBuilder.Entity("WebApplication1.Models.UserLike", b =>
                {
                    b.HasOne("WebApplication1.Models.Message")
                        .WithMany("UserLikeList")
                        .HasForeignKey("MessageId");
                });
#pragma warning restore 612, 618
        }
    }
}
