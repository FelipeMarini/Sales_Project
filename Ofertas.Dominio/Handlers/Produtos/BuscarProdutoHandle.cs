using Flunt.Notifications;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Queries.Produto;
using Ofertas.Dominio.Repositories;


namespace Ofertas.Dominio.Handlers.Produtos
{
    public class BuscarProdutoHandle : Notifiable<Notification>, IHandlerQuery<BuscarProdutoQuery>
    {

        private readonly IProdutoRepositorio produtoRepositorio;


        public BuscarProdutoHandle(IProdutoRepositorio _produtoRepositorio)
        {
            produtoRepositorio = _produtoRepositorio;
        }
        
        
        public IQueryResult Handler(BuscarProdutoQuery query)
        {

            var retornoProduto = produtoRepositorio.BuscarProdutoPorId(query.IdBuscaProduto);


            if (retornoProduto == null)
            {
                return new GenericQueryResult(false,"Produto não encontrado",null);
            }
            

            return new GenericQueryResult(true,"Produto encontrado",retornoProduto);

        }
    
    
    }

}
