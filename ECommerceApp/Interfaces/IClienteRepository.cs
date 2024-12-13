using System.Collections.Generic;
using ECommerceApp.classes;

namespace ECommerceApp.Interfaces
{
    public interface IClienteRepository
    {
        void AdicionarCliente(Cliente cliente);
        Cliente ObterClientePorEmail(string email);
        List<Cliente> ObterTodosClientes();
        void AtualizarCliente(string email, Cliente novoCliente);
        void RemoverCliente(string email);
    }
}
