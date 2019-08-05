﻿// <auto-generated />
using System;
using IgpFramework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Igp.Data.Common.Migrations
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

            modelBuilder.Entity("IgpFramework.Data.Model.Menus.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("MenuUrl")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("ParentId");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("date");

                    b.Property<int>("RecordUserId");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("date");

                    b.Property<int?>("UpdateUserId");

                    b.HasKey("Id");

                    b.ToTable("IGP_MENU");
                });

            modelBuilder.Entity("IgpFramework.Data.Model.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<decimal?>("IdentityKey")
                        .HasColumnType("decimal(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("date");

                    b.Property<int>("RecordUserId");

                    b.Property<int?>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("date");

                    b.Property<int?>("UpdateUserId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("IGP_USER");
                });

            modelBuilder.Entity("IgpFramework.Data.Model.Users.UserMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MenuId");

                    b.Property<int>("Modify");

                    b.Property<int>("Read");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("date");

                    b.Property<int>("RecordUserId");

                    b.Property<int>("Report");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("date");

                    b.Property<int?>("UpdateUserId");

                    b.Property<int>("UserId");

                    b.Property<int>("Write");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("UserId");

                    b.ToTable("IGP_USER_MENU_PERMISSIONS");
                });

            modelBuilder.Entity("IgpFramework.Data.Model.Users.UserPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("date");

                    b.Property<int>("RecordUserId");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("date");

                    b.Property<int?>("UpdateUserId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("IGP_USER_PASSWORDS");
                });

            modelBuilder.Entity("IgpFramework.Data.Model.Users.UserSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LoginDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("LogoutDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("date");

                    b.Property<int>("RecordUserId");

                    b.Property<string>("SessionId")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("date");

                    b.Property<int?>("UpdateUserId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("IGP_USER_SESSIONS");
                });

            modelBuilder.Entity("IgpFramework.Data.Model.Users.UserMenu", b =>
                {
                    b.HasOne("IgpFramework.Data.Model.Menus.Menu", "Menu")
                        .WithMany("UserMenuPermissions")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IgpFramework.Data.Model.Users.User", "User")
                        .WithMany("UserMenuPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IgpFramework.Data.Model.Users.UserPassword", b =>
                {
                    b.HasOne("IgpFramework.Data.Model.Users.User", "User")
                        .WithMany("UserPasswords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IgpFramework.Data.Model.Users.UserSession", b =>
                {
                    b.HasOne("IgpFramework.Data.Model.Users.User", "User")
                        .WithMany("UserSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
