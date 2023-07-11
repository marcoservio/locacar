using LocaCar.Domain.Validations;

namespace LocaCar.Domain.Models
{
    public class Carro2
    {
        public int Id
        {
            get { return Id; }
            set
            {
                DomainExceptionValidation.When(Id < 0, "O Id do carro deve ser positivo.");
                Id = value;
            }
        }
        public string Marca
        {
            get { return Marca; }
            set
            {
                DomainExceptionValidation.When(Marca.Length > 50, "A Marca deve ter no maximo 50 caracteres.");
                Marca = value;
            }
        }
        public string Modelo
        {
            get { return Modelo; }
            set
            {
                DomainExceptionValidation.When(Modelo.Length > 50, "O Modelo deve ter no maximo 50 caracteres.");
                Modelo = value;
            }
        }
        public string Ano
        {
            get { return Ano; }
            set
            {
                DomainExceptionValidation.When(Ano.Length != 4, "O Ano deve ter 4 caracteres.");
                Ano = value;
            }
        }
        public string Cor
        {
            get { return Cor; }
            set
            {
                DomainExceptionValidation.When(Cor.Length > 40, "A Cor deve ter no maximo 40 caracteres.");
                Cor = value;
            }
        }
        public string TipoCorpo
        {
            get { return TipoCorpo; }
            set
            {
                DomainExceptionValidation.When(TipoCorpo.Length > 50, "O Tipo Corpo deve ter no maximo 50 caracteres.");
                TipoCorpo = value;
            }
        }
        public string Motor
        {
            get { return Motor; }
            set
            {
                DomainExceptionValidation.When(Motor.Length > 50, "O Motor deve ter no maximo 50 caracteres.");
                Motor = value;
            }
        }
        public string Transmissao
        {
            get { return Transmissao; }
            set
            {
                DomainExceptionValidation.When(Transmissao.Length > 50, "A Transmissão deve ter no maximo 50 caracteres.");
                Transmissao = value;
            }
        }
        public string Descricao
        {
            get { return Descricao; }
            set
            {
                DomainExceptionValidation.When(Descricao.Length > 300, "A Descrição deve ter no maximo 300 caracteres.");
                Descricao = value;
            }
        }
        public decimal Quilometragem { get; set; }
        public decimal Preco { get; set; }
        public int NumeroPortas { get; set; }
        public int CapacidadePassageiros { get; set; }
    }
}
