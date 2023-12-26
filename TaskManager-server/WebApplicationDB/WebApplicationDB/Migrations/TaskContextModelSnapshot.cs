﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationDB.Data;

#nullable disable

namespace WebApplicationDB.Migrations
{
    [DbContext(typeof(TaskContext))]
    partial class TaskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplicationDB.Models.Entity.TaskDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaskEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskEntityId");

                    b.ToTable("TaskDates");
                });

            modelBuilder.Entity("WebApplicationDB.Models.Entity.TaskEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRepeated")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskType");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("WebApplicationDB.Models.Entity.TaskTypeTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaskTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Personal"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Study"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Work"
                        });
                });

            modelBuilder.Entity("WebApplicationDB.Models.Entity.TaskDate", b =>
                {
                    b.HasOne("WebApplicationDB.Models.Entity.TaskEntity", "Task")
                        .WithMany("StartDates")
                        .HasForeignKey("TaskEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("WebApplicationDB.Models.Entity.TaskEntity", b =>
                {
                    b.HasOne("WebApplicationDB.Models.Entity.TaskTypeTable", "TaskTypeTable")
                        .WithMany("TaskEntities")
                        .HasForeignKey("TaskType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskTypeTable");
                });

            modelBuilder.Entity("WebApplicationDB.Models.Entity.TaskEntity", b =>
                {
                    b.Navigation("StartDates");
                });

            modelBuilder.Entity("WebApplicationDB.Models.Entity.TaskTypeTable", b =>
                {
                    b.Navigation("TaskEntities");
                });
#pragma warning restore 612, 618
        }
    }
}