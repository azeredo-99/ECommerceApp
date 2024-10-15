using System;
using System.Collections.Generic;

namespace ECommerceApp.classes
{
    public class CarrinhoDeCompras
    {
        private List<Produto> itens = new List<Produto>();

        // Adiciona um produto ao carrinho
        public void AdicionarProduto(Produto produto)
        {
            itens.Add(produto);
        }

        // Remove um produto do carrinho pelo ID
        public void RemoverProduto(int produtoId)
        {
            var produto = itens.Find(p => p.Id == produtoId);
            if (produto != null)
            {
                itens.Remove(produto);
            }
            else
            {
                Console.WriteLine("Produto não encontrado no carrinho.");
            }
        }

        // Atualiza a quantidade de um produto no carrinho (se houver uma propriedade de quantidade)
        // Caso contrário, pode ser usado para substituir o produto com outro, se necessário
        public void AtualizarProduto(int produtoId, Produto novoProduto)
        {
            var produto = itens.Find(p => p.Id == produtoId);
            if (produto != null)
            {
                var index = itens.IndexOf(produto);
                itens[index] = novoProduto;  // Substitui pelo novo produto
            }
            else
            {
                Console.WriteLine("Produto não encontrado no carrinho.");
            }
        }

        // Exibe os produtos no carrinho
        public void ExibirCarrinho()
        {
            foreach (var produto in itens)
            {
                Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco:C}");
            }
        }

        // Limpa o carrinho
        public void LimparCarrinho()
        {
            itens.Clear();
        }

        // Calcular o valor total dos produtos no carrinho
        public decimal CalcularTotal()
        {
            return itens.Sum(p => p.Preco);
        }
    }
}
