using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum;
using System;
using System.Collections.Generic;

namespace Ofertas.Dominio.Entidades
{
    public class ReservaProduto : Base  // Os Guid´s de usuário e produto irei usar no Controller
    {

        public ReservaProduto( Usuario usuario, Produto produto)
        {
            AddNotifications(

                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(usuario, "Usuário", "objeto do usuário não pode ser nulo")
                    .IsNotNull(produto, "Produto", "objeto do produto não pode ser nulo")
            );

            if (IsValid)
            {
                Usuario = usuario;
                Produto = produto;
            }
        
        }


        public Usuario Usuario { get; set; } 
        
        public Produto Produto { get; set; }

               


        // composição de classes - diagrama UML
        // IReadOnlyCollection para permitir somente leitura
        public IReadOnlyCollection<ReservaProduto> ListaReservas { get { return _listaReservas.ToArray(); } }


        // lista para exibir as reservas dos produtos feitas por um determinado usuário
        // private para não poder ser editada (List permite essa vulnerabilidade)
        private List<ReservaProduto> _listaReservas = new List<ReservaProduto>();


        public void AdicionarReserva(ReservaProduto reserva)
        {

            if (IsValid)
            {
                _listaReservas.Add(reserva);
            }

        }


    }


}
