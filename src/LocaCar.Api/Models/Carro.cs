namespace LocaCar.Api.Models
{
    public class Carro
    {
        public Carro()
        {
                
        }

        public Carro(string marca, string modelo, string ano, string cor, string tipoCorpo, string motor, string transmissao, decimal quilometragem, decimal preco, int numeroPortas, int capacidadePassageiros, string descricao)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Cor = cor;
            TipoCorpo = tipoCorpo;
            Motor = motor;
            Transmissao = transmissao;
            Quilometragem = quilometragem;
            Preco = preco;
            NumeroPortas = numeroPortas;
            CapacidadePassageiros = capacidadePassageiros;
            Descricao = descricao;
        }

        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Cor { get; set; }
        public string TipoCorpo { get; set; }
        public string Motor { get; set; }
        public string Transmissao { get; set; }
        public decimal Quilometragem { get; set; }
        public decimal Preco { get; set; }
        public int NumeroPortas { get; set; }
        public int CapacidadePassageiros { get; set; }
        public string Descricao { get; set; }
    }
}
