using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Commands;
using Ofertas.Dominio.Entidades;


namespace Ofertas.Dominio.Commands.ReservaProdutos
{
    public class ReservarProdutoCommand : Notifiable<Notification>, ICommand
    {

        public ReservarProdutoCommand()
        {

        }

        public ReservarProdutoCommand(int quantidade)
        {
            Quantidade = quantidade;
        }       

       
        public Usuario Usuario { get; set; }

        public Produto Produto { get; set; }

        public int Quantidade { get; set; }


        public void Validar()
        {
            AddNotifications(

                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(Quantidade, "Quantidade", "Quantidade não pode ser nula")
                    .IsNotNull(Usuario, "Usuário", "Usuário não pode ser nulo")
                    .IsNotNull(Produto, "Produto", "Produto não pode ser nulo")
            );

        }

    
    }

}
