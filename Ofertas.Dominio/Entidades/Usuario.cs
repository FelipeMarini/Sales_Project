using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum;



namespace Ofertas.Dominio
{
    public class Usuario : Base  // adicionar referência de projeto com botão direito em Dependências
    {
        public Usuario(string nome, string email, string senha, EnTipoUsuario tipoUsuario)
        {

            AddNotifications
            (
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(nome, "Nome", "Nome não pode ser vazio")
                    .IsEmail(email, "Email", "O formato do email está incorreto")
                    .IsGreaterThan(senha, 7, "Senha", "A senha deve ter pelo menos 8 caracteres")
            );

            if (IsValid)
            {

                Nome = nome;
                Email = email;
                Senha = senha;
                TipoUsuario = tipoUsuario;

            }

        }

        
        public string Nome  { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public EnTipoUsuario TipoUsuario { get; private set; }


        public void AtualizaSenha(string senha)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsGreaterThan(senha, 7, "Senha", "A senha deve ter pelo menos 8 caracteres")
            );

            if (IsValid)
                Senha = senha;
        }


        public void AtualizaUsuario(string nome, string email)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(nome, "Nome", "Nome não pode ser vazio")
                    .IsEmail(email, "Email", "O formato de email está incorreto")
            );

            if (IsValid)
            {
                Nome = nome;
                Email = email;
            }

        }


    }


}
