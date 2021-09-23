using Flunt.Notifications;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Queries.ReservaProduto;
using Ofertas.Dominio.Repositories;


namespace Ofertas.Dominio.Handlers.ReservaProdutos
{
    public class MostrarReservaHandle : Notifiable<Notification>, IHandlerQuery<MostrarReservaQuery>
    {

        private readonly IReservaProdutoRepositorio reservaRepositorio;


        public MostrarReservaHandle(IReservaProdutoRepositorio _reservaRepositorio)
        {
            reservaRepositorio = _reservaRepositorio;
        }

        public IQueryResult Handler(MostrarReservaQuery query)
        {


            var retornoReserva = reservaRepositorio.MostrarReserva(query.IdUsuario);


            return new GenericQueryResult(true, "Reserva encontrada", retornoReserva);

        }

    }

}

