using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Queries;
using Ofertas.Dominio;
using Ofertas.Dominio.Commands.Autenticacao;
using Ofertas.Dominio.Commands.ReservaProdutos;
using Ofertas.Dominio.Commands.Usuarios;
using Ofertas.Dominio.Handlers.Autenticacao;
using Ofertas.Dominio.Handlers.ReservaProdutos;
using Ofertas.Dominio.Handlers.Usuarios;
using Ofertas.Dominio.Queries.ReservaProduto;
using Ofertas.Dominio.Queries.Usuario;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ofertas.Api.Controllers
{
    
    [Route("v1/account")]
    [ApiController]
    
    public class UsuarioController : ControllerBase  // vou precisar de um controller para as reservas?
    {

        private string GenerateJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OfertasKeySenai2021"));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(ClaimTypes.Role, userInfo.TipoUsuario.ToString()),
                new Claim("role", userInfo.TipoUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())
            };

            var token = new JwtSecurityToken                
                (
                    "Ofertas",
                    "Ofertas",
                    claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials
                );


            return  new JwtSecurityTokenHandler().WriteToken(token);

        }



        [Route("signup")]
        [HttpPost]
        public GenericCommandResult SignUp(CadastrarContaCommand command, [FromServices] CadastrarContaHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }



        [Route("signin")]
        [HttpPost]
        public GenericCommandResult SignIn(LogarCommand command, [FromServices] LogarHandle handle)
        {
            var resultado = (GenericCommandResult)handle.Handler(command);

            if (resultado.Sucesso)
            {
                var token = GenerateJSONWebToken((Usuario)resultado.Data);

                return new GenericCommandResult(resultado.Sucesso, resultado.Mensagem, new {Token = token} );
            }

            return new GenericCommandResult(false, resultado.Mensagem, resultado.Data);

        }

        [Route("changepwd")]  // precisa aqui?
        [HttpPut]
        [Authorize]
        public GenericCommandResult ChangePassword(AlterarSenhaCommand command, [FromServices] AlterarSenhaHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }


        [Route("recoverpwd")]
        [HttpGet]
        [Authorize]
        public GenericCommandResult RecoverPassword(RecuperarSenhaCommand command, [FromServices] RecuperarSenhaHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }


        [HttpDelete]
        [Authorize(Roles ="Admin")]
        public GenericCommandResult DeleteUser(ExcluirUsuarioCommand command, [FromServices] ExcluirUsuarioHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public GenericQueryResult GetAllUsers(ListarUsuariosQuery query, [FromServices] ListarUsuariosHandle handle)
        {
            return (GenericQueryResult)handle.Handler(query);
        }


        [HttpGet]
        [Authorize]
        public GenericQueryResult GetUser(ObterDadosQuery query, [FromServices] ObterDadosHandle handle)
        {
            return (GenericQueryResult)handle.Handler(query);
        }


        // reservas

        [HttpPost]
        public GenericCommandResult BookProduct(ReservarProdutoCommand command, [FromServices] ReservarProdutoHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }



        [HttpGet]
        public GenericQueryResult GetReservations(ListarReservasQuery query, [FromServices] ListarReservasHandle handle)
        {
            return (GenericQueryResult)handle.Handler(query);
        }



    }
}
