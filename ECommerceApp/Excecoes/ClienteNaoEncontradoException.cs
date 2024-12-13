using System;

namespace ECommerceApp.Excecoes
{
    public class ClienteNaoEncontradoException : Exception
    {
        public ClienteNaoEncontradoException()
            : base("Cliente não encontrado.")
        {
        }

        public ClienteNaoEncontradoException(string mensagem)
            : base(mensagem)
        {
        }
    }
}
