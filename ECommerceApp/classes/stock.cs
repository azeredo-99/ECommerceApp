using System;

namespace ECommerceApp.classes
{
    public class Stock
    {
        public Produto Produto { get; set; }
        public int QuantidadeDisponivel { get; set; }

        public Stock(Produto produto, int quantidadeDisponivel)
        {
            Produto = produto;
            QuantidadeDisponivel = quantidadeDisponivel;
        }

        public void AtualizarStock(int quantidadeVendida)
        {
            QuantidadeDisponivel -= quantidadeVendida;
        }
    }
}
