using Challenge.Domain.Interfaces;

namespace Challenge.Domain.Commands.CotacaoCommands.Output
{
    public sealed class CommandResult : ICommandResult
    {
        private CommandResult() { }

        public CommandResult(bool success, string message, object result)
        {
            Success = success;
            Message = message;
            Result = result;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
        public object Result { get; private set; }
        public object Notifications { get; private set; }

        public static class Factory
        {
            public static CommandResult CommandInvalid(bool success, string message, object notifications)
            {
                return new CommandResult
                {
                    Success = success,
                    Message = message,
                    Notifications = notifications
                };
            }
        }
    }
}