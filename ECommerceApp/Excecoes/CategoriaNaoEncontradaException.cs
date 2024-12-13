using System;

namespace ECommerceApp.Excecoes
{
    public class CategoriaNaoEncontradaException : Exception
    {
        public CategoriaNaoEncontradaException()
            : base("Categoria não encontrada.")
        {
        }

        public CategoriaNaoEncontradaException(string mensagem)
            : base(mensagem)
        {
        }
    }
}
