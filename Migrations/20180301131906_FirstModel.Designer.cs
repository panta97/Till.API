﻿// <auto-generated />
using caja.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace caja.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180301131906_FirstModel")]
    partial class FirstModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("caja.Models.Earning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<decimal>("Denomination");

                    b.Property<int>("TallyId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Earnings");
                });

            modelBuilder.Entity("caja.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<string>("Description");

                    b.Property<int>("TallyId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("caja.Models.Tally", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<decimal>("Final");

                    b.Property<int?>("TillId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TillId");

                    b.HasIndex("UserId");

                    b.ToTable("Tallies");
                });

            modelBuilder.Entity("caja.Models.TallyEarning", b =>
                {
                    b.Property<int>("EarningId");

                    b.Property<int>("TallyId");

                    b.HasKey("EarningId", "TallyId");

                    b.HasIndex("TallyId");

                    b.ToTable("TallyEarnings");
                });

            modelBuilder.Entity("caja.Models.TallyExpense", b =>
                {
                    b.Property<int>("ExpenseId");

                    b.Property<int>("TallyId");

                    b.HasKey("ExpenseId", "TallyId");

                    b.HasIndex("TallyId");

                    b.ToTable("TallyExpenses");
                });

            modelBuilder.Entity("caja.Models.Till", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Number");

                    b.Property<string>("Store");

                    b.HasKey("Id");

                    b.ToTable("Tills");
                });

            modelBuilder.Entity("caja.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("caja.Models.Tally", b =>
                {
                    b.HasOne("caja.Models.Till")
                        .WithMany("Tallies")
                        .HasForeignKey("TillId");

                    b.HasOne("caja.Models.User")
                        .WithMany("Tallies")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("caja.Models.TallyEarning", b =>
                {
                    b.HasOne("caja.Models.Earning", "Earning")
                        .WithMany("Tally")
                        .HasForeignKey("EarningId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("caja.Models.Tally", "Tally")
                        .WithMany("Earnings")
                        .HasForeignKey("TallyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("caja.Models.TallyExpense", b =>
                {
                    b.HasOne("caja.Models.Expense", "Expense")
                        .WithMany("Tally")
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("caja.Models.Tally", "Tally")
                        .WithMany("Expenses")
                        .HasForeignKey("TallyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}