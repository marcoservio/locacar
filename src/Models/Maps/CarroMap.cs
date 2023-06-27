using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocaCar.Api.Models.Maps
{
    public class CarroMap : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.ToTable("carros");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id_car").IsRequired();
            builder.Property(c => c.Marca).HasColumnName("marca_car").IsRequired().HasMaxLength(100);
            builder.Property(c => c.Modelo).HasColumnName("modelo_car").IsRequired().HasMaxLength(100);
            builder.Property(c => c.Ano).HasColumnName("ano_car").IsRequired().HasMaxLength(4);
            builder.Property(c => c.Cor).HasColumnName("cor_car").IsRequired().HasMaxLength(40);
            builder.Property(c => c.TipoCorpo).HasColumnName("tipoCorpo_car").IsRequired().HasMaxLength(50);
            builder.Property(c => c.Motor).HasColumnName("motor_car").IsRequired().HasMaxLength(50);
            builder.Property(c => c.Transmissao).HasColumnName("transmissao_car").IsRequired().HasMaxLength(50);
            builder.Property(c => c.Quilometragem).HasColumnName("quilometragem_car").IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.Preco).HasColumnName("preco_car").IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.NumeroPortas).HasColumnName("numeroPortas_car").IsRequired();
            builder.Property(c => c.CapacidadePassageiros).HasColumnName("capacidadePassageiros_car").IsRequired();
            builder.Property(c => c.Descricao).HasColumnName("descricao_car").IsRequired().HasMaxLength(300);
        }
    }
}
