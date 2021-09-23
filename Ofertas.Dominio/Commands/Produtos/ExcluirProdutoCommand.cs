using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Commands;
using Ofertas.Dominio.Entidades;
using System;

namespace Ofertas.Dominio.Commands.Produtos
{
    public class ExcluirProdutoCommand : Notifiable<Notification>, ICommand
    {


        public ExcluirProdutoCommand(Guid idProduto)
        {
            IdProduto = idProduto;
        }


        public Guid IdProduto { get; set; }


        public void Validar()
        {
            AddNotifications(

                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(IdProduto, "ID Produto", "ID do produto não pode ser nulo")
            );

        }

    }
}
