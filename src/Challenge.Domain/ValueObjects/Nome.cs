using Challenge.Domain.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace Challenge.Domain.ValueObjects
{
    public sealed class Nome : Notifiable, IValueObject
    {
        public Nome(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;

            AddNotifications(new Contract()

            );
        }

        public string NomeCompleto { get; private set; }

        public override string ToString() => NomeCompleto;
        
    }
}