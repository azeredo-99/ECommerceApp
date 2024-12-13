using System;

namespace ECommerceApp.classes
{
    public class Produto
    {
        #region Attributes

        private int id;
        private string nome;
        private decimal preco;
        private Categoria categoria;

        #endregion

        #region Constructors

        public Produto(int id, string nome, decimal preco, Categoria categoria)
        {
            // Validação simples
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do produto não pode ser vazio ou nulo.", nameof(nome));

            if (preco < 0)
                throw new ArgumentOutOfRangeException(nameof(preco), "O preço não pode ser negativo.");

            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria), "A categoria não pode ser nula.");

            this.id = id;
            this.nome = nome;
            this.preco = preco;
            this.categoria = categoria;
        }

        #endregion

        #region Properties

        public int Id => id;  // Propriedade somente leitura

        public string Nome => nome;  // Propriedade somente leitura

        public decimal Preco => preco;  // Propriedade somente leitura

        public Categoria Categoria => categoria;  // Propriedade somente leitura

        #endregion

        #region Methods

        // Métodos para atualização das propriedades
        public void AtualizarNome(string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome))
                throw new ArgumentException("O nome não pode ser vazio ou nulo.", nameof(novoNome));
            nome = novoNome;
        }

        public void AtualizarPreco(decimal novoPreco)
        {
            if (novoPreco < 0)
                throw new ArgumentOutOfRangeException(nameof(novoPreco), "O preço não pode ser negativo.");
            preco = novoPreco;
        }

        public void AtualizarCategoria(Categoria novaCategoria)
        {
            if (novaCategoria == null)
                throw new ArgumentNullException(nameof(novaCategoria), "A categoria não pode ser nula.");
            categoria = novaCategoria;
        }

        #endregion

        #region Functions

        public override string ToString()
        {
            return $"Produto ID: {Id}, Nome: {Nome}, Preço: {Preco:C}, Categoria: {Categoria.Nome}";
        }

        #endregion
    }
}
