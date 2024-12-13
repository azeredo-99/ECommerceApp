using System;

namespace ECommerceApp.classes
{
    public class Avaliacao
    {
        #region Attributes

        private int id;
        private Produto produto;
        private Cliente cliente; // Alterado para Cliente
        private int classificacao; // Ex: de 1 a 5 estrelas
        private string comentario;
        private DateTime data;

        #endregion

        #region Methods

        #region Constructors

        public Avaliacao(int id, Produto produto, Cliente cliente, int classificacao, string comentario)
        {
            Id = id;
            Produto = produto;
            Cliente = cliente; // Alterado para Cliente
            Classificacao = classificacao;
            Comentario = comentario;
            Data = DateTime.Now;
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Produto Produto
        {
            get { return produto; }
            set { produto = value; }
        }

        public Cliente Cliente // Alterado para Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public int Classificacao
        {
            get { return classificacao; }
            set { classificacao = value; }
        }

        public string Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        #endregion

        #region Functions

        public override string ToString()
        {
            return $"ID: {Id}, Produto: {Produto.Nome}, Cliente: {Cliente.Nome}, Classificação: {Classificacao}, Comentário: {Comentario}, Data: {Data}";
        }

        #endregion

        #region Destructor

        #endregion

        #endregion
    }
}
