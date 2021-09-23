using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Dominio.Commands.ReservaProdutos;
using Ofertas.Dominio.Entidades;
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
                return new GenericCommandResult(false,"Dados inválidos para reserva",command.Notifications);
            }


            var usuario = reservaRepositorio.BuscarUsuarioPorId(command.IdUsuario);

            if (usuario == null)
            {
                return new GenericCommandResult(false,"Usuário não encontrado",null);
            }

            var produto = reservaRepositorio.BuscarProdutoPorId(command.IdProduto);

            if (produto == null)
            {
                return new GenericCommandResult(false, "Produto não encontrado", null);
            }



            ReservaProduto reserva = new ReservaProduto
                (
                    command.Quantidade,
                    command.IdUsuario,
                    command.IdProduto
                );


            reserva.IdUsuario = usuario.Id;
            reserva.IdProduto = produto.Id; 
            
            var quantidade = command.Quantidade;

            
            reservaRepositorio.ReservarProduto(reserva,usuario,produto,quantidade);

            
            return new GenericCommandResult(true,"Produto reservado com sucesso","Sucesso");
        
        }
    
    
    }
}
