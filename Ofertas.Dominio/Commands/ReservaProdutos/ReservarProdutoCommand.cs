using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Enum;
using Ofertas.Dominio.Entidades;

namespace Ofertas.Dominio.Commands.ReservaProdutos
{
    public class ReservarProdutoCommand : Notifiable<Notification>, ICommand
    {

        public ReservarProdutoCommand()
        {

        }

        public ReservarProdutoCommand(string nome, string email, string titulo, string imagem, string descricao, EnStatusPreco statusPreco, int quantidade)
        {
            Nome = nome;
            Email = email;
            Titulo = titulo;
            Imagem = imagem;
            Descricao = descricao;
            StatusPreco = statusPreco;
            Quantidade = quantidade;
        }

        public string Nome { get; set; }

        public string Email { get; set; }


        public string Titulo { get; set; }

        public string Imagem { get; set; }

        public string Descricao { get; set; }

        public EnStatusPreco StatusPreco { get; set; }

        public int Quantidade { get; set; }

        public Usuario Usuario { get; set; }

        public Produto Produto { get; set; }




        public void Validar()
        {
            AddNotifications(

                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Nome, "Nome", "Nome não pode ser vazio")
                    .IsEmail(Email, "Email", "O formato do email está incorreto")
                    .IsNotEmpty(Titulo, "Título", "Título não pode ser vazio")
                    .IsNotEmpty(Imagem, "Imagem", "Imagem não pode ser vazia")
                    .IsNotEmpty(Descricao, "Descrição", "Descrição não pode ser vazia")
                    .IsNotNull(StatusPreco, "Status do Preço (Normal ou Oferta)", "Status do preço não pode ser nulo")
                    .IsNotNull(Quantidade, "Quantidade", "Quantidade não pode ser nula")
            );

        }

    
    }

}
