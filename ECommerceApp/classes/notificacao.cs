namespace ECommerceApp.classes
{
    public class Notificacao
    {
        #region Attributes

        private string mensagem;
        private DateTime dataHora;

        #endregion

        #region Methods

        #region Constructors

        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
            DataHora = DateTime.Now;
        }

        #endregion

        #region Properties

        public string Mensagem
        {
            get { return mensagem; }
            set { mensagem = value; }
        }

        public DateTime DataHora
        {
            get { return dataHora; }
            set { dataHora = value; }
        }

        #endregion

        #region Functions

        public override string ToString()
        {
            return $"[{DataHora}] - {Mensagem}";
        }

        #endregion

        #endregion
    }
}
