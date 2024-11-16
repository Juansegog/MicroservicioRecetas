using GestionRecetas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionRecetas.Infraestructura.ConfiguracionesBD
{
    public class ConfigurationReceta : IEntityTypeConfiguration<Receta>
    {
        public void Configure(EntityTypeBuilder<Receta> builder)
        {
            builder.ToTable("Recetas");
            builder.HasKey(x => x.Id);


            builder.OwnsOne(l => l.DireccionReclamacion, dir =>
            {
                dir.Property(d => d.Calle)
                    .HasMaxLength(100)
                    .HasColumnName("Calle");

                dir.Property(d => d.Barrio)
                    .HasMaxLength(100)
                    .HasColumnName("Barrio");

                dir.Property(d => d.Departamento)
                    .HasMaxLength(100)
                    .HasColumnName("Departamento");

                dir.Property(d => d.Municipio)
                    .HasMaxLength(100)
                    .HasColumnName("Municipio");
            });

        }
    }
}
