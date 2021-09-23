using Ofertas.Comum.Commands;
using Ofertas.Dominio;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositories;
using Ofertas.InfraData.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ofertas.InfraData.Repositories
{
    public class ReservaProdutoRepositorio : IReservaProdutoRepositorio
    {

        private readonly OfertasContext ctx;

        public ReservaProdutoRepositorio(OfertasContext _ctx)
        {
            ctx = _ctx;
        }

        
        public IReadOnlyCollection<ReservaProduto> ListarReservas(Guid idUsuario)
        {
            return (List<ReservaProduto>)ctx.Reservas

                    .Where(r => r.Usuario.Id == idUsuario);
        }

        
        public ReservaProduto MostrarReserva(Guid idReserva)
        {
           return ctx.Reservas.FirstOrDefault(x => x.Id == idReserva);
        }


        public Produto BuscarProdutoPorId(Guid id)
        {
            return ctx.Produtos.FirstOrDefault(x => x.Id == id);
        }


        public Usuario BuscarUsuarioPorId(Guid id)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Id == id);
        }


        public void ReservarProduto(ReservaProduto reserva, Usuario usuario, Produto produto, int quantidade)
        {
            
            if (produto.StatusReserva == 0) // status livre
            {
                // status passa a ser reservado
                

                reserva.IdUsuario = usuario.Id;
                reserva.IdProduto = produto.Id;

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

                ctx.Reservas.Add(reserva);
            }
            
            else
            {
                new GenericCommandResult(false,"Produto já reservado",null);
            }

        }

        
    
    }


}
