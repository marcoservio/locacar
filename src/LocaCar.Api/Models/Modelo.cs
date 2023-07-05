namespace LocaCar.Api.Models
{
    public class Modelo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual IEnumerable<AnoModelo> AnoModelo { get; set; }
    }
}
