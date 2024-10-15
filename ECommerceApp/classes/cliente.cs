using System;

namespace ECommerceApp.classes
{
    public class Cliente : Pessoa
    {
        public Cliente(string email, string nome, string password, int numeroTelemovel)
            : base(email, nome, password, numeroTelemovel)
        {
            Pedidos = new List<Pedido>();
        }

        public List<Pedido> Pedidos { get; set; }

        public void AdicionarPedido(Pedido pedido)
        {
            Pedidos.Add(pedido);
        }
    }
}
