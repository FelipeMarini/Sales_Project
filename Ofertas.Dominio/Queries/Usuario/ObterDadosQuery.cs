using Ofertas.Comum;
using Ofertas.Comum.Queries;
using System;

namespace Ofertas.Dominio.Queries.Usuario
{
    public class ObterDadosQuery : IQuery
    {
 

        public void Validar()
        {
            throw new System.NotImplementedException();
        }


        public class ObterDadosResult
        {

            public Guid Id { get; set; }

            public DateTime DataCriacao { get; set; }

            public string Nome { get; set; }

            public string Email { get; set; }

            public EnTipoUsuario? TipoUsuario { get; set; }

        }
    
    
    }
}
