using System.Collections.Generic;
using ECommerceApp.classes;

namespace ECommerceApp.Interfaces
{
    public interface ICarrinhoDeComprasRepository
    {
        void AdicionarProduto(Produto produto);
        void RemoverProduto(int produtoId);
        void ExibirCarrinho();
        decimal CalcularTotal();
        void LimparCarrinho();
        List<Produto> ObterProdutos();
    }
}
