namespace ECommerceApp.classes
{
    public class Categoria
    {
        #region Attributes

        private readonly int id; 
        private string nome;

        #endregion

        #region Constructors

        public Categoria(int id, string nome)
        {
            // Garantir que o nome não seja nulo ou vazio
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("Nome da categoria não pode ser vazio ou nulo.", nameof(nome));
            }

            this.id = id;  
            this.nome = nome;
        }

        #endregion

        #region Properties

        public int Id => id; 

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Nome da categoria não pode ser vazio ou nulo.", nameof(Nome));
                }
                nome = value;
            }
        }

        #endregion

        #region Functions

        public override string ToString()
        {
            return Nome;
        }

        #endregion
    }
}
