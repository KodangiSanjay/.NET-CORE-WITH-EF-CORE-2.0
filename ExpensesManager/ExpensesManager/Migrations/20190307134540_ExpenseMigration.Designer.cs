﻿// <auto-generated />
using System;
using ExpensesManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExpensesManager.Migrations
{
    [DbContext(typeof(ExpenseDBContext))]
    [Migration("20190307134540_ExpenseMigration")]
    partial class ExpenseMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExpensesManager.Models.ExpenseReport", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<DateTime>("ExpenseDate");

                    b.Property<string>("ItemName")
                        .IsRequired();

                    b.HasKey("ItemId");

                    b.ToTable("ExpenseReport");
                });
#pragma warning restore 612, 618
        }
    }
}
