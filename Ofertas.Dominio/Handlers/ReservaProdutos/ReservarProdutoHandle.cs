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
                return new GenericCommandResult(false,"Dados inválidos do produto",command.Notifications);
            }

            
            Usuario usuario = new Usuario
                (
                    command.Nome,
                    command.Email,
                    command.Senha,
                    command.TipoUsuario
                );

            
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

            ReservaProduto reserva = new ReservaProduto
                (
                    command.Nome,
                    command.Email,
                    command.Titulo,
                    command.Imagem,
                    command.Descricao,
                    command.StatusPreco,
                    command.Quantidade,
                    command.IdUsuario,
                    command.IdProduto
                );

            
            reservaRepositorio.ReservarProduto(reserva,usuario,produto);

            
            return new GenericCommandResult(true,"Produto reservado com sucesso","Sucesso");
        
        }
    
    
    }
}
