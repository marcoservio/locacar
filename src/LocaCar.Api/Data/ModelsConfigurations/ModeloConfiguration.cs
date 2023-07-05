using LocaCar.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LocaCar.Api.Data.ModelsConfigurations
{
    public class ModeloConfiguration : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable("modelos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id_mod").IsRequired();
            builder.Property(c => c.Codigo).HasColumnName("codigo_mod").IsRequired().HasMaxLength(10);
            builder.Property(c => c.Nome).HasColumnName("nome_mod").IsRequired().HasMaxLength(100);
            builder.Property<int>("MarcaId").IsRequired().HasColumnName("idMarca_mod");

            builder.Property<DateTime>("last_update_amd")
                .IsRequired()
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
