using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceApp.classes;
using ECommerceApp.Interfaces;

namespace ECommerceApp.Data
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private static List<Avaliacao> avaliacoes = new List<Avaliacao>();

        // Adiciona uma avaliação
        public void AdicionarAvaliacao(Avaliacao avaliacao)
        {
            if (avaliacao == null)
            {
                throw new ArgumentNullException(nameof(avaliacao), "A avaliação não pode ser nula.");
            }

            avaliacoes.Add(avaliacao);
        }

        // Obter avaliações por cliente (filtra por email do cliente)
        public List<Avaliacao> ObterAvaliacoesPorCliente(string emailCliente)
        {
            if (string.IsNullOrEmpty(emailCliente))
            {
                throw new ArgumentException("O email do cliente não pode ser nulo ou vazio.", nameof(emailCliente));
            }

            return avaliacoes.Where(a => a.Cliente.Email == emailCliente).ToList();
        }

        // Obter avaliações por produto (filtra por ID do produto)
        public List<Avaliacao> ObterAvaliacoesPorProduto(int produtoId)
        {
            return avaliacoes.Where(a => a.Produto.Id == produtoId).ToList();
        }
    }
}
