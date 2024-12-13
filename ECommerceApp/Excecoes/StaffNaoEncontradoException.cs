using System;

namespace ECommerceApp.Excecoes
{
    public class StaffNaoEncontradoException : Exception
    {
        public StaffNaoEncontradoException(string message) : base(message) { }
    }
}
