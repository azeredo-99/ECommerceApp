using System;

namespace ECommerceApp.classes
{
    public class Recomendacao
    {
        public static List<Produto> Recomendados(List<Produto> comprasAnteriores, List<Produto> todosProdutos)
        {
            // Implementação simples para recomendar produtos da mesma categoria
            var recomendacoes = new List<Produto>();
            foreach (var produto in comprasAnteriores)
            {
                recomendacoes.AddRange(todosProdutos.Where(p => p.Categoria == produto.Categoria && !comprasAnteriores.Contains(p)));
            }
            return recomendacoes;
        }
    }
}
