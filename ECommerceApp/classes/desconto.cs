using System;

namespace ECommerceApp.classes
{
    public class Desconto
    {
        public string Codigo { get; set; }
        public decimal ValorDesconto { get; set; }
        public DateTime Validade { get; set; }

        public Desconto(string codigo, decimal valorDesconto, DateTime validade)
        {
            Codigo = codigo;
            ValorDesconto = valorDesconto;
            Validade = validade;
        }

        public decimal AplicarDesconto(decimal valorTotal)
        {
            if (DateTime.Now <= Validade)
                return valorTotal - ValorDesconto;
            else
                return valorTotal;
        }
    }
}
