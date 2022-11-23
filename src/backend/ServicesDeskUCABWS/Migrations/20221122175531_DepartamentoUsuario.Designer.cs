﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServicesDeskUCABWS.Persistence.Database;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    [DbContext(typeof(MigrationDbContext))]
    [Migration("20221122175531_DepartamentoUsuario")]
    partial class DepartamentoUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Cargo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipoCargoId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("tipoCargoId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Categoria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Departamento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Estado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("EtiquetaId")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("notificationid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("EtiquetaId");

                    b.HasIndex("notificationid");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Etiqueta", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Etiquetas");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.FlujoAprobacion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<Guid?>("modeloParaleloid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("modelojerarquicoid")
                        .HasColumnType("int");

                    b.Property<int>("secuencia")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int?>("ticketid")
                        .HasColumnType("int");

                    b.Property<int?>("usuarioid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("modeloParaleloid");

                    b.HasIndex("modelojerarquicoid")
                        .IsUnique();

                    b.HasIndex("ticketid");

                    b.HasIndex("usuarioid");

                    b.ToTable("FlujoAprobacion");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Grupo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("Departamentoid")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Departamentoid");

                    b.ToTable("Grupo");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.ModeloJerarquico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("ModeloJerarquicos");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.ModeloParalelo", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("cantidadAprobaciones")
                        .HasColumnType("int");

                    b.Property<int>("categoriaid")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("paraleloId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("categoriaid");

                    b.ToTable("ModeloParalelo");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Notification", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("Plantillaid")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("usuarioid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Plantillaid");

                    b.HasIndex("usuarioid");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Plantilla", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("cuerpo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Plantillas");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Prioridad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Prioridades");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Ticket", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("Statusid")
                        .HasColumnType("int");

                    b.Property<int?>("asginadoaid")
                        .HasColumnType("int");

                    b.Property<int?>("creadoporid")
                        .HasColumnType("int");

                    b.Property<int?>("delegacionid")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("prioridadid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Statusid");

                    b.HasIndex("asginadoaid");

                    b.HasIndex("creadoporid");

                    b.HasIndex("delegacionid");

                    b.HasIndex("prioridadid");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.TipoCargo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("ModeloJerarquicoId")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("ModeloJerarquicoId");

                    b.ToTable("TipoCargos");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("Departamentoid")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Grupoid")
                        .HasColumnType("int");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("VerifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("cargoid")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("passwordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Departamentoid");

                    b.HasIndex("Grupoid");

                    b.HasIndex("cargoid");

                    b.ToTable("Usuario");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.administrador", b =>
                {
                    b.HasBaseType("ServicesDeskUCABWS.Persistence.Entity.Usuario");

                    b.HasDiscriminator().HasValue("administrador");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Cliente", b =>
                {
                    b.HasBaseType("ServicesDeskUCABWS.Persistence.Entity.Usuario");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Empleado", b =>
                {
                    b.HasBaseType("ServicesDeskUCABWS.Persistence.Entity.Usuario");

                    b.HasDiscriminator().HasValue("Empleado");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Cargo", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.TipoCargo", "tipoCargo")
                        .WithMany()
                        .HasForeignKey("tipoCargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tipoCargo");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Estado", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Etiqueta", "etiqueta")
                        .WithMany("estados")
                        .HasForeignKey("EtiquetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Notification", "notification")
                        .WithMany()
                        .HasForeignKey("notificationid");

                    b.Navigation("etiqueta");

                    b.Navigation("notification");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.FlujoAprobacion", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.ModeloParalelo", "modeloParalelo")
                        .WithMany()
                        .HasForeignKey("modeloParaleloid");

                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.ModeloJerarquico", "modeloJerarquico")
                        .WithOne("flujoAprobacion")
                        .HasForeignKey("ServicesDeskUCABWS.Persistence.Entity.FlujoAprobacion", "modelojerarquicoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Ticket", "ticket")
                        .WithMany()
                        .HasForeignKey("ticketid");

                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioid");

                    b.Navigation("modeloJerarquico");

                    b.Navigation("modeloParalelo");

                    b.Navigation("ticket");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Grupo", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Departamento", null)
                        .WithMany("grupos")
                        .HasForeignKey("Departamentoid");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.ModeloJerarquico", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Categoria", "categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoria");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.ModeloParalelo", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Categoria", "categoria")
                        .WithMany()
                        .HasForeignKey("categoriaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoria");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Notification", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Plantilla", null)
                        .WithMany("notifications")
                        .HasForeignKey("Plantillaid");

                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioid");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Ticket", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Estado", "Status")
                        .WithMany()
                        .HasForeignKey("Statusid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Usuario", "asginadoa")
                        .WithMany()
                        .HasForeignKey("asginadoaid");

                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Usuario", "creadopor")
                        .WithMany()
                        .HasForeignKey("creadoporid");

                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Ticket", "delegacion")
                        .WithMany()
                        .HasForeignKey("delegacionid");

                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Prioridad", "prioridad")
                        .WithMany()
                        .HasForeignKey("prioridadid");

                    b.Navigation("Status");

                    b.Navigation("asginadoa");

                    b.Navigation("creadopor");

                    b.Navigation("delegacion");

                    b.Navigation("prioridad");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.TipoCargo", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.ModeloJerarquico", null)
                        .WithMany("orden")
                        .HasForeignKey("ModeloJerarquicoId");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Usuario", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Departamento", "Departamento")
                        .WithMany("Usuarios")
                        .HasForeignKey("Departamentoid");

                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Grupo", null)
                        .WithMany("usuarios")
                        .HasForeignKey("Grupoid");

                    b.HasOne("ServicesDeskUCABWS.Persistence.Entity.Cargo", "cargo")
                        .WithMany("Usuarios")
                        .HasForeignKey("cargoid");

                    b.Navigation("Departamento");

                    b.Navigation("cargo");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Cargo", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Departamento", b =>
                {
                    b.Navigation("Usuarios");

                    b.Navigation("grupos");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Etiqueta", b =>
                {
                    b.Navigation("estados");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Grupo", b =>
                {
                    b.Navigation("usuarios");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.ModeloJerarquico", b =>
                {
                    b.Navigation("flujoAprobacion");

                    b.Navigation("orden");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Persistence.Entity.Plantilla", b =>
                {
                    b.Navigation("notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
