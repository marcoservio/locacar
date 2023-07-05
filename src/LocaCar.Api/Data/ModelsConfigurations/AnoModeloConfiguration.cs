using LocaCar.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LocaCar.Api.Data.ModelsConfigurations
{
    public class AnoModeloConfiguration : IEntityTypeConfiguration<AnoModelo>
    {
        public void Configure(EntityTypeBuilder<AnoModelo> builder)
        {
            builder.ToTable("anos_modelos");
            builder.Property<int>("AnoId").IsRequired().HasColumnName("idAno_amd");
            builder.Property<int>("ModeloId").IsRequired().HasColumnName("idModelo_amd");

            builder.Property<DateTime>("last_update_amd")
                .IsRequired()
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasKey("AnoId", "ModeloId");

            builder
                .HasOne(am => am.Ano)
                .WithMany(a => a.AnoModelo)
                .HasForeignKey("AnoId");

            builder
                .HasOne(am => am.Modelo)
                .WithMany(m => m.AnoModelo)
                .HasForeignKey("ModeloId");
        }
    }
}
