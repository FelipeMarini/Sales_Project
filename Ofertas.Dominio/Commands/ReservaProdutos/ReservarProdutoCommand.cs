using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Commands;
using Ofertas.Dominio.Entidades;
using System;

namespace Ofertas.Dominio.Commands.ReservaProdutos
{
    public class ReservarProdutoCommand : Notifiable<Notification>, ICommand
    {

        public ReservarProdutoCommand()
        {

        }

        public ReservarProdutoCommand(Guid idUsuario, Guid idProduto, int quantidade)
        {
            IdUsuario = idUsuario;
            IdProduto = idProduto;
            Quantidade = quantidade;

        }       

       
        public Guid IdUsuario { get; set; }

        public Guid IdProduto { get; set; }

        public int Quantidade { get; set; }


        public void Validar()
        {
            AddNotifications(

                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(Quantidade, "Quantidade", "Quantidade não pode ser nula")
         
            );

        }

    
    }

}
