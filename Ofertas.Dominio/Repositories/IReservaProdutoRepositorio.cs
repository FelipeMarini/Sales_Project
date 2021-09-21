using Ofertas.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Ofertas.Dominio.Repositories
{
    public interface IReservaProdutoRepositorio
    {

        /// <summary>
        /// Reserva um produto (alimento ou roupa) para o cliente
        /// </summary>
        /// <param name="reserva">dados do produto e do usuário para efetuar a reserva na aplicação</param>
        void ReservarProduto(ReservaProduto reserva, Usuario usuario, Produto produto);


        /// <summary>
        /// Lista as reservas de um determinado usuário
        /// </summary>
        /// <param name="idUsuario">id do usuário</param>
        /// <returns></returns>
        List<ReservaProduto> ListarReservas(Guid idUsuario);


    }
}
