using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Persistence.Entity;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;


namespace ServicesDeskUCABWS.Persistence.Database
{
    public class MigrationDbContext : DbContext, IMigrationDbContext
    {
        public MigrationDbContext(DbContextOptions<MigrationDbContext> options) : base(options)
        { }
        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }
        public virtual DbSet<Usuario> Usuario
        {
            get; set;
        }
        public virtual DbSet<Prioridad> Prioridades
        {
            get; set;
        }

        public virtual DbSet<TipoCargo> TipoCargos
        {
            get; set;
        }
        public virtual DbSet<Ticket> Tickets
        {
            get; set;
        }
        public virtual DbSet<Estado> Estados
        {
            get; set;
        }

        public virtual DbSet<Plantilla> Plantillas
        {
            get; set;
        }

        public virtual DbSet<Etiqueta> Etiquetas
        {
            get; set;
        }

        public virtual DbSet<administrador> Administradores
        {
            get; set;
        }
        public virtual DbSet<Empleado> Empleados
        {
            get; set;
        }
        public virtual DbSet<Cliente> clientes
        {
            get; set;
        }
        public virtual DbSet<Cargo> Cargos
        {
            get; set;
        }
        public virtual DbSet<Departamento> Departamentos
        {
            get; set;
        }
        public virtual DbSet<Categoria> Categorias
        {
            get; set;
        }

        public virtual DbSet<ModeloJerarquico> ModeloJerarquicos
        {
            get; set;
        }

        public virtual DbSet<Grupo> Grupo
        {
            get;set;
        } 
        public virtual DbSet<ModeloParalelo> ModeloParalelos
        {
            get; set;
        }
        public virtual DbSet<FlujoAprobacion> FlujoAprobaciones
        {
            get; set;
        }
         public  DbSet<TickectsRelacionados> TickectsRelacionados
        {
            get; set;
        }
        public DbSet<ModeloAprobacion> ModeloAprobacion
        {
            get; set;
        }
        public DbSet<ModeloJerarquicoCargos> ModeloJerarquicoCargos
        {
            get; set;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        modelBuilder.Entity<TickectsRelacionados>().HasKey(i => new { i.Ticketid, i.TicketRelacionadoid });
                modelBuilder.Entity<TickectsRelacionados>()
                .HasOne(pt => pt.TicketRelacion)
                .WithMany(p => p.TickectsRelacionadosHijos)
                .HasForeignKey(pt => pt.TicketRelacionadoid)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<TickectsRelacionados>()
                .HasOne(pt => pt.ticket)
                .WithMany(t => t.TickectsRelacionadosPadre)
                .HasForeignKey(pt => pt.Ticketid)
                .OnDelete(DeleteBehavior.ClientNoAction);     
        }


    }
}