using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Commands;

namespace Ofertas.Dominio.Commands.ReservaProdutos
{
    public class ReservarProdutoCommand : Notifiable<Notification>, ICommand
    {

        // só isso está bom ou preciso colocar mais propriedades?
        public ReservarProdutoCommand(int quantidade)
        {
            Quantidade = quantidade;
        }

        public int Quantidade { get; set; }

        public void Validar()
        {
            AddNotifications(
            
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(Quantidade,"Quantidade","Quantidade não pode ser nula")

            );
        }
    }
}
