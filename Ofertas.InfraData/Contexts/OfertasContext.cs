using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Ofertas.Dominio;
using Ofertas.Dominio.Entidades;

namespace Ofertas.InfraData.Contexts
{
    public class OfertasContext : DbContext
    {

        public OfertasContext(DbContextOptions<OfertasContext> options) : base(options)
        {


        }


        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Produto> Produtos { get; set; }

    
        // console do gerenciador de pacotes do NuGet (ferramentas):
        // add-migration "Banco Inicial - Tabela Usuarios" -> cria tabela (migration) na pasta migrations
        // update-database -> cria efetivamente o banco no Sql Server Management Studio
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Ignore<Notification>();


            // não precisa colocar TipoUsuario aqui por ser um Enum?
            // preciso ter uma tabela da classe ReservaProduto?
            #region Tabela Usuarios  

            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            modelBuilder.Entity<Usuario>().Property(x => x.Id);
            //pelo nome ser "Id" já gera uma PK automática
           
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(80);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("varchar(80)");
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired(); // NOT NULL

            
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(100);
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasColumnType("varchar(100)");
            modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<Usuario>().HasIndex(x => x.Email).IsUnique();


            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(255);
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnType("varchar(255)");
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();


            modelBuilder.Entity<Usuario>().Property(x => x.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(x => x.DataCriacao).HasDefaultValueSql("getdate()");

            #endregion


            #region Tabela Produtos

            modelBuilder.Entity<Produto>().ToTable("Produtos");

            modelBuilder.Entity<Produto>().Property(x => x.Id);

            modelBuilder.Entity<Produto>().Property(x => x.Titulo).HasMaxLength(100);
            modelBuilder.Entity<Produto>().Property(x => x.Titulo).HasColumnType("varchar(100)");
            modelBuilder.Entity<Produto>().Property(x => x.Titulo).IsRequired();

            modelBuilder.Entity<Produto>().Property(x => x.Imagem).HasMaxLength(200);
            modelBuilder.Entity<Produto>().Property(x => x.Imagem).HasColumnType("varchar(200)");
            modelBuilder.Entity<Produto>().Property(x => x.Imagem).IsRequired();

            modelBuilder.Entity<Produto>().Property(x => x.Descricao).HasMaxLength(500);
            modelBuilder.Entity<Produto>().Property(x => x.Descricao).HasColumnType("text(500)");
            modelBuilder.Entity<Produto>().Property(x => x.Descricao).IsRequired();

            modelBuilder.Entity<Produto>().Property(x => x.Quantidade).HasColumnType("int");

            modelBuilder.Entity<Produto>().Property(x => x.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Produto>().Property(x => x.DataCriacao).HasDefaultValueSql("getdate()");

            #endregion


            base.OnModelCreating(modelBuilder);

        }
    
    
    
    
    
    }
}
