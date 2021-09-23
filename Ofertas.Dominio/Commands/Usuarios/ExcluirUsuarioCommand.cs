using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum;
using Ofertas.Comum.Commands;
using System;

namespace Ofertas.Dominio.Commands.Usuarios
{
    public class ExcluirUsuarioCommand : Notifiable<Notification>, ICommand
    {
        
        public ExcluirUsuarioCommand(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }


        public Guid IdUsuario { get; set; }

        public void Validar()
        {
            AddNotifications(

                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(IdUsuario, "ID Usuário", "ID do usuário não pode ser nulo")
            );
        }

    
    }
}
