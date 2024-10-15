using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.classes
{
    public class Pedido
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<Produto> Produtos { get; set; }
        public StatusPedido Status { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal => Produtos.Sum(p => p.Preco);

        public Pedido(int id, Cliente cliente)
        {
            Id = id;
            Cliente = cliente;
            Produtos = new List<Produto>();
            DataPedido = DateTime.Now;
            Status = StatusPedido.AguardaPagamento;
        }

        // Adiciona um produto ao pedido
        public void AdicionarProduto(Produto produto)
        {
            Produtos.Add(produto);
        }

        // Remove um produto do pedido pelo ID
        public void RemoverProduto(int produtoId)
        {
            var produto = Produtos.Find(p => p.Id == produtoId);
            if (produto != null)
            {
                Produtos.Remove(produto);
            }
            else
            {
                Console.WriteLine("Produto não encontrado no pedido.");
            }
        }

        // Atualiza um produto no pedido (substitui o produto)
        public void AtualizarProduto(int produtoId, Produto novoProduto)
        {
            var produto = Produtos.Find(p => p.Id == produtoId);
            if (produto != null)
            {
                var index = Produtos.IndexOf(produto);
                Produtos[index] = novoProduto;
            }
            else
            {
                Console.WriteLine("Produto não encontrado no pedido.");
            }
        }

        public override string ToString()
        {
            return $"Pedido ID: {Id}, Cliente: {Cliente.Nome}, Status: {Status}, Total: {ValorTotal:C}, Data: {DataPedido}";
        }
    }
}
