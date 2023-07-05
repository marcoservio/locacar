using LocaCar.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LocaCar.Api.Data.ModelsConfigurations
{
    public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("marcas");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id_mar").IsRequired();
            builder.Property(c => c.Codigo).HasColumnName("codigo_mar").IsRequired().HasMaxLength(10);
            builder.Property(c => c.Nome).HasColumnName("nome_mar").IsRequired().HasMaxLength(100);

            builder.Property<DateTime>("last_update_amd")
                .IsRequired()
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
