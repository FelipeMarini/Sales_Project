using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum;
using System;
using System.Collections.Generic;

namespace Ofertas.Dominio.Entidades
{
    public class ReservaProduto : Base  // Os Guid´s de usuário e produto irei usar no Controller
    {

        public ReservaProduto(int quantidade, Guid idUsuario, Guid idProduto)
        {
            AddNotifications(

                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(idUsuario, "Usuário", "objeto do usuário não pode ser nulo")
                    .IsNotNull(idProduto, "Produto", "objeto do produto não pode ser nulo")
                    .IsNotNull(quantidade, "Quantidade", "quantidade do produto não pode ser nula")
            );
        

            if (IsValid)
            {
                Quantidade = quantidade;
                IdUsuario = idUsuario;
                IdProduto = idProduto;
            }
        
        }

        
        public int Quantidade { get; set; }




        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; private set; }  // amarra o usuário com a reserva 



        public Guid IdProduto { get; set; }
        public Produto Produto { get; private set; }   // amarra o produto com a reserva





        // lista de reservas para os métodos de reservar e listar
        // IReadOnlyCollection para permitir somente leitura
        public IReadOnlyCollection<ReservaProduto> Reservas { get { return _reservas.ToArray(); } }


        // lista para exibir as reservas dos produtos feitas por um determinado usuário
        // private para não poder ser editada (List permite essa vulnerabilidade)
        private List<ReservaProduto> _reservas = new List<ReservaProduto>();


        
        public void AdicionarReserva(ReservaProduto reserva)
        {

            if (IsValid)
            {
                _reservas.Add(reserva);
            }

        }


    }


}
