using System;
using System.Collections.Generic;

namespace ECommerceApp.classes
{
    public class Program
    {
        static CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
        static List<Cliente> clientes = new List<Cliente>();
        static List<Staff> staffs = new List<Staff>();

        static void Main()
        {
            // Adicionando dados fictícios para teste de login
            InicializarUsuarios();

            // Exibe o menu de login da aplicação
            LoginMenu();
        }

        static void InicializarUsuarios()
        {
            // Criando alguns clientes e staff
            clientes.Add(new Cliente("cliente1@example.com", "Cliente 1", "1234", 911111111));
            staffs.Add(new Staff("staff1@example.com", "Staff 1", "abcd", 922222222));
        }

        static void LoginMenu()
        {
            Console.WriteLine("=== Sistema de Login ===");
            Console.WriteLine("1. Login como Cliente");
            Console.WriteLine("2. Login como Staff");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    LoginCliente();
                    break;
                case 2:
                    LoginStaff();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    LoginMenu();
                    break;
            }
        }

        static void LoginCliente()
        {
            Console.WriteLine("\n=== Login Cliente ===");
            Console.Write("Digite seu email: ");
            string email = Console.ReadLine();

            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine();

            var cliente = clientes.Find(c => c.Email == email && c.Password == senha);

            if (cliente != null)
            {
                Console.WriteLine($"Bem-vindo, {cliente.Nome}!");
                MenuCliente(cliente); // Entrar no menu de cliente
            }
            else
            {
                Console.WriteLine("Login falhou! Email ou senha incorretos.");
                LoginMenu();
            }
        }

        static void LoginStaff()
        {
            Console.WriteLine("\n=== Login Staff ===");
            Console.Write("Digite seu email: ");
            string email = Console.ReadLine();

            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine();

            var staff = staffs.Find(s => s.Email == email && s.Password == senha);

            if (staff != null)
            {
                Console.WriteLine($"Bem-vindo, {staff.Nome}!");
                MenuStaff(staff); // Entrar no menu de staff
            }
            else
            {
                Console.WriteLine("Login falhou! Email ou senha incorretos.");
                LoginMenu();
            }
        }

        static void MenuCliente(Cliente cliente)
        {
            int escolha;

            do
            {
                Console.WriteLine($"\n=== Menu do Cliente {cliente.Nome} ===");
                Console.WriteLine("1. Adicionar Produto ao Carrinho");
                Console.WriteLine("2. Remover Produto do Carrinho");
                Console.WriteLine("3. Exibir Carrinho");
                Console.WriteLine("4. Limpar Carrinho");
                Console.WriteLine("5. Calcular Total do Carrinho");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        AdicionarProdutoMenu();
                        break;
                    case 2:
                        RemoverProdutoMenu();
                        break;
                    case 3:
                        carrinho.ExibirCarrinho();
                        break;
                    case 4:
                        carrinho.LimparCarrinho();
                        Console.WriteLine("Carrinho Limpo!");
                        break;
                    case 5:
                        Console.WriteLine($"Total: {carrinho.CalcularTotal():C}");
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

            } while (escolha != 0);
        }

        static void MenuStaff(Staff staff)
        {
            int escolha;

            do
            {
                Console.WriteLine($"\n=== Menu do Staff {staff.Nome} ===");
                Console.WriteLine("1. Exibir Produtos no Sistema");
                Console.WriteLine("2. Adicionar Produto ao Sistema");
                Console.WriteLine("3. Remover Produto do Sistema");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        // Exibe todos os produtos cadastrados
                        // (Função não implementada, adicione a lógica aqui)
                        Console.WriteLine("Exibir Produtos no Sistema...");
                        break;
                    case 2:
                        // Adicionar um novo produto no sistema
                        // (Função não implementada, adicione a lógica aqui)
                        Console.WriteLine("Adicionar Produto no Sistema...");
                        break;
                    case 3:
                        // Remover produto do sistema
                        // (Função não implementada, adicione a lógica aqui)
                        Console.WriteLine("Remover Produto do Sistema...");
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

            } while (escolha != 0);
        }

        static void AdicionarProdutoMenu()
        {
            Console.WriteLine("\n=== Adicionar Produto ===");

            // Exemplo de entrada de dados pelo usuário para criação do produto
            Console.Write("Digite o ID do produto: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o preço do produto: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            // Criando a categoria do produto para simplicidade
            Categoria categoria = new Categoria(1, "Categoria Padrão");

            // Criando um novo produto
            Produto produto = new Produto(id, nome, preco, categoria);

            // Adicionando o produto ao carrinho
            carrinho.AdicionarProduto(produto);

            Console.WriteLine($"Produto {nome} adicionado ao carrinho!\n");
        }

        static void RemoverProdutoMenu()
        {
            Console.WriteLine("\n=== Remover Produto ===");

            Console.Write("Digite o ID do produto a ser removido: ");
            int id = int.Parse(Console.ReadLine());

            carrinho.RemoverProduto(id);

            Console.WriteLine($"Produto com ID {id} removido do carrinho!\n");
        }
    }
}
