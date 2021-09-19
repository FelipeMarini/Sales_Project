using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Enum;

namespace Ofertas.Dominio.Commands.Produto
{
    public class AlterarStatusCommand : Notifiable<Notification>, ICommand
    {
        public AlterarStatusCommand(EnStatusProduto status)
        {
            Status = status;
        }

        public EnStatusProduto Status { get; set; }


        public void Validar()
        {
            AddNotifications(
                
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(Status,"Status","O status do produto não pode ser nulo")
                

            );
        
        }
        
    
    }
}
