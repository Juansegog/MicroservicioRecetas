using GestionRecetas.Domain.Entities;
using GestionRecetas.Infraestructura.ConfiguracionesBD;
using Microsoft.EntityFrameworkCore;

namespace GestionRecetas.Infraestructura.Persistencia
{
    public class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ConfigurationReceta());
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Receta> Recetas { get; set; }
    }
}
