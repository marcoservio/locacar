namespace LocaCar.Api.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public virtual List<Modelo> Modelos { get; set; }
    }
}
