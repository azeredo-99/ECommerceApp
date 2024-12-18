using System;
using System.Collections.Generic;
using ECommerceApp.classes;
using ECommerceApp.Interfaces;

namespace ECommerceApp.Data
{
    public class CarrinhoDeComprasRepository : ICarrinhoDeComprasRepository
    {
        private static List<CarrinhoDeCompras> carrinhos = new List<CarrinhoDeCompras>();

        // Adicionar um novo carrinho
        public void AdicionarCarrinho(CarrinhoDeCompras carrinho)
        {
            if (carrinho == null)
            {
                throw new ArgumentNullException(nameof(carrinho), "O carrinho não pode ser nulo.");
            }

            carrinhos.Add(carrinho);
            Console.WriteLine("Carrinho adicionado com sucesso.");
        }

        // Obter carrinho por índice ou posição (pode ser ajustado para outra chave de identificação)
        public CarrinhoDeCompras ObterCarrinho(int index)
        {
            if (index < 0 || index >= carrinhos.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Índice do carrinho inválido.");
            }

            return carrinhos[index];
        }

        // Remover um carrinho pelo índice
        public void RemoverCarrinho(int index)
        {
            var carrinho = ObterCarrinho(index);
            carrinhos.Remove(carrinho);
            Console.WriteLine("Carrinho removido com sucesso.");
        }

        // Limpar todos os carrinhos (útil para testes ou reset)
        public void LimparTodosCarrinhos()
        {
            carrinhos.Clear();
            Console.WriteLine("Todos os carrinhos foram removidos.");
        }

        // Obter todos os carrinhos (para monitoramento ou controle)
        public List<CarrinhoDeCompras> ObterTodosCarrinhos()
        {
            return new List<CarrinhoDeCompras>(carrinhos);
        }
    }
}
