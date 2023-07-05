namespace LocaCar.Api.Models
{
    public class Ano
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<AnoModelo> AnoModelo { get; set; }
    }
}
