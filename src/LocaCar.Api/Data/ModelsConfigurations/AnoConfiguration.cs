using LocaCar.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LocaCar.Api.Data.ModelsConfigurations
{
    public class AnoConfiguration : IEntityTypeConfiguration<Ano>
    {
        public void Configure(EntityTypeBuilder<Ano> builder)
        {
            builder.ToTable("anos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id_ano").IsRequired();
            builder.Property(c => c.Codigo).HasColumnName("codigo_ano").IsRequired().HasMaxLength(10);
            builder.Property(c => c.Nome).HasColumnName("nome_ano").IsRequired().HasMaxLength(100);

            builder.Property<DateTime>("last_update_amd")
                .IsRequired()
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
