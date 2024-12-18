using System.Collections.Generic;
using ECommerceApp.classes;

namespace ECommerceApp.Interfaces
{
    public interface ICarrinhoDeComprasRepository
    {
        void AdicionarCarrinho(CarrinhoDeCompras carrinho);
        CarrinhoDeCompras ObterCarrinho(int index);
        void RemoverCarrinho(int index);
        void LimparTodosCarrinhos();
        List<CarrinhoDeCompras> ObterTodosCarrinhos();
    }
}
