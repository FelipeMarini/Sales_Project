﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Commands.ReservaProdutos;
using Ofertas.Dominio.Handlers.ReservaProdutos;
using Ofertas.Dominio.Queries.ReservaProduto;

namespace Ofertas.Api.Controllers
{
    [Route("v1/reservation")]
    [ApiController]
    public class ReservaProdutoController : ControllerBase
    {


        [Route("bookproduct")]
        [HttpPost]
        [Authorize]
        public GenericCommandResult BookProduct(ReservarProdutoCommand command, [FromServices] ReservarProdutoHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        
        [Route("getreservation")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public GenericQueryResult GetOneReservation(MostrarReservaQuery query, [FromServices] MostrarReservaHandle handle)
        {
            return (GenericQueryResult)handle.Handler(query);
        }


        [Route("getallreservations")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public GenericQueryResult GetReservations(ListarReservasQuery query, [FromServices] ListarReservasHandle handle)
        {
            return (GenericQueryResult)handle.Handler(query);
        }




    }
}
