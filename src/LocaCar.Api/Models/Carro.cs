using LocaCar.Domain.Validations;

namespace LocaCar.Api.Models
{
    public class Carro
    {
        private int id;
        private string marca;
        private string modelo;
        private string ano;
        private string cor;
        private string tipoCorpo;
        private string motor;
        private string transmissao;
        private string descricao;

        public int Id
        {
            get { return id; }
            set
            {
                DomainExceptionValidation.When(value < 0, "O Id do carro deve ser positivo.");
                id = value;
            }
        }

        public string Marca
        {
            get { return marca; }
            set
            {
                DomainExceptionValidation.When(value.Length > 50, "A Marca deve ter no máximo 50 caracteres.");
                marca = value;
            }
        }

        public string Modelo
        {
            get { return modelo; }
            set
            {
                DomainExceptionValidation.When(value.Length > 50, "O Modelo deve ter no máximo 50 caracteres.");
                modelo = value;
            }
        }

        public string Ano
        {
            get { return ano; }
            set
            {
                DomainExceptionValidation.When(value.Length != 4, "O Ano deve ter 4 caracteres.");
                ano = value;
            }
        }

        public string Cor
        {
            get { return cor; }
            set
            {
                DomainExceptionValidation.When(value.Length > 40, "A Cor deve ter no máximo 40 caracteres.");
                cor = value;
            }
        }

        public string TipoCorpo
        {
            get { return tipoCorpo; }
            set
            {
                DomainExceptionValidation.When(value.Length > 50, "O Tipo Corpo deve ter no máximo 50 caracteres.");
                tipoCorpo = value;
            }
        }

        public string Motor
        {
            get { return motor; }
            set
            {
                DomainExceptionValidation.When(value.Length > 50, "O Motor deve ter no máximo 50 caracteres.");
                motor = value;
            }
        }

        public string Transmissao
        {
            get { return transmissao; }
            set
            {
                DomainExceptionValidation.When(value.Length > 50, "A Transmissão deve ter no máximo 50 caracteres.");
                transmissao = value;
            }
        }

        public string Descricao
        {
            get { return descricao; }
            set
            {
                DomainExceptionValidation.When(value.Length > 300, "A Descrição deve ter no máximo 300 caracteres.");
                descricao = value;
            }
        }

        public decimal Quilometragem { get; set; }

        public decimal Preco { get; set; }

        public int NumeroPortas { get; set; }

        public int CapacidadePassageiros { get; set; }
    }
}