using System.ComponentModel.DataAnnotations;

namespace LocaCar.Api.Dtos
{
    public class CarroDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Marca { get; set; }
        [Required]
        [StringLength(100)]
        public string Modelo { get; set; }
        [Required]
        [StringLength(4)]
        public string Ano { get; set; }
        [Required]
        [StringLength(40)]
        public string Cor { get; set; }
        [Required]
        [StringLength(50)]
        public string TipoCorpo { get; set; }
        [Required]
        [StringLength(50)]
        public string Motor { get; set; }
        [Required]
        [StringLength(50)]
        public string Transmissao { get; set; }
        [Required]
        public decimal Quilometragem { get; set; }
        [Required]
        public decimal Preco { get; set; }
        [Required]
        public int NumeroPortas { get; set; }
        [Required]
        public int CapacidadePassageiros { get; set; }
        [Required]
        [StringLength(300)]
        public string Descricao { get; set; }
    }
}
