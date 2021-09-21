using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum;
using Ofertas.Comum.Enum;
using System;
using System.Collections.Generic;

namespace Ofertas.Dominio.Entidades
{
    public abstract class ReservaProduto : Base
    {

        public ReservaProduto(string nome, string email, string titulo, string imagem, string descricao, EnStatusPreco statusPreco, int quantidade, Guid idUsuario, Guid idProduto)
        {
            AddNotifications(

                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(nome, "Nome", "Nome não pode ser vazio")
                    .IsEmail(email, "Email", "O formato do email está incorreto")
                    .IsNotEmpty(titulo, "Título", "Título não pode ser vazio")
                    .IsNotEmpty(imagem, "Imagem", "Imagem não pode ser vazia")
                    .IsNotEmpty(descricao, "Descrição", "Descrição não pode ser vazia")
                    .IsNotNull(statusPreco, "Status do Preço (Normal ou Oferta)", "Status do preço não pode ser nulo")
                    .IsNotNull(quantidade, "Quantidade", "Quantidade não pode ser nula")
            );

            if (IsValid)
            {
                Nome = nome;
                Email = email;
                Titulo = titulo;
                Imagem = imagem;
                Descricao = descricao;
                StatusPreco = statusPreco;
                Quantidade = quantidade;
                IdUsuario = idUsuario;
                IdProduto = idProduto;
            }
        
        }


        public string Nome { get; set; }

        public string Email { get; set; }


        public string Titulo { get; set; }

        public string Imagem { get; set; }

        public string Descricao { get; set; }

        public EnStatusPreco StatusPreco { get; set; }
        
        public int Quantidade { get; set; }


        
        public Guid IdUsuario { get; set; }         
        
        public Guid IdProduto { get; set; }




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
