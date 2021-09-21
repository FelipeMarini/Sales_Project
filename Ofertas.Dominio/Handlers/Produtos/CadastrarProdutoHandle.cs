using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Dominio.Commands.Produtos;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositories;

namespace Ofertas.Dominio.Handlers.Produtos
{
    public class CadastrarProdutoHandle : Notifiable<Notification>, IHandlerCommand<CadastrarProdutoCommand>
    {

        private readonly IProdutoRepositorio produtoRepositorio;


        public CadastrarProdutoHandle(IProdutoRepositorio _produtoRepositorio)
        {
            produtoRepositorio = _produtoRepositorio;
        }


        public ICommandResult Handler(CadastrarProdutoCommand command)
        {

            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false,"Dados incorretos do produto",command.Notifications);
            }


            var produtoExiste1 = produtoRepositorio.BuscarProdutoPorTitulo(command.Titulo);

            if (produtoExiste1 != null)
            {
                return new GenericCommandResult(false,"Produto já cadastrado",null);
            }

            
            var produtoExiste3 = produtoRepositorio.BuscarProdutoPorDescricao(command.Descricao);

            if (produtoExiste3 != null)
            {
                return new GenericCommandResult(false, "Produto já cadastrado", null);
            }


            Produto produto = new Produto
                (
                    command.Titulo,
                    command.Imagem,
                    command.Descricao,
                    command.StatusPreco,
                    command.TipoProduto,
                    command.StatusReserva,
                    command.Quantidade
                );


            produtoRepositorio.CadastrarProduto(produto);

            
            return new GenericCommandResult(true, "Produto cadastrado com sucesso", produto);          

        }
    
    
    
    }
}
