using Flunt.Notifications;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Queries.Usuario;
using Ofertas.Dominio.Repositories;

namespace Ofertas.Dominio.Handlers.Usuarios
{
    public class ObterDadosHandle : Notifiable<Notification>, IHandlerQuery<ObterDadosQuery>
    {

        private readonly IUsuarioRepositorio usuarioRepositorio;


        public ObterDadosHandle(IUsuarioRepositorio _usuarioRepositorio)
        {

            usuarioRepositorio = _usuarioRepositorio;

        }


        public IQueryResult Handler(ObterDadosQuery query)
        {
            var usuario = usuarioRepositorio.BuscarUsuarioPorId(query.IdBuscaUsuario);

            var retornoUsuario = usuario.ToString();

            return new GenericQueryResult(true, "Usuário encontrado", retornoUsuario);
        }
    
    
    }

}
