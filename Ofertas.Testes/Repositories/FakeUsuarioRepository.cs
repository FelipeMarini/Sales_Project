using Ofertas.Comum;
using Ofertas.Dominio;
using Ofertas.Dominio.Repositories;
using System;
using System.Collections.Generic;

namespace Ofertas.Testes.Repositories
{
    public class FakeUsuarioRepository : IUsuarioRepositorio
    {
        public void AlterarUsuario(Usuario usuario)
        {
            
        }

        public Usuario BuscarUsuarioPorEmail(string email)
        {
            return null;
        }

        public Usuario BuscarUsuarioPorId(Guid id)
        {
            return null;
        }

        public Usuario BuscarUsuarioPorNome(string nome)
        {
            return null;
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            
        }

        public void ExcluirUsuario(Guid id)
        {
            
        }

        public IEnumerable<Usuario> ListarUsuarios(EnTipoUsuario? tipo = null)
        {

            List<Usuario> ListaUsuariosTeste = new List<Usuario>();

            return ListaUsuariosTeste;
        
        }
    
    
    }

}
