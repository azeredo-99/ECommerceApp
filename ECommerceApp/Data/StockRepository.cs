﻿using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceApp.classes;
using ECommerceApp.Excecoes;

namespace ECommerceApp.Data
{
    public static class StockRepository
    {
        private static List<Stock> stock = new List<Stock>();

        public static void AdicionarProdutoAoStock(Produto produto, int quantidade)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo.");

            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.", nameof(quantidade));

            var stockProduto = stock.FirstOrDefault(s => s.Produto.Id == produto.Id);
            if (stockProduto != null)
            {
                stockProduto.QuantidadeDisponivel += quantidade;
                Console.WriteLine($"Quantidade atualizada para o produto {produto.Nome}. Novo stock: {stockProduto.QuantidadeDisponivel}");
            }
            else
            {
                stock.Add(new Stock(produto, quantidade));
                Console.WriteLine($"Produto {produto.Nome} adicionado ao stock com quantidade {quantidade}.");
            }
        }

        public static Stock ObterStockProduto(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo.");

            var stockProduto = stock.FirstOrDefault(s => s.Produto.Id == produto.Id);
            if (stockProduto == null)
            {
                throw new ProdutoNaoEncontradoException($"Produto {produto.Nome} não encontrado no stock.");
            }

            return stockProduto;
        }

        public static bool VerificarStockDisponivel(Produto produto, int quantidade)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo.");

            if (quantidade <= 0)
                throw new ArgumentException("Quantidade solicitada deve ser maior que zero.", nameof(quantidade));

            var stockProduto = stock.FirstOrDefault(s => s.Produto.Id == produto.Id);
            if (stockProduto == null)
            {
                return false;
            }

            return stockProduto.QuantidadeDisponivel >= quantidade;
        }

        public static void RemoverDoStock(Produto produto, int quantidade)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo.");

            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.", nameof(quantidade));

            var stockProduto = ObterStockProduto(produto);
            if (stockProduto.QuantidadeDisponivel < quantidade)
            {
                throw new StockInsuficienteException(produto.Nome, quantidade, stockProduto.QuantidadeDisponivel);
            }

            stockProduto.QuantidadeDisponivel -= quantidade;
            Console.WriteLine($"Quantidade {quantidade} removida do stock do produto {produto.Nome}. Quantidade restante: {stockProduto.QuantidadeDisponivel}");
        }

        public static void ExibirStock()
        {
            if (!stock.Any())
            {
                Console.WriteLine("Nenhum produto no stock.");
                return;
            }

            Console.WriteLine("\n=== Stock Atual ===");
            foreach (var s in stock)
            {
                Console.WriteLine($"Produto: {s.Produto.Nome}, Quantidade: {s.QuantidadeDisponivel}");
            }
        }
    }
}
