using Flunt.Notifications;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Queries.ReservaProduto;
using Ofertas.Dominio.Repositories;
using System.Linq;
using static Ofertas.Dominio.Queries.ReservaProduto.ListarReservasQuery;

namespace Ofertas.Dominio.Handlers.ReservaProdutos
{
    public class ListarReservasHandle : Notifiable<Notification>, IHandlerQuery<ListarReservasQuery>
    {

        private readonly IReservaProdutoRepositorio reservaRepositorio;


        public ListarReservasHandle(IReservaProdutoRepositorio _reservaRepositorio)
        {
            reservaRepositorio = _reservaRepositorio;
        }

        public IQueryResult Handler(ListarReservasQuery query)
        {


            var reservas = reservaRepositorio.ListarReservas(query.idUsuario);

            
            var retornoReservas = reservas.Select(

                    x =>

                    {                    
                        return new ListarReservasResult()
                        {
                            // reserva
                            Id = x.Id,
                            DataCriacao = x.DataCriacao,
                            Quantidade = x.Quantidade,
                            
                            // produto
                            Titulo = x.Produto.Titulo,
                            Imagem = x.Produto.Imagem,
                            Descricao = x.Produto.Descricao,
                            StatusPreco = x.Produto.StatusPreco,
                            TipoProduto = x.Produto.TipoProduto,
                            
                            // usuário
                            Nome = x.Usuario.Nome,
                            Email = x.Usuario.Email

                        };
                
                    }

                );


            return new GenericQueryResult(true, "Reservas encontradas", retornoReservas);

        }

    }

}
