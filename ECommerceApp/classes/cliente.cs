using System;
using System.Collections.Generic;

namespace ECommerceApp.classes
{
    public class Cliente : Pessoa
    {
        #region Attributes

        private List<Pedido> pedidos;

        #endregion

        #region Constructors

        public Cliente(string email, string nome, string password, int numeroTelemovel)
            : base(email, nome, password, numeroTelemovel)
        {
            pedidos = new List<Pedido>();
        }

        #endregion

        #region Properties

        public IReadOnlyList<Pedido> Pedidos => pedidos.AsReadOnly();

        #endregion

        #region Methods

        public void AdicionarPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido), "O pedido não pode ser nulo.");
            }

            pedidos.Add(pedido);
        }

        public List<Pedido> ObterPedidos()
        {
            return new List<Pedido>(pedidos); // Retorna uma cópia para proteger a lista interna
        }

        #endregion
    }
}
