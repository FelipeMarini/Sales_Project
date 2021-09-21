using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Enum;
using Ofertas.Dominio.Entidades;
using System;

namespace Ofertas.Dominio.Commands.ReservaProdutos
{
    public class ReservarProdutoCommand : Notifiable<Notification>, ICommand
    {

        public ReservarProdutoCommand()
        {

        }

        public ReservarProdutoCommand(Guid idUsuario, string nome, string email, string senha, EnTipoUsuario tipoUsuario, Guid idProduto, string titulo, string imagem, string descricao, EnStatusPreco statusPreco, EnStatusReservaProduto statusReserva, EnTipoProduto tipoProduto, int quantidade)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;

            IdProduto = idProduto;
            Titulo = titulo;
            Imagem = imagem;
            Descricao = descricao;
            StatusPreco = statusPreco;
            StatusReserva = statusReserva;
            TipoProduto = tipoProduto;
            Quantidade = quantidade;
        }

        // usuario
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public EnTipoUsuario TipoUsuario { get; set; }


        // produto
        public string Titulo { get; set; }

        public string Imagem { get; set; }

        public string Descricao { get; set; }

        public EnStatusPreco StatusPreco { get; set; }

        public EnStatusReservaProduto StatusReserva { get; set; }

        public EnTipoProduto TipoProduto { get; set; }

        public int Quantidade { get; set; }



        // reserva

        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }


        public Guid IdProduto { get; set; }
        public Produto Produto { get; set; }



        public void Validar()
        {
            AddNotifications(

                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Nome, "Nome", "Nome não pode ser vazio")
                    .IsEmail(Email, "Email", "O formato do email está incorreto")
                    .IsGreaterThan(Senha, 7, "Senha", "A senha deve ter pelo menos 8 caracteres")
                    .IsNotEmpty(Titulo, "Título", "Título não pode ser vazio")
                    .IsNotEmpty(Imagem, "Imagem", "Imagem não pode ser vazia")
                    .IsNotEmpty(Descricao, "Descrição", "Descrição não pode ser vazia")
                    .IsNotNull(StatusPreco, "Status do Preço (Normal ou Oferta)", "Status do preço não pode ser nulo")
                    .IsNotNull(Quantidade, "Quantidade", "Quantidade não pode ser nula")
            );

        }

    
    }

}
