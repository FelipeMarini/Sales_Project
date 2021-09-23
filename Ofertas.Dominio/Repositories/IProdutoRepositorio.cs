using Ofertas.Comum.Enum;
using Ofertas.Dominio.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Ofertas.Dominio.Repositories
{
    public interface IProdutoRepositorio
    {

        /// <summary>
        /// Cadastra um novo produto
        /// </summary>
        /// <param name="produto">dados do produto</param>
        void CadastrarProduto(Produto produto);

        
        /// <summary>
        /// Altera os dados de um produto existente
        /// </summary>
        /// <param name="produto">dados atualizados do produto</param>
        void AlterarProduto(Produto produto);


        /// <summary>
        /// Altera o status do preço de um produto existente, em oferta ou normal
        /// </summary>
        /// <param name="produto">status do preço do produto</param>
        void AlterarStatusPreco(EnStatusPreco statusPreco);


        /// <summary>
        /// Busca um produto através do seu título
        /// </summary>
        /// <param name="email">título do produto buscado</param>
        /// <returns>Retorna o produto buscado</returns>
        Produto BuscarProdutoPorTitulo(string titulo);

        
        /// <summary>
        /// Busca o produto através de sua descrição
        /// </summary>
        /// <param name="id">descrição do produto buscado</param>
        /// <returns>Retorna o produto buscado pela descrição</returns>
        Produto BuscarProdutoPorDescricao(string descricao);


        /// <summary>
        /// Busca o produto através do seu id
        /// </summary>
        /// <param name="id">id do produto buscado</param>
        /// <returns>Retorna o produto buscado pelo id</returns>
        Produto BuscarProdutoPorId(Guid id);


        /// <summary>
        /// Busca o produto através do seu tipo (alimento ou roupa)
        /// </summary>
        /// <param name="id">tipo do produto buscado (alimento ou roupa)</param>
        /// <returns>Retorna o produto do tipo específico buscado</returns>
        Produto BuscarProdutoPorTipo(EnTipoProduto tipo);


        /// <summary>
        /// Busca o produto através do seu status (alimento ou roupa)
        /// </summary>
        /// <param name="id">status do produto buscado (normal ou oferta)</param>
        /// <returns>Retorna o produto do status específico buscado</returns>
        Produto BuscarProdutoPorStatus(EnStatusPreco status);



        /// <summary>
        /// Lista todos os produtos ou de acordo com o status (oferta/normal)
        /// </summary>
        /// <param name="status">status do produto (oferta/normal)</param>
        /// <returns>Uma lista de produtos</returns>

        // ? porque null não é nem true nem false
        IEnumerable<Produto> ListarProdutos(EnStatusReservaProduto? statusReserva = null);


        /// <summary>
        /// Exclui o produto através do seu id
        /// </summary>
        /// <param name="id">id do produto que vai ser excluído</param>
        void ExcluirProduto(Guid id);


    }
}
