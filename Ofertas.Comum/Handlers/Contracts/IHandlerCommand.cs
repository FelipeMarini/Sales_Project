using Ofertas.Comum.Commands;

namespace Ofertas.Comum.Handlers.Contracts
{

    // <T> é um objeto genérico garantindo que a interface de handlers esteja herdando ICommand
    // assim como os Commands herdam de ICommand
    public interface IHandlerCommand<T> where T: ICommand
    {

        ICommandResult Handler(T command);  // recebe resultados das validações dos Commands

    }
}
