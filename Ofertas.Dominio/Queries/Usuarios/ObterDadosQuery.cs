using Ofertas.Comum.Queries;
using System;

namespace Ofertas.Dominio.Queries.Usuario
{
    public class ObterDadosQuery : IQuery
    {

        public Guid IdBuscaUsuario { get; set; }


        public void Validar()
        {
            throw new System.NotImplementedException();
        }


    
    
    }
}
