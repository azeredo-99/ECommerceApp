using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceApp.classes;
using ECommerceApp.Interfaces;

namespace ECommerceApp.Data
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        // Armazena as avaliações em uma lista
        private List<Avaliacao> avaliacoes = new List<Avaliacao>();

        // Adiciona uma avaliação
        public void AdicionarAvaliacao(Avaliacao avaliacao)
        {
            if (avaliacao == null)
                throw new ArgumentNullException(nameof(avaliacao), "A avaliação não pode ser nula.");

            avaliacoes.Add(avaliacao);
            Console.WriteLine($"Avaliação ID {avaliacao.Id} adicionada com sucesso.");
        }

        // Retorna todas as avaliações
        public List<Avaliacao> ObterTodasAvaliacoes()
        {
            return new List<Avaliacao>(avaliacoes); // Evita modificações externas
        }

        // Retorna avaliações por cliente
        public List<Avaliacao> ObterAvaliacoesPorCliente(string emailCliente)
        {
            if (string.IsNullOrWhiteSpace(emailCliente))
                throw new ArgumentException("Email não pode ser vazio.", nameof(emailCliente));

            return avaliacoes
                .Where(a => a.Cliente.Email.Equals(emailCliente, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Retorna avaliações por produto
        public List<Avaliacao> ObterAvaliacoesPorProduto(int produtoId)
        {
            if (produtoId <= 0)
                throw new ArgumentException("O ID do produto deve ser maior que zero.", nameof(produtoId));

            return avaliacoes.Where(a => a.Produto.Id == produtoId).ToList();
        }
    }
}
