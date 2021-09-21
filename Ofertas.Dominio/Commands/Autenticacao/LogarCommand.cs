using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Commands;

namespace Ofertas.Dominio.Commands.Autenticacao
{
    public class LogarCommand : Notifiable<Notification>, ICommand
    {
        public LogarCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        
        public string Email { get; set; }

        public string Senha { get; set; }


        public void Validar()
        {
            AddNotifications(
                
                new Contract<Notification>()
                    .Requires()
                    .IsEmail(Email,"Email","O formato de email está incorreto")
                    .IsGreaterThan(Senha,7,"Senha","A senha precisa ter no mínimo 8 caracteres")
                
            );
        }
    
    }

}
