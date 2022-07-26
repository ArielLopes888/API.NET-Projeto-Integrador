﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PI_DigitalHouse_API_MVC.Models;

#nullable disable

namespace PI_DigitalHouse_API_MVC.Migrations
{
    [DbContext(typeof(MeuPetContext))]
    partial class MeuPetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PI_DigitalHouse_API_MVC.Models.AcheiPet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Informações")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomePet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumColeira")
                        .HasColumnType("int");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.Property<string>("TipoPet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AcheiPet");
                });

            modelBuilder.Entity("PI_DigitalHouse_API_MVC.Models.CadastroPet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CadastroUsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("Informações")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Raça")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoPet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CadastroUsuarioId");

                    b.ToTable("CadastroPets");
                });

            modelBuilder.Entity("PI_DigitalHouse_API_MVC.Models.CadastroUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StatusCadastro")
                        .HasColumnType("bit");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CadastroUsuarios");
                });

            modelBuilder.Entity("PI_DigitalHouse_API_MVC.Models.PerdiMeuPet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CadastroPetId")
                        .HasColumnType("int");

                    b.Property<string>("Informacoes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalDesaparecimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StatusPerdido")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CadastroPetId")
                        .IsUnique();

                    b.ToTable("PerdiMeusPets");
                });

            modelBuilder.Entity("PI_DigitalHouse_API_MVC.Models.CadastroPet", b =>
                {
                    b.HasOne("PI_DigitalHouse_API_MVC.Models.CadastroUsuario", null)
                        .WithMany("Pets")
                        .HasForeignKey("CadastroUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PI_DigitalHouse_API_MVC.Models.PerdiMeuPet", b =>
                {
                    b.HasOne("PI_DigitalHouse_API_MVC.Models.CadastroPet", null)
                        .WithOne("PerdiMeuPet")
                        .HasForeignKey("PI_DigitalHouse_API_MVC.Models.PerdiMeuPet", "CadastroPetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PI_DigitalHouse_API_MVC.Models.CadastroPet", b =>
                {
                    b.Navigation("PerdiMeuPet");
                });

            modelBuilder.Entity("PI_DigitalHouse_API_MVC.Models.CadastroUsuario", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
