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
        /// <param name="reserva">objeto contendo os dados da reserva (id do usuario e produto)</param>
        /// <param name="usuario">objeto contendo os dados do usuário que efetua a reserva</param>
        /// <param name="produto">objeto contendo os dados do produto que será reservado</param>
        void ReservarProduto(ReservaProduto reserva, Usuario usuario, Produto produto, int quantidade);


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
        IReadOnlyCollection<ReservaProduto> ListarReservas(Guid idUsuario);


        /// <summary>
        /// Busca o produto através do seu id
        /// </summary>
        /// <param name="id">id do produto buscado</param>
        /// <returns>Retorna o produto buscado pelo id</returns>
        Produto BuscarProdutoPorId(Guid id);


        /// <summary>
        /// Busca o usuário através do seu id
        /// </summary>
        /// <param name="id">id do usuário buscado</param>
        /// <returns>Retorna o usuário buscado</returns>
        Usuario BuscarUsuarioPorId(Guid id);


    }
}
