using App.Domain.Commands.Contracts;

namespace App.Domain.Handlers.Contracts
{
    public interface IHandler<T>  where T : ICommand
    {
        ICommandResult handle(T command);
    }
}