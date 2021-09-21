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

         public ReservaProduto MostrarReserva(Guid idReserva)
         {
            return ctx.ListaReservas.FirstOrDefault(x => x.Id == idReserva);
         }

        
        public void ReservarProduto( Usuario usuario, Produto produto)
        {
            

            

        }


    }


}
