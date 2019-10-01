using System.Collections.Generic;
using System.Linq;
using Challenge.Domain.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace Challenge.Domain.Models
{
    public sealed class Endereco : Notifiable
    {
        public Endereco(string logradouro, string bairro, Cep cep, string cidade)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;

            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Cidade, "Cidade", "O nome da cidade é obrigatório!")
            );
        }

        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public Cep Cep { get; private set; }
        public string Cidade { get; private set; }

        public bool VerificaSeCidadeExiste(IEnumerable<string> cidades)
        {
            var cidadeExiste = cidades.Contains(Cidade);
            if (!cidadeExiste) AddNotification("Cidade", "Cidade não encontrada na base disponível para atendimento!");

            return cidadeExiste;
        }

        public override string ToString()
        {
            return $"{Logradouro} - {Bairro}, {Cidade}, {Cep}";
        }
    }
}