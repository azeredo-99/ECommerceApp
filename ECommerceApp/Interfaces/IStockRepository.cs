using System.Collections.Generic;
using ECommerceApp.classes;

namespace ECommerceApp.Interfaces
{
    public interface IStockRepository
    {
        void AdicionarProdutoAoStock(Produto produto, int quantidade);
        Stock ObterStockProduto(Produto produto);
        bool VerificarStockDisponivel(Produto produto, int quantidade);
    }
}
