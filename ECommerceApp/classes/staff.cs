using System;

namespace ECommerceApp.classes
{
    public class Staff : Pessoa
    {
        #region Attributes

        private string cargo;

        #endregion

        #region Constructors

        // Construtor que chama o construtor da classe base (Pessoa)
        public Staff(string email, string nome, string password, int numeroTelemovel, string cargo)
            : base(email, nome, password, numeroTelemovel)
        {
            Cargo = cargo; // Atribui o cargo específico para Staff
        }

        #endregion

        #region Properties

        public string Cargo
        {
            get { return cargo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O cargo não pode ser vazio ou nulo.");
                }
                cargo = value;
            }
        }

        #endregion

        #region Functions

        // Override do ToString para fornecer uma saída para o Staff
        public override string ToString()
        {
            return $"[Staff] {base.ToString()}, Cargo: {Cargo}";
        }

        #endregion
    }
}
