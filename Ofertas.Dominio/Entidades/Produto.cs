using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum;
using Ofertas.Comum.Enum;
using System.Collections.Generic;

namespace Ofertas.Dominio.Entidades
{
    public class Produto : Base
    {
        protected Produto()
        {

        }

        public Produto(string titulo, string imagem, string descricao, EnStatusPreco statusPreco, EnTipoProduto tipo, EnStatusReservaProduto statusReserva, int quantidade)
        {

            AddNotifications(
                
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(titulo, "Título", "Título não pode ser vazio")
                    .IsNotEmpty(imagem, "Imagem", "Imagem não pode ser vazia")
                    .IsNotEmpty(descricao, "Descrição", "Descrição não pode ser vazia")
                    .IsNotNull(statusPreco, "Status do Preço (Normal ou Oferta)", "Status do preço não pode ser nulo")
                    .IsNotNull(tipo, "Tipo", "Tipo não pode ser nulo")
                    .IsNotNull(statusReserva, "Status da Reserva do Produto (Livre ou Reservado)", "Status da reserva não pode ser nulo")
                    .IsNotNull(quantidade, "Quantidade", "Quantidade não pode ser nula")
            );



            if (IsValid)
            {
                Titulo = titulo;
                Imagem = imagem;
                Descricao = descricao;
                StatusPreco = statusPreco;
                TipoProduto = tipo;
                StatusReserva = statusReserva;
                Quantidade = quantidade;
            }
        }

        public string Titulo { get; private set; }

        public string Imagem { get; private set; }

        public string Descricao { get; private set; }

        public EnStatusPreco StatusPreco { get; private set; }

        public EnTipoProduto TipoProduto { get; private set; }

        public EnStatusReservaProduto StatusReserva { get; private set; }  // gambiarra por tirar o private? rs

        public int Quantidade { get; private set; }



        
        // lista de reservas associadas a um determinado produto
        public IReadOnlyCollection<ReservaProduto> Reservations { get { return _reservations.ToArray(); } }

        
        // lista de reservas associadas a um determinado produto        
        private List<ReservaProduto> _reservations = new List<ReservaProduto>();

       


    }

}
