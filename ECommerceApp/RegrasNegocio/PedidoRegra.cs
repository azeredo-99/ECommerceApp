using System;
using ECommerceApp.classes;
using ECommerceApp.Data;

namespace ECommerceApp.RegrasNegocio
{
    public class PedidoRegra
    {
        public static bool ValidarPedido(Pedido pedido)
        {
            // Verificar se todos os produtos no pedido têm stock suficiente
            foreach (var item in pedido.ItensPedido)
            {
                var stockProduto = StockRepository.ObterStockProduto(item.Produto);
                if (stockProduto == null || stockProduto.QuantidadeDisponivel < item.Quantidade)
                {
                    Console.WriteLine($"Produto {item.Produto.Nome} não tem stock suficiente.");
                    return false;  // Se algum produto não tem stock suficiente, o pedido não é válido
                }
            }

            // Se o stock for suficiente para todos os produtos, o pedido pode ser validado
            return true;
        }
    }
}
