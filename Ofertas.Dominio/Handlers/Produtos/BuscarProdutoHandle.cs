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

            var produto = produtoRepositorio.BuscarProdutoPorId(query.IdBuscaProduto);

            var retornoProduto = produto.ToString(); 
            
            // tirar dúvida com o Paulo de como mostrar o produto aqui da busca

            return new GenericQueryResult(true,"Produto encontrado",retornoProduto);

        }
    
    
    }

}
