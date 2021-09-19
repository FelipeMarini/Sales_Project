

using Ofertas.Comum.Queries;

namespace Ofertas.Comum.Handlers.Contracts
{
    public interface IHandlerQuery<T> where T : IQuery
    {

        IQueryResult Handler(T query);

    }
}
