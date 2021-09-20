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
        
        public CadastrarProdutoCommand(string titulo, string imagem, string descricao, EnStatusProduto status, bool tipo, int quantidade)
        {
            Titulo = titulo;
            Imagem = imagem;
            Descricao = descricao;
            Status = status; // oferta ou normal
            TipoProduto = tipo; // roupa ou alimento
            Quantidade = quantidade;
            
        }

        public string Titulo { get; set; }

        public string Imagem { get; set; }

        public string Descricao { get; set; }

        public EnStatusProduto Status { get; set; }

        public bool TipoProduto { get; set; }

        public int Quantidade { get; set; }


        public void Validar()
        {
            AddNotifications(
            
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Titulo, "Título", "Título não pode ser vazio")
                    .IsNotEmpty(Imagem, "Imagem", "Imagem não pode ser vazia")
                    .IsNotEmpty(Descricao, "Descrição", "Descrição não pode ser vazia")
                    .IsNotNull(Status, "Status", "Status não pode ser nulo")
                    .IsNotNull(TipoProduto, "Tipo", "Tipo não pode ser nulo")
                    .IsNotNull(Quantidade, "Quantidade", "Quantidade não pode ser nula")
            );
        
        }
    
    
    }
}
