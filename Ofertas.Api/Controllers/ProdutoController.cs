using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ofertas.Comum;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Enum;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Commands.Produtos;
using Ofertas.Dominio.Handlers.Produtos;
using Ofertas.Dominio.Queries.Produto;
using System;
using System.Linq;
using System.Security.Claims;

namespace Ofertas.Api.Controllers
{
    
    [Route("v1/package")]
    [ApiController]
    
    public class ProdutoController : ControllerBase 
    {
        
        [Route("registerproduct")]
        [HttpPost]
        [Authorize(Roles = "Admin")]        
        public GenericCommandResult RegisterProduct(CadastrarProdutoCommand command, [FromServices] CadastrarProdutoHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }


        [Route("getallproducts")]
        [HttpGet]
        [Authorize]
        public GenericQueryResult GetAllProducts( [FromServices] ListarProdutosHandle handle)
        {
            ListarProdutosQuery query = new ListarProdutosQuery();

            // busca nos dados do usuário o seu tipo e armazena na variável
            var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(t => t.Type == ClaimTypes.Role);

            if (tipoUsuario.Value.ToString() == EnTipoUsuario.Admin.ToString())
            {
                query.SituacaoReserva = EnStatusReservaProduto.Reservado;
            }

            return (GenericQueryResult)handle.Handler(query);
        }

        [Route("alterproduct")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public GenericCommandResult ChangeProduct(AlterarProdutoCommand command, [FromServices] AlterarProdutoHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        

        [Route("getproduct")]
        [HttpGet("{id}")]
        public GenericQueryResult GetProduct(Guid id, BuscarProdutoQuery query, [FromServices] BuscarProdutoHandle handle)
        {

            query.IdBuscaProduto = id;

            return (GenericQueryResult)handle.Handler(query);
        }


        [Route("deleteproduct")]
        [HttpDelete]
        public GenericCommandResult DeleteProduct(ExcluirProdutoCommand command, [FromServices] ExcluirProdutoHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }
                       



    }


}
