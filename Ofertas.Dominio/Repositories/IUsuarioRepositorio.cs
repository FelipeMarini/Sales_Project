using Ofertas.Comum;
using System;
using System.Collections.Generic;

namespace Ofertas.Dominio.Repositories
{
    public interface IUsuarioRepositorio
    {
        
        
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">dados do usuário</param>
        void CadastrarUsuario(Usuario usuario);

        
        
        /// <summary>
        /// Altera os dados de um usuário existente
        /// </summary>
        /// <param name="usuario">dados atualizados do usuário</param>
        void AlterarUsuario(Usuario usuario);


        /// <summary>
        /// Altera a senha do usuário
        /// </summary>
        /// <param name="senha">nova senha do usuário</param>
        void AlterarSenha(string senha);



        /// <summary>
        /// Busca um usuário através do seu email
        /// </summary>
        /// <param name="email">email do usuário buscado</param>
        /// <returns>Retorna o usuário buscado</returns>
        Usuario BuscarUsuarioPorEmail(string email);


        
        /// <summary>
        /// Busca um usuário através do seu nome
        /// </summary>
        /// <param name="email">nome do usuário buscado</param>
        /// <returns>Retorna o usuário buscado</returns>
        Usuario BuscarUsuarioPorNome(string nome);

        
        
        /// <summary>
        /// Busca o usuário através do seu id
        /// </summary>
        /// <param name="id">id do usuário buscado</param>
        /// <returns>Retorna o usuário buscado</returns>
        Usuario BuscarUsuarioPorId(Guid id);

        
        
        
        /// <summary>
        /// Exclui o usuário através do seu id
        /// </summary>
        /// <param name="id">id do usuário que vai ser excluído</param>
        void ExcluirUsuario(Guid id);

        
        
        
        /// <summary>
        /// Lista todos os usuários ou de acordo com o seu tipo (admnistrador/comum)
        /// </summary>
        /// <param name="tipo">tipo do usuário (admnistrador/comum)</param>
        /// <returns>Uma lista de usuários</returns>

        // bool? porque null não é nem true nem false
        IEnumerable<Usuario> ListarUsuarios(EnTipoUsuario? tipo = null);



    }
}
