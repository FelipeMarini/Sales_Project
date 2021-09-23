using Flunt.Notifications;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Queries.Usuario;
using Ofertas.Dominio.Repositories;
using System.Linq;
using static Ofertas.Dominio.Queries.Usuario.ObterDadosQuery;

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

            var retornoUsuario = usuarioRepositorio.BuscarUsuarioPorId(query.IdBuscaUsuario);
                

            if (retornoUsuario == null)
            {
                return new GenericQueryResult(false, "Usuário não encontrado", null);
            }
          
            return new GenericQueryResult(true, "Usuário encontrado", retornoUsuario );
        }
    
    
    }

}
