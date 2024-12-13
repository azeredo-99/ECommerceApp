using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.classes
{
    public class Recomendacao
    {
        #region Methods

        public static List<Produto> Recomendados(List<Produto> comprasAnteriores, List<Produto> todosProdutos)
        {
            // Recomenda produtos da mesma categoria que não estão nas compras anteriores
            var recomendacoes = new List<Produto>();
            foreach (var produto in comprasAnteriores)
            {
                recomendacoes.AddRange(todosProdutos.Where(p =>
                    p.Categoria == produto.Categoria && !comprasAnteriores.Contains(p)));
            }
            return recomendacoes.Distinct().ToList(); // Remove duplicados
        }

        #endregion
    }
}
