using Ofertas.Comum.Enum;
using Ofertas.Comum.Queries;
using System;

namespace Ofertas.Dominio.Queries.Produto
{
    public class ListarProdutosQuery : IQuery
    {

        public EnStatusReservaProduto? SituacaoReserva { get; set; } = null;

        public void Validar()
        {
            throw new System.NotImplementedException();
        }


        public class ListarProdutosResult
        {
            public Guid Id { get; set; }

            public DateTime DataCriacao { get; set; }

            public string Titulo { get; set; }

            public string Imagem { get; set; }

            public string Descricao { get; set; }

            public EnTipoProduto? TipoProduto { get; set; }

            public EnStatusPreco? StatusPreco { get; set; }

            public EnStatusReservaProduto? StatusReserva { get; set; }

            public int Quantidade { get; set; }
        }
    
    
    }
}
