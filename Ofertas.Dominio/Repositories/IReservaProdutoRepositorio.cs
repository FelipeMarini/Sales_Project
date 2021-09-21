using Ofertas.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Ofertas.Dominio.Repositories
{
    public interface IReservaProdutoRepositorio
    {

        /// <summary>
        /// Usuário realiza a reserva de um determinado produto
        /// </summary>
        /// <param name="usuario">objeto contendo os dados do usuário que efetua a reserva</param>
        /// <param name="produto">objeto contendo os dados do produto que será reservado</param>
        void ReservarProduto( Usuario usuario, Produto produto);


        /// <summary>
        /// Mostra uma determinada reserva que foi feita
        /// </summary>
        /// <param name="idReserva">id da reserva que foi feita</param>
        /// <returns></returns>
        ReservaProduto MostrarReserva(Guid idReserva);


        /// <summary>
        /// Lista todas as reservas de um determinado usuário
        /// </summary>
        /// <param name="idUsuario">id do usuário que possui as reservas</param>
        /// <returns></returns>
        List<ReservaProduto> ListarReservas(Guid idUsuario);


    }
}
