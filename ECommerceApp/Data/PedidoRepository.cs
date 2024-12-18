using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceApp.classes;

namespace ECommerceApp.Data
{
    public class PedidoRepository
    {
        private static List<Pedido> pedidos = new List<Pedido>();

        // Adiciona um pedido ao repositório
        public static void AdicionarPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido), "O pedido não pode ser nulo.");
            }

            pedidos.Add(pedido);
            Console.WriteLine($"Pedido ID {pedido.Id} adicionado com sucesso.");
        }

        // Obtém todos os pedidos do sistema
        public static List<Pedido> ObterTodosPedidos()
        {
            return new List<Pedido>(pedidos); // Retorna uma cópia da lista
        }

        // Obtém um pedido pelo ID
        public static Pedido ObterPedidoPorId(int id)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null)
            {
                throw new Exception($"Pedido com ID {id} não encontrado.");
            }
            return pedido;
        }

        // Obtém todos os pedidos de um cliente
        public static List<Pedido> ObterPedidosPorCliente(string emailCliente)
        {
            if (string.IsNullOrEmpty(emailCliente))
            {
                throw new ArgumentException("O email do cliente não pode ser nulo ou vazio.", nameof(emailCliente));
            }

            return pedidos.Where(p => p.Cliente.Email == emailCliente).ToList();
        }

        // Atualiza o status de um pedido
        public static void AtualizarStatusPedido(int id, StatusPedidos.StatusPedido novoStatus)
        {
            var pedido = ObterPedidoPorId(id);
            pedido.Status = novoStatus;
            Console.WriteLine($"Status do pedido ID {id} atualizado para {StatusPedidos.ObterDescricao(novoStatus)}.");
        }
    }
}
