using System;
using System.Collections.Generic;
using Challenge.Domain.Interfaces;

namespace Challenge.Domain.Commands.CotacaoCommands.Input
{
    public class RealizarCotacaoCommand : ICommand
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public EnderecoCommand Endereco { get; set; }
        public List<string> Coberturas { get; set; }
    }
}