namespace ECommerceApp.classes
{
    public class Endereco
    {
        #region Attributes

        private string rua;
        private string cidade;
        private string distrito;
        private string cp;

        #endregion

        #region Methods

        #region Constructors

        public Endereco(string rua, string cidade, string distrito, string cp)
        {
            Rua = rua;
            Cidade = cidade;
            Distrito = distrito;
            Cpostal = cp;
        }

        #endregion

        #region Properties

        public string Rua
        {
            get { return rua; }
            set { rua = value; }
        }

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public string Distrito
        {
            get { return distrito; }
            set { distrito = value; }
        }

        public string Cpostal
        {
            get { return cp; }
            set { cp = value; }
        }

        #endregion

        #region Functions

        public override string ToString()
        {
            return $"{Rua}, {Cidade}, {Distrito} - {Cpostal}";
        }

        #endregion

        #endregion
    }
}
