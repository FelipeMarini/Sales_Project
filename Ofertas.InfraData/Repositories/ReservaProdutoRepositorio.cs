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

        
        public IReadOnlyCollection<ReservaProduto> ListarReservas(Guid idUsuario)
        {
            return (List<ReservaProduto>)ctx.ListaReservas
                    
                    .Where(r => r.Usuario.Id == idUsuario);
        }

        
        public ReservaProduto MostrarReserva(Guid idReserva)
        {
           return ctx.ListaReservas.FirstOrDefault(x => x.Id == idReserva);
        }

        
        
        public void ReservarProduto(ReservaProduto reserva, Usuario usuario, Produto produto, int quantidade)
        {
            
            if (produto.StatusReserva == 0) // status livre
            {
                // status passa a ser reservado
                produto.StatusReserva = (Comum.Enum.EnStatusReservaProduto)1;

                reserva.Usuario.Id = usuario.Id;
                reserva.Produto.Id = produto.Id;

                // não reservar quantidade além da disponível
                if (quantidade <= produto.Quantidade)
                {
                
                    // quantidade do produto a ser reservado
                    reserva.Quantidade = quantidade;

                }

                else
                {
                    new GenericCommandResult(false, "Quantidade indisponível", null);
                }

                ctx.AdicionarReserva(reserva);
            }
            
            else
            {
                new GenericCommandResult(false,"Produto já reservado",null);
            }

        }

        
    
    }


}
