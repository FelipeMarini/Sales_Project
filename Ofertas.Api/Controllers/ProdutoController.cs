using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ofertas.Comum;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Enum;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Commands.Produto;
using Ofertas.Dominio.Commands.Produtos;
using Ofertas.Dominio.Commands.ReservaProdutos;
using Ofertas.Dominio.Handlers.Produtos;
using Ofertas.Dominio.Handlers.ReservaProdutos;
using Ofertas.Dominio.Queries.Produto;
using Ofertas.Dominio.Queries.ReservaProduto;
using System.Linq;
using System.Security.Claims;

namespace Ofertas.Api.Controllers
{
    
    [Route("v1/package")]
    [ApiController]
    
    public class ProdutoController : ControllerBase 
    {

        [HttpPost]
        [Authorize(Roles = "Admin")]        
        public GenericCommandResult RegisterProduct(CadastrarProdutoCommand command, [FromServices] CadastrarProdutoHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }  


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

        
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public GenericCommandResult ChangeProduct(AlterarProdutoCommand command, [FromServices] AlterarProdutoHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public GenericCommandResult ChangeStatus(AlterarStatusCommand command, [FromServices] AlterarStatusHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }


        [HttpGet]
        public GenericQueryResult GetProduct(BuscarProdutoQuery query, [FromServices] BuscarProdutoHandle handle)
        {
            return (GenericQueryResult)handle.Handler(query);
        }

        
        
        [HttpDelete]
        public GenericCommandResult DeleteProduct(ExcluirProdutoCommand command, [FromServices] ExcluirProdutoHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }
                       



    }


}
