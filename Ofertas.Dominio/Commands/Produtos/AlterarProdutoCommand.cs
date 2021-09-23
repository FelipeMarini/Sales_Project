using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Enum;
using Ofertas.Dominio.Entidades;
using System;

namespace Ofertas.Dominio.Commands.Produtos
{
    public class AlterarProdutoCommand : Notifiable<Notification>, ICommand
    {
        public AlterarProdutoCommand()
        {
                
        }

        public AlterarProdutoCommand(Produto produto)
        {
            Produto = produto;
        }


        public Produto Produto { get; set; }


        public void Validar()
        {
            AddNotifications(

                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(Produto, "Produto", "Dados do produto não pode ser nula")
            );

        }
    
        
    }
}
