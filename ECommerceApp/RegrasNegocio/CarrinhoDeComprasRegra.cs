using ECommerceApp.classes;
using ECommerceApp.Data;
using System;

namespace ECommerceApp.RegrasNegocio
{
    public static class CarrinhoDeComprasRegra
    {
        public static bool ValidarAdicaoAoCarrinho(CarrinhoDeCompras carrinho, Produto produto, int quantidade)
        {
            if (!StockRepository.VerificarStockDisponivel(produto, quantidade))
            {
                Console.WriteLine("Produto não disponível no stock ou quantidade solicitada excede o disponível.");
                return false;
            }

            // Se tudo estiver ok
            return true;
        }
    }
}
