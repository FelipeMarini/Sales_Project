using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Commands;

namespace Ofertas.Dominio.Commands.Autenticacao
{
    public class RecuperarSenhaCommand : Notifiable<Notification>, ICommand
    {
        public RecuperarSenhaCommand(string email, string senha)
        {
            Email = email;
        }

        public string Email { get; set; }


        public void Validar()
        {
            AddNotifications(
                
                new Contract<Notification>()
                    .Requires()
                    .IsEmail(Email,"Email","O formato de email está incorreto")
                
            );
        
        }
    
    
    }
}
