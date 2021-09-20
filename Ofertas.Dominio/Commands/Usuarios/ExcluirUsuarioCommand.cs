﻿using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum;
using Ofertas.Comum.Commands;

namespace Ofertas.Dominio.Commands.Usuarios
{
    public class ExcluirUsuarioCommand : Notifiable<Notification>, ICommand
    {
        
        public ExcluirUsuarioCommand(string nome, string email, string senha, EnTipoUsuario tipoUsuario)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
        }

        
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public EnTipoUsuario TipoUsuario { get; set; }


        public void Validar()
        {
            AddNotifications(

                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(Nome, "Nome", "O nome não pode ser vazio")
                    .IsEmail(Email, "Email", "O formato de email está incorreto")
                    .IsGreaterThan(Senha, 7, "Senha", "A senha precisa ter no mínimo 8 caracteres")
                    .IsNotNull(TipoUsuario, "Tipo de Usuário", "Tipo de Usuário não pode ser nulo")
            );
        }

    
    }
}