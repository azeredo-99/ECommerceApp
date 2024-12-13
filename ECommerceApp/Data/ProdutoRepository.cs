using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceApp.classes;
using ECommerceApp.Excecoes;

namespace ECommerceApp.Data
{
    public static class ProdutoRepository
    {
        private static Dictionary<int, Produto> produtos = new Dictionary<int, Produto>(); // Usando um dicionário para armazenar produtos

        // Adicionar Produto
        public static void AdicionarProduto(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo.");
            }

            // Verifica se já existe um produto com o mesmo ID
            if (produtos.ContainsKey(produto.Id))
            {
                throw new ArgumentException($"Já existe um produto com o ID {produto.Id}.");
            }

            produtos[produto.Id] = produto; // Adiciona o produto no dicionário
            Console.WriteLine($"Produto {produto.Nome} adicionado com sucesso.");
        }

        // Obter Produto por ID
        public static Produto ObterProdutoPorId(int id)
        {
            // Verifica se o produto existe no dicionário
            if (!produtos.ContainsKey(id))
            {
                throw new ProdutoNaoEncontradoException($"Produto com ID {id} não encontrado.");
            }

            return produtos[id]; // Retorna o produto do dicionário
        }

        // Obter Todos os Produtos
        public static List<Produto> ObterTodosProdutos()
        {
            return produtos.Values.ToList(); // Retorna os valores do dicionário como uma lista
        }

        // Remover Produto
        public static void RemoverProduto(int id)
        {
            // Verifica se o produto existe antes de tentar remover
            if (produtos.ContainsKey(id))
            {
                produtos.Remove(id); // Remove diretamente do dicionário
                Console.WriteLine($"Produto com ID {id} removido com sucesso.");
            }
            else
            {
                Console.WriteLine($"Produto com ID {id} não encontrado.");
            }
        }

        // Atualizar Produto
        public static void AtualizarProduto(int id, Produto novoProduto)
        {
            // Verifica se o produto já existe no repositório
            var produtoExistente = ObterProdutoPorId(id);

            if (novoProduto != null)
            {
                // Atualiza o produto usando os métodos da classe Produto
                produtoExistente.AtualizarNome(novoProduto.Nome);
                produtoExistente.AtualizarPreco(novoProduto.Preco);
                produtoExistente.AtualizarCategoria(novoProduto.Categoria);

                Console.WriteLine($"Produto com ID {id} atualizado com sucesso.");
            }
            else
            {
                throw new ArgumentNullException(nameof(novoProduto), "Produto não pode ser nulo.");
            }
        }
    }
}
