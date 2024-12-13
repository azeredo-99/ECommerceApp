using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceApp.classes;
using ECommerceApp.Interfaces;

namespace ECommerceApp.Data
{
    public class CarrinhoDeComprasRepository : ICarrinhoDeComprasRepository
    {
        private List<Produto> produtosCarrinho = new List<Produto>();

        // Adicionar produto ao carrinho
        public void AdicionarProduto(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");
            }

            produtosCarrinho.Add(produto);
            Console.WriteLine($"Produto '{produto.Nome}' adicionado ao carrinho.");
        }

        // Remover produto do carrinho pelo ID
        public void RemoverProduto(int produtoId)
        {
            var produto = produtosCarrinho.FirstOrDefault(p => p.Id == produtoId);
            if (produto == null)
            {
                throw new ArgumentException($"Produto com ID {produtoId} não encontrado no carrinho.");
            }

            produtosCarrinho.Remove(produto);
            Console.WriteLine($"Produto '{produto.Nome}' removido do carrinho.");
        }

        // Exibir todos os produtos do carrinho
        public void ExibirCarrinho()
        {
            if (!produtosCarrinho.Any())
            {
                Console.WriteLine("O carrinho está vazio.");
                return;
            }

            Console.WriteLine("Produtos no carrinho:");
            foreach (var produto in produtosCarrinho)
            {
                Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco:C}");
            }
        }

        // Calcular o total do carrinho
        public decimal CalcularTotal()
        {
            return produtosCarrinho.Sum(p => p.Preco);
        }

        // Limpar todos os produtos do carrinho
        public void LimparCarrinho()
        {
            produtosCarrinho.Clear();
            Console.WriteLine("O carrinho foi limpo.");
        }

        // Obter a lista de produtos no carrinho
        public List<Produto> ObterProdutos()
        {
            return new List<Produto>(produtosCarrinho);
        }
    }
}
