using System;

namespace ECommerceApp.classes
{
    public class Produto
    {
        #region CONSTRUTORES

        public Produto(int id, string nome, decimal preco, Categoria categoria)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser maior que zero.");

            if (preco < 0)
                throw new ArgumentOutOfRangeException(nameof(preco), "O preço não pode ser negativo.");

            Id = id;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome), "O nome não pode ser nulo.");
            Preco = preco;
            Categoria = categoria ?? throw new ArgumentNullException(nameof(categoria), "A categoria não pode ser nula.");
        }

        #endregion

        #region ESTADO

        public int Id { get; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        // Nova propriedade Categoria
        public Categoria Categoria { get; set; }

        #endregion

        #region MÉTODOS

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Preço: {Preco:C}, Categoria: {Categoria.Nome}";
        }

        #endregion
    }
}
