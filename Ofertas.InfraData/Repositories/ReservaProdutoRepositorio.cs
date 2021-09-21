using Ofertas.Comum.Commands;
using Ofertas.Dominio;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ofertas.InfraData.Repositories
{
    public class ReservaProdutoRepositorio : IReservaProdutoRepositorio
    {

        private readonly ReservaProduto ctx;

        public ReservaProdutoRepositorio(ReservaProduto _ctx)
        {
            ctx = _ctx;
        }

        public List<ReservaProduto> ListarReservas(Guid idUsuario)
        {
            return (List<ReservaProduto>)ctx.ListaReservas
                    
                    .Where(r => r.IdUsuario == idUsuario);
        }

        
        public void ReservarProduto(ReservaProduto reserva, Usuario usuario, Produto produto)
        {
            
            var situacaoReserva = produto.StatusReserva;

            if (situacaoReserva == 0)   // status de reserva livre (EnStatusReservaProduto = 0)
            {
                // status de reserva do produto passa a ser reservado (EnStatusReservaProduto = 1)
                // consigo mudar porque deixei StatusReserva sem "private set" em Produto.cs
                produto.StatusReserva = (Comum.Enum.EnStatusReservaProduto)1;

                reserva.IdUsuario = usuario.Id;
                reserva.Nome = usuario.Nome;
                reserva.Email = usuario.Email;

                reserva.IdProduto = produto.Id;
                reserva.Titulo = produto.Titulo;
                reserva.Imagem = produto.Imagem;
                reserva.Descricao = produto.Descricao;
                reserva.StatusPreco = produto.StatusPreco;
                reserva.Quantidade = produto.Quantidade;

                reserva.AdicionarReserva(reserva);                
            }
            
            else 
            { 
                new GenericCommandResult(false, "Produto já está reservado", null); 
            }

        }


    }


}
