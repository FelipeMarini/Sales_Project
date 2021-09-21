

namespace Ofertas.Comum.Utils
{
    public static class Senha
    {

        public static string Criptografar(string senha)
        {

            return BCrypt.Net.BCrypt.HashPassword(senha);

        }


        public static bool ValidarHash(string senha, string hash)
        {

            return BCrypt.Net.BCrypt.Verify(senha, hash);

        }


    }
}
