﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using THEJOB.Cachorro.Repository;

#nullable disable

namespace THEJOB.Cachorro.Repository.Migrations.API
{
    [DbContext(typeof(CachorroDbContext))]
    partial class CachorroDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("THEJOB.Cachorro.Domain.Cachorro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<bool>("Adotado")
                        .HasColumnType("bit")
                        .HasColumnName("Adotado");

                    b.Property<DateTime>("Atualizacao")
                        .HasColumnType("datetime")
                        .HasColumnName("DataAlteracao");

                    b.Property<DateTime>("Cadastro")
                        .HasColumnType("datetime")
                        .HasColumnName("DataCadastro");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("Pelagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(6,2)")
                        .HasColumnName("Peso");

                    b.HasKey("Id");

                    b.HasIndex("Adotado");

                    b.HasIndex("Id", "Atualizacao");

                    b.ToTable("Cao", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ce5cdcc9-7f21-48bf-a677-54ca3c635429"),
                            Adotado = true,
                            Atualizacao = new DateTime(2024, 2, 11, 2, 6, 30, 531, DateTimeKind.Local).AddTicks(4969),
                            Cadastro = new DateTime(2024, 2, 11, 2, 6, 30, 531, DateTimeKind.Local).AddTicks(4952),
                            Nascimento = new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Rex",
                            Pelagem = "Longo",
                            Peso = 9.3m
                        });
                });

            modelBuilder.Entity("THEJOB.Cachorro.Domain.Tutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Atualizacao")
                        .HasColumnType("datetime")
                        .HasColumnName("DataAlteracao");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("Cadastro")
                        .HasColumnType("datetime")
                        .HasColumnName("DataCadastro");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("Id", "Atualizacao");

                    b.ToTable("Tutor", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}