namespace ECommerceApp.classes
{
    public class Desconto
    {
        #region Attributes

        private string codigo;
        private decimal valor;

        #endregion

        #region Methods

        #region Constructors

        public Desconto(string codigo, decimal valor)
        {
            Codigo = codigo;
            Valor = valor;
        }

        #endregion

        #region Properties

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        #endregion

        #region Functions

        public override string ToString()
        {
            return $"Código: {Codigo}, Desconto: {Valor:C}";
        }

        #endregion

        #endregion
    }
}
