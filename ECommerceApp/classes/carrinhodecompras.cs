using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.classes
{
    public class CarrinhoDeCompras
    {
        #region Attributes

        private List<Produto> itens;
        private Desconto descontoAplicado; // Referência para o desconto aplicado

        #endregion

        #region Constructors

        public CarrinhoDeCompras()
        {
            itens = new List<Produto>();
            descontoAplicado = null; // Sem desconto inicialmente
        }

        #endregion

        #region Properties

        public List<Produto> Itens => new List<Produto>(itens);

        public Desconto DescontoAplicado => descontoAplicado;

        #endregion

        #region Functions

        // Adicionar Produto
        public void AdicionarProduto(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");
            }

            itens.Add(produto);
            Console.WriteLine($"Produto '{produto.Nome}' adicionado ao carrinho.");
        }

        // Remover Produto por ID
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

        // Exibir os Produtos no Carrinho
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

            if (descontoAplicado != null)
            {
                Console.WriteLine($"Desconto Aplicado: -{descontoAplicado.Valor:C}");
            }

            Console.WriteLine($"Total: {CalcularTotal():C}");
        }

        // Calcular Total
        public decimal CalcularTotal()
        {
            decimal total = itens.Sum(p => p.Preco);
            if (descontoAplicado != null)
            {
                total -= descontoAplicado.Valor;
            }

            return total < 0 ? 0 : total; // Evita valores negativos
        }

        // Limpar Carrinho
        public void LimparCarrinho()
        {
            itens.Clear();
            descontoAplicado = null; // Remove o desconto ao limpar o carrinho
            Console.WriteLine("Carrinho limpo com sucesso.");
        }

        // Obter Produtos
        public List<Produto> ObterProdutos()
        {
            return new List<Produto>(itens);
        }

        // Obter Quantidade de Produtos
        public int ObterQuantidadeProdutos()
        {
            return itens.Count;
        }

        // Aplicar Desconto
        public void AplicarDesconto(Desconto desconto)
        {
            if (desconto == null)
            {
                throw new ArgumentNullException(nameof(desconto), "O desconto não pode ser nulo.");
            }

            descontoAplicado = desconto;
            Console.WriteLine($"Desconto de {desconto.Valor:C} aplicado com sucesso.");
        }

        #endregion
    }
}
