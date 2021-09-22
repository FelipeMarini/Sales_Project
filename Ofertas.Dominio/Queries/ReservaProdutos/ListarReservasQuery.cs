using Ofertas.Comum.Enum;
using Ofertas.Comum.Queries;
using System;

namespace Ofertas.Dominio.Queries.ReservaProduto
{
    public class ListarReservasQuery : IQuery
    {


        public Guid idUsuario { get; set; }


        public void Validar()
        {
            throw new System.NotImplementedException();
        }


        public class ListarReservasResult
        {
            
            public Guid Id { get; set; }

            public DateTime DataCriacao { get; set; }
            
            public int Quantidade { get; set; }

            
            
            public string Nome { get; set; }

            public string Email { get; set; }

            
            
            public string Titulo { get; set; }

            public string Imagem { get; set; }

            public string Descricao { get; set; }

            public EnStatusPreco StatusPreco { get; set; }

            public EnTipoProduto TipoProduto { get; set; }



        
        }    
    

    }


}
