using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Dominio.Commands.Autenticacao;
using Ofertas.Dominio.Repositories;

namespace Ofertas.Dominio.Handlers.Autenticacao
{
    public class AlterarSenhaHandle : Notifiable<Notification>, IHandlerCommand<AlterarSenhaCommand>
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AlterarSenhaHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handler(AlterarSenhaCommand command)
        {
            // valida os dados em seu formato correto
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false,"Dados de usuário informados corretamente",command.Notifications);
            }

            var usuario = _usuarioRepositorio.BuscarUsuarioPorEmail(command.Email);

            // verifica se a nova senha continua igual a anterior também?
            if (usuario == null || command.Senha == usuario.Senha)
            {
                return new GenericCommandResult(false,"Dados Inválidos",null);
            }


            


            return new GenericCommandResult(true,"Senha alterada com sucesso",usuario);

        }
    
    
    }
}
