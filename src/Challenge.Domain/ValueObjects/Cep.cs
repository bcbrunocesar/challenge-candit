using System.Text.RegularExpressions;
using Challenge.Domain.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace Challenge.Domain.ValueObjects
{
    public sealed class Cep : Notifiable, IValueObject
    {
        public Cep(string numero)
        {
            Numero = numero;

            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Numero, "Cep", "O cep é obrigatório!")
                .IsTrue(ValidarCep(Numero), "Numero", "CEP inválido!")
            );
        }

        public string Numero { get; private set; }

        private static bool ValidarCep(string cep)
        {
            return Regex.IsMatch(cep, "[0-9]{5}-[0-9]{3}");
        } 

        public override string ToString() => Numero;
    }
}