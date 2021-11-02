﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockData.DataService.Contexts;

namespace StockData.Worker.Data.Migrations
{
    [DbContext(typeof(DataServiceContext))]
    [Migration("20210830151421_CompanyAndStockPriceTable")]
    partial class CompanyAndStockPriceTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockData.DataService.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TradeCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("StockData.DataService.Entities.StockPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Change")
                        .HasColumnType("int");

                    b.Property<int>("ClosePrice")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("High")
                        .HasColumnType("int");

                    b.Property<int>("LastTradingPrice")
                        .HasColumnType("int");

                    b.Property<int>("Low")
                        .HasColumnType("int");

                    b.Property<int>("Trade")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.Property<int>("YesterdayClosePrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.ToTable("StockPrices");
                });

            modelBuilder.Entity("StockData.DataService.Entities.StockPrice", b =>
                {
                    b.HasOne("StockData.DataService.Entities.Company", "Company")
                        .WithOne("StockPrice")
                        .HasForeignKey("StockData.DataService.Entities.StockPrice", "CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("StockData.DataService.Entities.Company", b =>
                {
                    b.Navigation("StockPrice");
                });
#pragma warning restore 612, 618
        }
    }
}
