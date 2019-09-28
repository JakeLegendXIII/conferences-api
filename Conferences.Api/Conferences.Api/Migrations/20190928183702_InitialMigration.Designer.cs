﻿// <auto-generated />
using System;
using Conferences.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Conferences.Api.Migrations
{
    [DbContext(typeof(ConferenceDataContext))]
    [Migration("20190928183702_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Conferences.Api.Domain.Conference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Attending");

                    b.Property<string>("City");

                    b.Property<DateTime>("EndDate");

                    b.Property<int?>("FocusTopicId");

                    b.Property<string>("Name");

                    b.Property<bool>("Speaking");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("State");

                    b.HasKey("Id");

                    b.HasIndex("FocusTopicId");

                    b.ToTable("Conferences");
                });

            modelBuilder.Entity("Conferences.Api.Domain.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Conferences.Api.Domain.Conference", b =>
                {
                    b.HasOne("Conferences.Api.Domain.Topic", "FocusTopic")
                        .WithMany()
                        .HasForeignKey("FocusTopicId");
                });
#pragma warning restore 612, 618
        }
    }
}