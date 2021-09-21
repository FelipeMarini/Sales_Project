using Flunt.Notifications;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Queries.Produto;
using Ofertas.Dominio.Repositories;
using System.Linq;
using static Ofertas.Dominio.Queries.Produto.ListarProdutosQuery;

namespace Ofertas.Dominio.Handlers.Produtos
{
    public class ListarProdutosHandle : Notifiable<Notification>, IHandlerQuery<ListarProdutosQuery>
    {

        private readonly IProdutoRepositorio produtoRepositorio;

        public ListarProdutosHandle(IProdutoRepositorio _produtoRepositorio)
        {
            produtoRepositorio = _produtoRepositorio;
        }


        public IQueryResult Handler(ListarProdutosQuery query)
        {

            var produtos = produtoRepositorio.ListarProdutos(query.SituacaoReserva);

            var retornoProdutos = produtos.Select(
                
                x =>
                {
                    return new ListarProdutosResult()
                    {
                        Id = x.Id,
                        DataCriacao = x.DataCriacao,
                        Titulo = x.Titulo,
                        Imagem = x.Imagem,
                        Descricao = x.Descricao,
                        TipoProduto = x.TipoProduto,
                        StatusPreco = x.StatusPreco,
                        Quantidade = x.Quantidade
                    };
                
                }                
                
                );


            return new GenericQueryResult(true,"Produtos Encontrados",retornoProdutos);

        }
    
    
    }
}
