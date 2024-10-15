using System;

namespace ECommerceApp.classes
{
    public class Pessoa
    {
        #region CONSTRUTOR

        public Pessoa(string email, string nome, string password, int numeroTelemovel)
        {
            Email = email;
            Nome = nome;
            Password = password;
            NumeroTelemovel = numeroTelemovel;
        }

        #endregion

        #region ESTADO

        public string Email { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public int NumeroTelemovel { get; set; }

        #endregion
    }
}
