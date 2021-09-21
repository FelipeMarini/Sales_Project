using Flunt.Notifications;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Queries.Usuario;
using Ofertas.Dominio.Repositories;
using System.Linq;
using static Ofertas.Dominio.Queries.Usuario.ListarUsuariosQuery;

namespace Ofertas.Dominio.Handlers.Usuarios
{
    public class ListarUsuariosHandle : Notifiable<Notification>, IHandlerQuery<ListarUsuariosQuery>
    {

        private readonly IUsuarioRepositorio usuarioRepositorio;


        public ListarUsuariosHandle(IUsuarioRepositorio _usuarioRepositorio)
        {
            usuarioRepositorio = _usuarioRepositorio;
        }


        public IQueryResult Handler(ListarUsuariosQuery query)
        {

            var usuarios = usuarioRepositorio.ListarUsuarios(query.Tipo);

            var retornoUsuarios = usuarios.Select(

                x =>
                {

                    return new ListarUsuariosResult()
                    {
                        Id = x.Id,
                        DataCriacao = x.DataCriacao,
                        Nome = x.Nome,
                        Email = x.Email,
                        TipoUsuario = x.TipoUsuario
                    };

                }

                );


            return new GenericQueryResult(true,"Usuários encontrados",retornoUsuarios);

        }
    
    }

}
