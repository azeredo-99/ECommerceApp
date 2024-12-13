using ECommerceApp.classes;
using ECommerceApp.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.Data
{
    public static class ClienteRepository
    {
        private static List<Cliente> clientes = new List<Cliente>();

        // Adiciona um novo cliente
        public static void AdicionarCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "Cliente não pode ser nulo.");
            }

            // Verifica se já existe um cliente com o mesmo email
            if (clientes.Any(c => c.Email.Equals(cliente.Email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Já existe um cliente cadastrado com o email '{cliente.Email}'.");
            }

            clientes.Add(cliente);
            Console.WriteLine($"Cliente {cliente.Nome} adicionado com sucesso.");
        }

        // Obtém um cliente por email
        public static Cliente ObterClientePorEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("O email não pode ser vazio ou nulo.", nameof(email));
            }

            var cliente = clientes.FirstOrDefault(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (cliente == null)
            {
                throw new ClienteNaoEncontradoException($"Cliente com o email '{email}' não encontrado.");
            }

            return cliente;
        }

        // Obtém todos os clientes
        public static List<Cliente> ObterTodosClientes()
        {
            return new List<Cliente>(clientes);  // Retorna uma cópia da lista para evitar modificações diretas
        }

        // Atualiza as informações de um cliente com base no email
        public static void AtualizarCliente(string email, Cliente novoCliente)
        {
            var cliente = ObterClientePorEmail(email);
            cliente.Nome = novoCliente.Nome;
            cliente.Password = novoCliente.Password;
            cliente.NumeroTelemovel = novoCliente.NumeroTelemovel;
            Console.WriteLine($"Cliente {cliente.Nome} atualizado com sucesso.");
        }

        // Remove um cliente pelo email
        public static void RemoverCliente(string email)
        {
            var cliente = ObterClientePorEmail(email);
            clientes.Remove(cliente);
            Console.WriteLine($"Cliente {cliente.Nome} removido com sucesso.");
        }
    }
}
