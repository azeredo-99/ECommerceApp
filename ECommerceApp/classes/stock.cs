using System;

namespace ECommerceApp.classes
{
    public class Stock
    {
        #region Attributes

        private Produto produto;
        private int quantidadeDisponivel;

        #endregion

        #region Constructors

        public Stock(Produto produto, int quantidadeDisponivel)
        {
            Produto = produto;
            QuantidadeDisponivel = quantidadeDisponivel;
        }

        #endregion

        #region Properties

        public Produto Produto
        {
            get { return produto; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "O produto não pode ser nulo.");
                }
                produto = value;
            }
        }

        public int QuantidadeDisponivel
        {
            get { return quantidadeDisponivel; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("A quantidade disponível não pode ser negativa.", nameof(value));
                }
                quantidadeDisponivel = value;
            }
        }

        #endregion

        #region Functions

        public void AtualizarStock(int quantidadeVendida)
        {
            if (quantidadeVendida <= 0)
            {
                throw new ArgumentException("A quantidade vendida deve ser maior que zero.", nameof(quantidadeVendida));
            }

            if (quantidadeVendida > QuantidadeDisponivel)
            {
                throw new InvalidOperationException("Quantidade vendida não pode ser maior do que a quantidade disponível no stock.");
            }

            QuantidadeDisponivel -= quantidadeVendida;
        }

        #endregion
    }
}
