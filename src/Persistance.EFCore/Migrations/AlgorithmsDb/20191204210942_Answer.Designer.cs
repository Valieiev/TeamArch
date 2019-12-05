﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.EFCore;

namespace Persistence.EFСore.Migrations.AlgorithmsDb
{
    [DbContext(typeof(AlgorithmsDbContext))]
    [Migration("20191204210942_Answer")]
    partial class Answer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Persistence.EFСore.CodePart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserTaskId");

                    b.ToTable("CodeParts");
                });

            modelBuilder.Entity("Persistence.EFСore.Diagramm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserTaskId")
                        .IsUnique();

                    b.ToTable("Diagramms");
                });

            modelBuilder.Entity("Persistence.EFСore.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserTaskId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Persistence.EFСore.UserTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserTasks");
                });

            modelBuilder.Entity("Persistence.EFСore.CodePart", b =>
                {
                    b.HasOne("Persistence.EFСore.UserTask", "UserTask")
                        .WithMany("CodeParts")
                        .HasForeignKey("UserTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Persistence.EFСore.Diagramm", b =>
                {
                    b.HasOne("Persistence.EFСore.UserTask", "UserTask")
                        .WithOne("diagramm")
                        .HasForeignKey("Persistence.EFСore.Diagramm", "UserTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Persistence.EFСore.Question", b =>
                {
                    b.HasOne("Persistence.EFСore.UserTask", "UserTask")
                        .WithMany("Questions")
                        .HasForeignKey("UserTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
