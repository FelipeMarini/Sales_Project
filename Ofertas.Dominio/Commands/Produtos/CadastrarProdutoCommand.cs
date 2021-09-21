using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Enum;

namespace Ofertas.Dominio.Commands.Produtos
{
    public class CadastrarProdutoCommand : Notifiable<Notification>, ICommand
    {
        public CadastrarProdutoCommand()
        {
            
        }

        public CadastrarProdutoCommand(string titulo, string imagem, string descricao, EnStatusPreco statusPreco, EnTipoProduto tipo, EnStatusReservaProduto statusReserva, int quantidade)
        {
            Titulo = titulo;
            Imagem = imagem;
            Descricao = descricao;
            StatusPreco = statusPreco;
            TipoProduto = tipo;
            StatusReserva = statusReserva;
            Quantidade = quantidade;
        }


        public string Titulo { get; set; }

        public string Imagem { get; set; }

        public string Descricao { get; set; }

        public EnStatusPreco StatusPreco { get; set; }

        public EnTipoProduto TipoProduto { get; set; }

        public EnStatusReservaProduto StatusReserva { get; set; }

        public int Quantidade { get; set; }


        public void Validar()
        {
            AddNotifications(

                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Titulo, "Título", "Título não pode ser vazio")
                    .IsNotEmpty(Imagem, "Imagem", "Imagem não pode ser vazia")
                    .IsNotEmpty(Descricao, "Descrição", "Descrição não pode ser vazia")
                    .IsNotNull(StatusPreco, "Status do Preço (Normal ou Oferta)", "Status do preço não pode ser nulo")
                    .IsNotNull(TipoProduto, "Tipo", "Tipo não pode ser nulo")
                    .IsNotNull(StatusReserva, "Status da Reserva do Produto (Livre ou Reservado)", "Status da reserva não pode ser nula")
                    .IsNotNull(Quantidade, "Quantidade", "Quantidade não pode ser nula")
            );

        }

    }
}
