using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Dominio.Commands.ReservaProdutos;
using Ofertas.Dominio.Repositories;

namespace Ofertas.Dominio.Handlers.ReservaProdutos
{
    public class ReservarProdutoHandle : Notifiable<Notification>, IHandlerCommand<ReservarProdutoCommand>
    {

        private readonly IReservaProdutoRepositorio reservaRepositorio;


        public ReservarProdutoHandle(IReservaProdutoRepositorio _reservaRepositorio)
        {

            reservaRepositorio = _reservaRepositorio;

        }


        public ICommandResult Handler(ReservarProdutoCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false,"Dados inválidos do produto",command.Notifications);
            }

           //reservaRepositorio.ReservarProduto();

            return new GenericCommandResult(true,"Produto reservado com sucesso","Sucesso");
        
        }
    
    
    }
}
