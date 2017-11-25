﻿// <auto-generated />
using Accountant.DataAccess;
using Accountant.Domain.Budget;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Accountant.DataAccess.Migrations.Budgets
{
    [DbContext(typeof(BudgetsContext))]
    partial class BudgetsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Accountant.Domain.Budget.MonthBudget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Month");

                    b.Property<Guid>("TenantId");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("MonthBudgets");
                });

            modelBuilder.Entity("Accountant.Domain.Budget.Operation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<int>("Kind");

                    b.Property<Guid?>("MonthBudgetId");

                    b.Property<string>("Remarks");

                    b.Property<string>("Summary");

                    b.Property<Guid>("TenantId");

                    b.Property<DateTime>("UtcDateTime");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MonthBudgetId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("Accountant.Domain.Budget.OperationCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Kind");

                    b.Property<string>("Label");

                    b.Property<Guid>("TenantId");

                    b.HasKey("Id");

                    b.ToTable("OperationCategories");
                });

            modelBuilder.Entity("Accountant.Domain.Budget.Operation", b =>
                {
                    b.HasOne("Accountant.Domain.Budget.OperationCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Accountant.Domain.Budget.MonthBudget")
                        .WithMany("Operations")
                        .HasForeignKey("MonthBudgetId");
                });
#pragma warning restore 612, 618
        }
    }
}