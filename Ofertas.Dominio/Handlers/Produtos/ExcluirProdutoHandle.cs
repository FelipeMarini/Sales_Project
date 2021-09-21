using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Dominio.Commands.Produtos;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositories;

namespace Ofertas.Dominio.Handlers.Produtos
{
    public class ExcluirProdutoHandle : Notifiable<Notification>, IHandlerCommand<ExcluirProdutoCommand>
    {

        private readonly IProdutoRepositorio produtoRepositorio;


        public ExcluirProdutoHandle(IProdutoRepositorio _produtoRepositorio)
        {
            produtoRepositorio = _produtoRepositorio;
        }


        public ICommandResult Handler(ExcluirProdutoCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false,"Dados do produto inválidos",command.Notifications);
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

            
            produtoRepositorio.ExcluirProduto(produto.Id);

            
            return new GenericCommandResult(true,"Produto excluído com sucesso","Sucesso");

        }
    
    
    }

}
