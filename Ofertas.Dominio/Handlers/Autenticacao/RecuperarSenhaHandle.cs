using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Utils;
using Ofertas.Dominio.Commands.Autenticacao;
using Ofertas.Dominio.Repositories;

namespace Ofertas.Dominio.Handlers.Autenticacao
{
    public class RecuperarSenhaHandle : Notifiable<Notification>, IHandlerCommand<RecuperarSenhaCommand>
    {
        private IUsuarioRepositorio _usuarioRepositorio { get; set; }
        
        public RecuperarSenhaHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }



        public ICommandResult Handler(RecuperarSenhaCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false,"Informe os dados de usuário corretamente",command.Notifications);
            }

            var usuario = _usuarioRepositorio.BuscarUsuarioPorEmail(command.Email);

            if (usuario == null)
            {
                return new GenericCommandResult(false,"Dados Inválidos",null);
            }
            

            return new GenericCommandResult(true,"Senha recuperada com sucesso",usuario);

        }
    
    }
}
