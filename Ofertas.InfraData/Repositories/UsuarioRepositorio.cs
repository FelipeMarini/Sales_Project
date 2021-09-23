using Microsoft.EntityFrameworkCore;
using Ofertas.Comum;
using Ofertas.Dominio;
using Ofertas.Dominio.Repositories;
using Ofertas.InfraData.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ofertas.InfraData.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly OfertasContext ctx;


        public UsuarioRepositorio(OfertasContext _ctx)
        {
            ctx = _ctx;
        }


        
        public void AlterarUsuario(Usuario usuario)
        {
            ctx.Entry(usuario).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        
        public void AlterarSenha(string senha)
        {
            ctx.Entry(senha).State = EntityState.Modified;
            ctx.SaveChanges();
        }



        public Usuario BuscarUsuarioPorEmail(string email)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        
        
        public Usuario BuscarUsuarioPorId(Guid id)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        
        
        public Usuario BuscarUsuarioPorNome(string nome)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Nome.ToLower() == nome.ToLower());
        }

        
        public void CadastrarUsuario(Usuario usuario)
        {
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();
        }

        public void ExcluirUsuario(Guid id)
        {
            ctx.Usuarios.Remove(BuscarUsuarioPorId(id));

            ctx.SaveChanges();
        }

        public ICollection<Usuario> ListarUsuarios(EnTipoUsuario? tipo = null)
        {
            return ctx.Usuarios
                .AsNoTracking()
                .OrderBy(x => x.DataCriacao)
                .ToList();
        }

        IEnumerable<Usuario> IUsuarioRepositorio.ListarUsuarios(EnTipoUsuario? tipo)
        {
            throw new NotImplementedException();
        }
    }

}
