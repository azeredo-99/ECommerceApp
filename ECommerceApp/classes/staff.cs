using System;

namespace ECommerceApp.classes
{
    public class Staff : Pessoa
    {
        public Staff(string email, string nome, string password, int numeroTelemovel)
            : base(email, nome, password, numeroTelemovel)
        {
        }
    }
}
