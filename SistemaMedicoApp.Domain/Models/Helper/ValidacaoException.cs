namespace SistemaMedicoApp.Domain.Models.Validations
{
    // Exceção personalizada para validações
    public class ValidacaoException : Exception
    {
        public string Detalhes { get; }

        public ValidacaoException(string mensagem, string detalhes = "") : base(mensagem)
        {
            Detalhes = detalhes;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Detalhes))
            {
                return base.ToString();
            }

            return $"{base.ToString()} - Detalhes: {Detalhes}";
        }
    }
}

