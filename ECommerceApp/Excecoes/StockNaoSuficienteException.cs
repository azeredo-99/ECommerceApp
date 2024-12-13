using System;

namespace ECommerceApp.Excecoes
{
    public class StockInsuficienteException : Exception
    {
        public StockInsuficienteException(string produtoNome, int quantidadeSolicitada, int quantidadeDisponivel)
            : base($"Stock insuficiente para o produto '{produtoNome}'. Solicitado: {quantidadeSolicitada}, Disponível: {quantidadeDisponivel}.")
        {
        }
    }
}
