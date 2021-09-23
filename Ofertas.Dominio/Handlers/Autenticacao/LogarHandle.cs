using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Utils;
using Ofertas.Dominio.Commands.Autenticacao;
using Ofertas.Dominio.Repositories;

namespace Ofertas.Dominio.Handlers.Autenticacao
{
    public class LogarHandle : Notifiable<Notification>, IHandlerCommand<LogarCommand>
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LogarHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handler(LogarCommand command)
        {
            command.Validar();

            if (!command.IsValid == true)
            {
                return new GenericCommandResult(false,"Informe os dados de usuário corretamente",command.Notifications);
            }

            
            // verifica se existe um usuário cadastrado
            var usuario = _usuarioRepositorio.BuscarUsuarioPorEmail(command.Email);

            if (usuario == null)
            {
                return new GenericCommandResult(false,"Dados Inválidos",null);
            }


            
            if (!Senha.ValidarHash(command.Senha, usuario.Senha))
            {
                return new GenericCommandResult(false, "Dados Inválidos", null);
            }

            

            return new GenericCommandResult(true,"Usuário logado com sucesso", usuario);

        }
    
    }
}
