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

            
            Usuario usuario = new Usuario
                (
                    command.Usuario.Nome,
                    command.Usuario.Email,
                    command.Usuario.Senha,
                    command.Usuario.TipoUsuario
                );

            
            Produto produto = new Produto
                (
                    command.Produto.Titulo,
                    command.Produto.Imagem,
                    command.Produto.Descricao,
                    command.Produto.StatusPreco,
                    command.Produto.TipoProduto,
                    command.Produto.StatusReserva,
                    command.Produto.Quantidade
                );

            ReservaProduto reserva = new ReservaProduto
                (
                    command.Quantidade,
                    command.Usuario.Id,
                    command.Produto.Id
                );

            
            var quantidade = command.Quantidade;

            
            reservaRepositorio.ReservarProduto(reserva,usuario,produto,quantidade);

            
            return new GenericCommandResult(true,"Produto reservado com sucesso","Sucesso");
        
        }
    
    
    }
}
