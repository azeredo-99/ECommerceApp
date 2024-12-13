using System;

namespace ECommerceApp.Excecoes
{
    public class ProdutoNaoEncontradoException : Exception
    {
        public ProdutoNaoEncontradoException()
            : base("Produto não encontrado.")
        {
        }

        public ProdutoNaoEncontradoException(string mensagem)
            : base(mensagem)
        {
        }
    }
}
