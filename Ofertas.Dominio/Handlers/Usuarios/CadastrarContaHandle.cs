using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Utils;
using Ofertas.Dominio.Commands.Usuarios;
using Ofertas.Dominio.Repositories;

namespace Ofertas.Dominio.Handlers.Users


{
    public class CadastrarContaHandle : Notifiable<Notification>, IHandlerCommand<CadastrarContaCommand>
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        
        // injeção de dependência para garantir que haja instância do repositório de usuário com os métodos
        public CadastrarContaHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        
        public ICommandResult Handler(CadastrarContaCommand command)
        {
            command.Validar(); // validar os dados de usuário com o comando recebido como argumento 

            if (!command.IsValid)
            {
                return new GenericCommandResult
                    (
                        false, 
                        "Informe os dados de usuário corretamente",
                        command.Notifications
                    );
            }

            var userExiste = _usuarioRepositorio.BuscarUsuarioPorEmail(command.Email);

            if (userExiste != null)
            {
                return new GenericCommandResult(false,"Email já cadastrado","Informe um email diferente");
            }


            command.Senha = Senha.Criptografar(command.Senha);

            //Usuario u1 = new Usuario(command.Nome, command.Email, command.Senha, command.TipoUsuario);




            return new GenericCommandResult(true,"Usuário criado com sucesso","Token");


        }

    }

}
