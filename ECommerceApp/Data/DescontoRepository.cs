using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceApp.classes;

namespace ECommerceApp.Data
{
    public static class DescontoRepository
    {
        private static List<Desconto> descontos = new List<Desconto>();

        // Adiciona um novo desconto
        public static void AdicionarDesconto(Desconto desconto)
        {
            if (desconto == null || string.IsNullOrWhiteSpace(desconto.Codigo))
            {
                throw new ArgumentException("O desconto é inválido.");
            }

            descontos.Add(desconto);
        }

        // Valida o código de desconto
        public static Desconto ObterDescontoPorCodigo(string codigo)
        {
            return descontos.FirstOrDefault(d => d.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }
    }
}
