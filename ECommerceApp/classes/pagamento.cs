using System;

namespace ECommerceApp.classes
{
    public class Pagamento
    {
        public int Id { get; set; }
        public Pedido Pedido { get; set; }
        public string MetodoPagamento { get; set; } // Pode ser "Cartão", "PayPal", etc.
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }

        public Pagamento(int id, Pedido pedido, string metodoPagamento, decimal valor)
        {
            Id = id;
            Pedido = pedido;
            MetodoPagamento = metodoPagamento;
            Valor = valor;
            DataPagamento = DateTime.Now;
        }
    }
}
