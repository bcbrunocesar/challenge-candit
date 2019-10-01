using System.Linq;
using System.Threading.Tasks;
using Challenge.Domain.Commands.CotacaoCommands.Input;
using Challenge.Domain.Commands.CotacaoCommands.Output;
using Challenge.Domain.Interfaces;
using Challenge.Domain.Models;
using Challenge.Domain.Services;
using Challenge.Domain.ValueObjects;
using Flunt.Notifications;

namespace Challenge.Domain.Handlers
{
    public class CotacaoHandler : Notifiable,
        ICommandHandler<RealizarCotacaoCommand>
    {
        private readonly ICidadeService _cidadeService;

        public CotacaoHandler(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        public async Task<ICommandResult> Handle(RealizarCotacaoCommand command)
        {
            var nome = new Nome(command.Nome);
            var cep = new Cep(command.Endereco.Cep);
            var endereco = new Endereco(command.Endereco.Logradouro, command.Endereco.Bairro, cep, command.Endereco.Cidade);
            var coberturas = Cobertura.ObterCoberturasPorId(command.Coberturas);
            var segurado = new Cotacao(nome, command.Nascimento, endereco, coberturas);

            AddNotifications(nome, cep, endereco, segurado);
            if (Invalid) return CommandResult.Factory.CommandInvalid(false, "Não foi possível realizar a cotação!", Notifications);

            var cidades = (await _cidadeService.ObterTodasAsync()).Select(x => x.Name);
            if (!endereco.VerificaSeCidadeExiste(cidades)) return CommandResult.Factory.CommandInvalid(false, "Não foi possível realizar a cotação!", endereco.Notifications);

            var totalCobertura = segurado.TotalCobertura();
            var premio = segurado.Premio();
            var primeiroVencimento = segurado.PrimeiroVencimento();
            var quantidadeParcelas = segurado.Parcelas();
            var valorParcelas = segurado.ValorParcelas();

            return new CommandResult(
                true,
                $"Cotação realizada com sucesso para o(a) {command.Nome}!",
                new RealizarCotacaoCommandResult(
                    premio,
                    quantidadeParcelas,
                    valorParcelas,
                    primeiroVencimento,
                    totalCobertura));
        }
    }
}