namespace ECommerceApp.classes
{
    public class Pessoa
    {
        #region Attributes

        private string email;
        private string nome;
        private string password;
        private int numeroTelemovel;

        #endregion

        #region Methods

        #region Constructors

        public Pessoa(string email, string nome, string password, int numeroTelemovel)
        {
            Email = email;
            Nome = nome;
            Password = password;
            NumeroTelemovel = numeroTelemovel;
        }

        #endregion

        #region Properties

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email não pode ser vazio.");
                email = value;
            }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nome não pode ser vazio.");
                nome = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Password não pode ser vazia.");
                password = value;
            }
        }

        public int NumeroTelemovel
        {
            get { return numeroTelemovel; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Número de telemóvel deve ser positivo.");
                numeroTelemovel = value;
            }
        }

        #endregion

        #region Functions

        public override string ToString()
        {
            return $"Nome: {Nome}, Email: {Email}, Telemóvel: {NumeroTelemovel}";
        }

        #endregion

        #endregion
    }
}
