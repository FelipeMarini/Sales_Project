using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Dominio.Commands.Usuarios;
using Ofertas.Dominio.Repositories;

namespace Ofertas.Dominio.Handlers.Usuarios
{
    public class ExcluirUsuarioHandle : Notifiable<Notification>, IHandlerCommand<ExcluirUsuarioCommand>
    {

        private readonly IUsuarioRepositorio usuarioRepositorio;

        public ExcluirUsuarioHandle(IUsuarioRepositorio _usuarioRepositorio)
        {
            usuarioRepositorio = _usuarioRepositorio;
        }

        public ICommandResult Handler(ExcluirUsuarioCommand command)
        {

            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false,"Dados do usuário inválidos",command.Notifications);
            }

            
            Usuario user = new Usuario(command.Nome,command.Email,command.Senha,command.TipoUsuario);

            
            usuarioRepositorio.ExcluirUsuario(user.Id);

            
            return new GenericCommandResult(true,"Usuário excluído com sucesso","Sucesso");
            
        }
    
    
    }
}
