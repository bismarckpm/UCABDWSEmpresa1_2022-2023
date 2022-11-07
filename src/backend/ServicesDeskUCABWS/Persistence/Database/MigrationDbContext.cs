using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Persistence.Entity;


namespace ServicesDeskUCABWS.Persistence.Database
{
    public class MigrationDbContext : DbContext ,IMigrationDbContext
    {
        public MigrationDbContext(DbContextOptions<MigrationDbContext> options) : base(options)
        {}
        public DbContext DbContext{
            get
            { 
                return this;
            }
        }
        public virtual DbSet<Usuario> Usuario
        {
            get; set;
        }
        public virtual DbSet<Notification> Notifications
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
        public  virtual DbSet<Ticket> Tickets
        {
            get; set;
        }
        public virtual DbSet<Estado> Estado
        {
            get; set;
        }
     public virtual DbSet<administrador> Administradores
        {
            get; set;
        }
       public virtual   DbSet<Empleado> Empleados
        {
            get; set;
        }
       public virtual     DbSet<Cliente> clientes
        {
            get; set;
        }
        public virtual DbSet<Cargo> Cargos{
            get;set;
        }
        public virtual DbSet<Grupo> Grupos
        {
            get;set;
        }
    }
    
}