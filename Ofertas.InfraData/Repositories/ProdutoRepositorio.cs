using Microsoft.EntityFrameworkCore;
using Ofertas.Comum.Enum;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositories;
using Ofertas.InfraData.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ofertas.InfraData.Repositories
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {

        private readonly OfertasContext ctx;


        public ProdutoRepositorio(OfertasContext _ctx)
        {
            ctx = _ctx;
        }


        public void AlterarProduto(Produto produto)
        {
            ctx.Entry(produto).State = EntityState.Modified;
            ctx.SaveChanges();
        }


        public void AlterarStatusPreco(EnStatusPreco statusPreco)
        {
            ctx.Entry(statusPreco).State = EntityState.Modified;
            ctx.SaveChanges();
        }


        public Produto BuscarProdutoPorDescricao(string descricao)
        {
            return ctx.Produtos.FirstOrDefault(x => x.Descricao.ToLower() == descricao.ToLower());
        }

        public Produto BuscarProdutoPorId(Guid id)
        {
            return ctx.Produtos.FirstOrDefault(x => x.Id == id);
        }

        public Produto BuscarProdutoPorStatus(EnStatusPreco status)
        {
            return ctx.Produtos.FirstOrDefault(x => x.StatusPreco == status);
        }

        public Produto BuscarProdutoPorTipo(EnTipoProduto tipo)
        {
            return ctx.Produtos.FirstOrDefault(x => x.TipoProduto == tipo);
        }

        public Produto BuscarProdutoPorTitulo(string titulo)
        {
            return ctx.Produtos.FirstOrDefault(x => x.Titulo.ToLower() == titulo.ToLower());
        }

        public void CadastrarProduto(Produto produto)
        {
            ctx.Produtos.Add(produto);
            ctx.SaveChanges();
        }

        public void ExcluirProduto(Guid id)
        {
            ctx.Produtos.Remove(BuscarProdutoPorId(id));

            ctx.SaveChanges();
        }

        public IEnumerable<Produto> ListarProdutos(EnStatusReservaProduto? statusReserva = null)
        {
            // incluo a classe ReservaProduto aqui?
            return ctx.Produtos
                .AsNoTracking()
                .OrderBy(x => x.DataCriacao)
                .ToList();

        }

        
    }

}
