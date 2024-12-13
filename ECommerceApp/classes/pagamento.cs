namespace ECommerceApp.classes
{
    public class Pagamento
    {
        #region Attributes

        private decimal valor;
        private string metodoPagamento;

        #endregion

        #region Methods

        #region Constructors

        public Pagamento(decimal valor, string metodoPagamento)
        {
            Valor = valor;
            MetodoPagamento = metodoPagamento;
        }

        #endregion

        #region Properties

        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public string MetodoPagamento
        {
            get { return metodoPagamento; }
            set { metodoPagamento = value; }
        }

        #endregion

        #region Functions

        public override string ToString()
        {
            return $"Método de Pagamento: {MetodoPagamento}, Valor: {Valor:C}";
        }

        #endregion

        #endregion
    }
}
