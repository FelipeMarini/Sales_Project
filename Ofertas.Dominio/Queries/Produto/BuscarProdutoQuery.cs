

using Ofertas.Comum.Enum;
using Ofertas.Comum.Queries;

namespace Ofertas.Dominio.Queries.Produto
{
    public class BuscarProdutoQuery : IQuery
    {
        public void Validar()
        {
            throw new System.NotImplementedException();
        }


        public class BuscarProdutoResult
        {
            public string Titulo { get; set; }

            public string Imagem { get; set; }

            public string Descricao { get; set; }

            public bool TipoProduto { get; set; }

            public EnStatusProduto? Status { get; set; }

            public int Quantidade { get; set; }
        }
    
    
    }
}
