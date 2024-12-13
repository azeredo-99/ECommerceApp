using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceApp.classes;

namespace ECommerceApp.classes
{
    public class Pedido
    {
        #region Attributes

        private int id;
        private Cliente cliente;
        private List<ItemPedido> itensPedido;
        private StatusPedidos.StatusPedido status;
        private DateTime dataPedido;

        #endregion

        #region Constructors

        public Pedido(int id, Cliente cliente)
        {
            Id = id;
            Cliente = cliente;
            ItensPedido = new List<ItemPedido>();
            DataPedido = DateTime.Now;
            Status = StatusPedidos.StatusPedido.AguardaPagamento;
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public List<ItemPedido> ItensPedido
        {
            get { return itensPedido; }
            set { itensPedido = value; }
        }

        public StatusPedidos.StatusPedido Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime DataPedido
        {
            get { return dataPedido; }
            set { dataPedido = value; }
        }

        public decimal ValorTotal
        {
            get { return ItensPedido.Sum(item => item.Produto.Preco * item.Quantidade); }
        }

        #endregion

        #region Functions

        public void AdicionarItem(Produto produto, int quantidade)
        {
            var itemExistente = ItensPedido.FirstOrDefault(item => item.Produto.Id == produto.Id);
            if (itemExistente != null)
            {
                itemExistente.Quantidade += quantidade; // Atualiza a quantidade do produto
            }
            else
            {
                ItensPedido.Add(new ItemPedido(produto, quantidade));
            }
        }

        public void RemoverItem(int produtoId)
        {
            var item = ItensPedido.FirstOrDefault(i => i.Produto.Id == produtoId);
            if (item != null)
            {
                ItensPedido.Remove(item);
            }
            else
            {
                Console.WriteLine("Produto não encontrado no pedido.");
            }
        }

        public override string ToString()
        {
            return $"Pedido ID: {Id}, Cliente: {Cliente.Nome}, Status: {Status}, Total: {ValorTotal:C}, Data: {DataPedido}";
        }

        #endregion
    }

    public class ItemPedido
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public ItemPedido(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
        }
    }
}
