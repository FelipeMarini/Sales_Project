using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Dominio.Commands.Autenticacao;
using Ofertas.Dominio.Repositories;

namespace Ofertas.Dominio.Handlers.Autenticacao
{
    public class AlterarSenhaHandle : Notifiable<Notification>, IHandlerCommand<AlterarSenhaCommand>
    {

        private readonly IUsuarioRepositorio usuarioRepositorio;

        public AlterarSenhaHandle(IUsuarioRepositorio _usuarioRepositorio)
        {
            usuarioRepositorio = _usuarioRepositorio;
        }

        public ICommandResult Handler(AlterarSenhaCommand command)
        {
            
            
            // valida os dados em seu formato correto
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false,"Dados de usuário informados corretamente",command.Notifications);
            }
            
             

            var usuario = usuarioRepositorio.BuscarUsuarioPorEmail(command.Email);


            // verifica o email informado
            if (usuario == null)
            {
                return new GenericCommandResult(false,"Usuário não encontrado",null);
            }


            usuarioRepositorio.AlterarSenha(usuario.Senha);
            

            return new GenericCommandResult(true,"Senha alterada com sucesso","Sucesso");

        }
    
    
    }
}
