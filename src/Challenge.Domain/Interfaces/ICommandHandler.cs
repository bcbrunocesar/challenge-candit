using System.Threading.Tasks;

namespace Challenge.Domain.Interfaces
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}