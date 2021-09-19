using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum;
using Ofertas.Comum.Enum;


namespace Ofertas.Dominio.Entidades
{
    public class Produto : Base
    {
        public Produto(string titulo, string imagem, string descricao, EnStatusProduto status, bool tipo, int quantidade)
        {

            AddNotifications(
                
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(titulo,"Título","Título não pode ser vazio")
                    .IsNotEmpty(imagem, "Imagem", "Imagem não pode ser vazia")
                    .IsNotEmpty(descricao, "Descrição", "Descrição não pode ser vazia")
                    .IsNotNull(status,"Status","Status não pode ser nulo")
                    .IsNotNull(tipo, "Tipo", "Tipo não pode ser nulo")
                    .IsNotNull(quantidade, "Quantidade", "Quantidade não pode ser nula") // mas pode ser zero
            );



            if (IsValid)
            {
                Titulo = titulo;
                Imagem = imagem;
                Descricao = descricao;
                Status = status;
                TipoProduto = tipo;
                Quantidade = quantidade;
            }
        }

        public string Titulo { get; set; }

        public string Imagem { get; set; }

        public string Descricao { get; set; }

        public EnStatusProduto Status { get; set; }

        public bool TipoProduto { get; set; }

        public int Quantidade { get; set; }


        public void AtualizaProduto(string titulo, string imagem, string descricao, EnStatusProduto status, bool tipo, int quantidade)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(titulo, "Título", "Título não pode ser vazio")
                    .IsNotEmpty(imagem, "Imagem", "Imagem não pode ser vazia")
                    .IsNotEmpty(descricao, "Descrição", "Descrição não pode ser vazia")
                    .IsNotNull(status,"Status","Status não pode ser nulo")
                    .IsNotNull(tipo,"Tipo","Tipo não pode ser nulo")
                    .IsNotNull(quantidade, "Quantidade", "Quantidade não pode ser nula")
            );

            if (IsValid)
            {
                Titulo = titulo;
                Imagem = imagem;
                Descricao = descricao;
                Status = status;
                TipoProduto = tipo;
                Quantidade = quantidade;
            }

        }


        public void AtualizaStatus(EnStatusProduto status)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(status, "Status", "Status do produto não pode ser nulo")                    
            );

            if (IsValid)
            {
                Status = status;
            }

        }

        public void AtualizaTipo(bool tipo)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(tipo, "Tipo", "Tipo de produto não pode ser nulo")
            );

            if (IsValid)
            {
                TipoProduto = tipo;
            }

        }




    }
}
