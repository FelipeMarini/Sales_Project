using Microsoft.AspNetCore.Mvc;
using Ofertas.Comum.Commands;
using Ofertas.Dominio.Commands.Usuario;
using Ofertas.Dominio.Handlers.Usuario;

namespace Ofertas.Api.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [Route("signup")]
        [HttpPost]
        public GenericCommandResult SignUp(CadastrarContaCommand command, CadastrarContaHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }




    }
}
