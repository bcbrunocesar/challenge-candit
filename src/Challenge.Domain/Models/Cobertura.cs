namespace Challenge.Domain.Models
{
    public sealed class Cobertura
    {
        public Cobertura(string id, string nome, double premio, double valor, char principal)
        {
            Id = id;
            Nome = nome;
            Premio = premio;
            Valor = valor;
            Principal = principal;
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public double Premio { get; private set; }
        public double Valor { get; private set; }
        public char Principal { get; private set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}