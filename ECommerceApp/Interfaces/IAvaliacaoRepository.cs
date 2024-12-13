using System.Collections.Generic;
using ECommerceApp.classes;

namespace ECommerceApp.Interfaces
{
    public interface IAvaliacaoRepository
    {
        void AdicionarAvaliacao(Avaliacao avaliacao);
        List<Avaliacao> ObterAvaliacoesPorCliente(string emailCliente);
        List<Avaliacao> ObterAvaliacoesPorProduto(int produtoId);
    }
}
