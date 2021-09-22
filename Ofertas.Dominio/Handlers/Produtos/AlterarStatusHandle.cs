using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Dominio.Commands.Produtos;
using Ofertas.Dominio.Repositories;

namespace Ofertas.Dominio.Handlers.Produtos
{
    public class AlterarStatusHandle : Notifiable<Notification>, IHandlerCommand<AlterarStatusCommand>
    {

        private readonly IProdutoRepositorio produtoRepositorio;

        public AlterarStatusHandle(IProdutoRepositorio _produtoRepositorio)
        {

            produtoRepositorio = _produtoRepositorio;

        }


        public ICommandResult Handler(AlterarStatusCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false,"Dados do produto inválidos",command.Notifications);
            }

            var p1 = produtoRepositorio.BuscarProdutoPorStatus(command.StatusPreco);

            if (p1 == null)
            {
                return new GenericCommandResult(false,"Produto não encontrado",null);
            }


            return new GenericCommandResult(true,"Status alterado com sucesso","Sucesso");


        }
    
    
    
    }
}
