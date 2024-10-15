using System;

namespace ECommerceApp.classes
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public Pessoa Pessoa { get; set; }
        public int Classificacao { get; set; } // Ex: de 1 a 5 estrelas
        public string Comentario { get; set; }
        public DateTime Data { get; set; }

        public Avaliacao(int id, Produto produto, Pessoa pessoa, int classificacao, string comentario)
        {
            Id = id;
            Produto = produto;
            Pessoa = pessoa;
            Classificacao = classificacao;
            Comentario = comentario;
            Data = DateTime.Now;
        }
    }
}
