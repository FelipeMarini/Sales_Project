using Ofertas.Dominio;
using Xunit;

namespace Ofertas.Testes
{
    public class UsuarioTeste
    {

        [Fact] // data annotation para representar que é um teste 
        
        public void DeveRetornarSeUsuarioForValido()
        {
            Usuario usuario = new Usuario(
                "Felipe",
                "felipemarini@gmail.com",
                "123456789", 
                Comum.EnTipoUsuario.Admin
            );

            Assert.True(usuario.IsValid,"Usuário validado com sucesso");
        }


    }
}
