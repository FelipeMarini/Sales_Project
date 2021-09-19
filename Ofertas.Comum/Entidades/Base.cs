using Flunt.Notifications;
using System;


namespace Ofertas.Comum
{
    public abstract class Base : Notifiable<Notification>  // se não há modificador de acesso fica 'private'
    {

        public Base()
        {
            Id = Guid.NewGuid();
            
            DataCriacao = DateTime.Now;
        }


        public Guid Id { get; set; }

        public DateTime DataCriacao { get; set; }

    
    }
}
