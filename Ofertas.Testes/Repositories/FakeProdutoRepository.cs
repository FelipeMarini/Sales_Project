using Ofertas.Comum.Enum;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositories;
using System;
using System.Collections.Generic;

namespace Ofertas.Testes.Repositories
{
    public class FakeProdutoRepository : IProdutoRepositorio
    {
        public void AlterarProduto(Produto produto)
        {
            
        }

        public void AlterarStatusPreco(EnStatusPreco statusPreco)
        {
            
        }

        public Produto BuscarProdutoPorDescricao(string descricao)
        {
            return null;  // faço isso para todos aqui quando há retorno?
        }

        public Produto BuscarProdutoPorId(Guid id)
        {
            return null;
        }

        public Produto BuscarProdutoPorStatus(EnStatusPreco status)
        {
            return null;
        }

        public Produto BuscarProdutoPorTipo(EnTipoProduto tipo)
        {
            return null;
        }

        public Produto BuscarProdutoPorTitulo(string titulo)
        {
            return null;
        }

        public void CadastrarProduto(Produto produto)
        {
            
        }

        public void ExcluirProduto(Guid id)
        {
            
        }

        public IEnumerable<Produto> ListarProdutos(EnStatusReservaProduto? statusReserva = null)
        {
            List<Produto> ListaProdutosTeste = new List<Produto>();

            return ListaProdutosTeste;   // ?
        }
    
    
    }

}
