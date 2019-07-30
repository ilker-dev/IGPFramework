﻿// <auto-generated />
using System;
using IgpFramework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IgpFramework.Data.Migrations
{
    [DbContext(typeof(IGPCoreContext))]
    partial class IGPCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IgpFramework.Data.Users.User", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("decimal(20)");

                    b.Property<string>("Adi")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CepTelefonu")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Cinsiyeti")
                        .HasColumnType("int(1)");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("date");

                    b.Property<string>("Eposta")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("KullaniciAdi")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Sifresi")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Soyadi")
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("TcKimlikNo")
                        .HasColumnType("decimal(11)");

                    b.HasKey("Id");

                    b.ToTable("IGP_KULLANICI_BILGILERI");
                });
#pragma warning restore 612, 618
        }
    }
}