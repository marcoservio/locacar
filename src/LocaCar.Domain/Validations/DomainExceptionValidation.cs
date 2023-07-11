namespace LocaCar.Domain.Validations
{
    public  class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string erro) : base(erro) { }

        public static void When(bool hasErro, string erro)
        {
            if(hasErro)
                throw new DomainExceptionValidation(erro);
        }
    }
}
