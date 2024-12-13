using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceApp.classes;

namespace ECommerceApp.classes
{
    public class CarrinhoDeCompras
    {
        private List<Produto> itens;

        public CarrinhoDeCompras()
        {
            itens = new List<Produto>();
        }

        public List<Produto> Itens => new List<Produto>(itens);

        public void AdicionarProduto(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");
            }

            itens.Add(produto);
            Console.WriteLine($"Produto '{produto.Nome}' adicionado ao carrinho.");
        }

        public void RemoverProduto(int produtoId)
        {
            var produto = itens.FirstOrDefault(p => p.Id == produtoId);
            if (produto == null)
            {
                Console.WriteLine($"Produto com ID {produtoId} não encontrado no carrinho.");
                return;
            }

            itens.Remove(produto);
            Console.WriteLine($"Produto '{produto.Nome}' removido do carrinho.");
        }

        public void RemoverProdutoPorObjeto(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");
            }

            if (itens.Remove(produto))
            {
                Console.WriteLine($"Produto '{produto.Nome}' removido do carrinho.");
            }
            else
            {
                Console.WriteLine($"Produto '{produto.Nome}' não encontrado no carrinho.");
            }
        }

        public void ExibirCarrinho()
        {
            if (!itens.Any())
            {
                Console.WriteLine("O carrinho está vazio.");
                return;
            }

            Console.WriteLine("\n=== Carrinho de Compras ===");
            foreach (var produto in itens)
            {
                Console.WriteLine($"Produto: {produto.Nome}, Preço: {produto.Preco:C}");
            }
            Console.WriteLine($"Total: {CalcularTotal():C}");
        }

        public decimal CalcularTotal()
        {
            return itens.Sum(p => p.Preco);
        }

        public void LimparCarrinho()
        {
            itens.Clear();
            Console.WriteLine("Carrinho limpo com sucesso.");
        }

        public List<Produto> ObterProdutos()
        {
            return new List<Produto>(itens);
        }

        public int ObterQuantidadeProdutos()
        {
            return itens.Count;
        }
    }
}
