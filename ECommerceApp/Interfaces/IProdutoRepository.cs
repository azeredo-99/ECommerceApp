using System.Collections.Generic;
using ECommerceApp.classes;

namespace ECommerceApp.Interfaces
{
    public interface IProdutoRepository
    {
        void AdicionarProduto(Produto produto);
        Produto ObterProdutoPorId(int id);
        List<Produto> ObterTodosProdutos();
        void RemoverProduto(int id);
        void AtualizarProduto(int id, Produto novoProduto);
    }
}
