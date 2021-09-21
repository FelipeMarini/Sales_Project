using Ofertas.Comum.Enum;
using Ofertas.Comum.Queries;
using System;

namespace Ofertas.Dominio.Queries.ReservaProduto
{
    public class ListarReservasQuery : IQuery
    {


        public void Validar()
        {
            throw new System.NotImplementedException();
        }


        public class ListarReservasResult
        {
            public Guid Id { get; set; }

            public DateTime DataCriacao { get; set; }

            public string Nome { get; set; }

            public string Email { get; set; }

            public string Titulo { get; set; }

            public string Imagem { get; set; }

            public string Descricao { get; set; }

            public EnStatusPreco StatusPreco { get; set; }

            public int Quantidade { get; set; }


            public Guid IdUsuario { get; set; }

            public Guid IdProduto { get; set; }

        
        }    
    

    }


}
