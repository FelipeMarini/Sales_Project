using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Dominio.Commands.Produtos;
using Ofertas.Dominio.Repositories;

namespace Ofertas.Dominio.Handlers.Produtos
{
    public class AlterarProdutoHandle : Notifiable<Notification>, IHandlerCommand<AlterarProdutoCommand>
    {

        private readonly IProdutoRepositorio produtoRepositorio;


        public AlterarProdutoHandle(IProdutoRepositorio _produtoRepositorio)
        {

            produtoRepositorio = _produtoRepositorio;

        }


        public ICommandResult Handler(AlterarProdutoCommand command)
        {

            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false,"Dados incorretos do produto",command.Notifications);
            }

            
            var produtoBuscado = produtoRepositorio.BuscarProdutoPorId(command.Produto.Id);

            if (produtoBuscado == null)
            {
                return new GenericCommandResult(false, "Produto não encontrado", null);
            }


            produtoRepositorio.AlterarProduto(command.Produto);
            

            return new GenericCommandResult(true,"Produto alterado com sucesso","Sucesso");


        }
    
    
    }
}
