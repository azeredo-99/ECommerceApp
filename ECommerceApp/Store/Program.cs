using System;
using ECommerceApp.classes;
using ECommerceApp.Data;
using ECommerceApp.RegrasNegocio;
using ECommerceApp.Excecoes;

namespace ECommerceApp.Store
{
    public class Program
    {
        static CarrinhoDeCompras carrinho = new CarrinhoDeCompras();

        static void Main()
        {
            try
            {
                // Inicializa dados fictícios
                IniciarDados();

                // Exibe o menu principal
                LoginMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante a inicialização: {ex.Message}");
            }
        }

        static void IniciarDados()
        {
            try
            {
                // Inicializando categorias
                CategoriaRepository.AdicionarCategoria(new Categoria(1, "Eletrônicos"));
                CategoriaRepository.AdicionarCategoria(new Categoria(2, "Roupas"));

                // Inicializando produtos
                ProdutoRepository.AdicionarProduto(new Produto(1, "Smartphone", 499.00m, CategoriaRepository.ObterCategoriaPorId(1)));
                ProdutoRepository.AdicionarProduto(new Produto(2, "Camisola Nike", 19.00m, CategoriaRepository.ObterCategoriaPorId(2)));

                // Inicializando clientes
                ClienteRepository.AdicionarCliente(new Cliente("joao@example.com", "João", "1234", 911111111));
                ClienteRepository.AdicionarCliente(new Cliente("tiago@example.com", "Tiago", "5678", 912222222));

                // Inicializando staff com o parâmetro 'cargo'
                StaffRepository.AdicionarStaff(new Staff("staff@example.com", "Staff", "abcd", 922222222, "Administrador"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inicializar dados: {ex.Message}");
            }
        }

        static void LoginMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== Sistema de Login ===");
                Console.WriteLine("1. Login como Cliente");
                Console.WriteLine("2. Login como Staff");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int escolha))
                {
                    switch (escolha)
                    {
                        case 1:
                            LoginCliente();
                            break;
                        case 2:
                            LoginStaff();
                            break;
                        case 0:
                            Console.WriteLine("Encerrando o sistema...");
                            return;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número válido.");
                }
            }
        }

        static void LoginCliente()
        {
            try
            {
                Console.WriteLine("\n=== Login Cliente ===");
                Console.Write("Digite o seu email: ");
                string email = Console.ReadLine();

                Console.Write("Digite a sua senha: ");
                string senha = Console.ReadLine();

                var cliente = ClienteRepository.ObterClientePorEmail(email);
                if (cliente.Password == senha)
                {
                    Console.WriteLine($"Bem-vindo, {cliente.Nome}!");
                    MenuCliente(cliente);
                }
                else
                {
                    Console.WriteLine("Senha incorreta.");
                }
            }
            catch (ClienteNaoEncontradoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante o login do cliente: {ex.Message}");
            }
        }

        static void LoginStaff()
        {
            try
            {
                Console.WriteLine("\n=== Login Staff ===");
                Console.Write("Digite o seu email: ");
                string email = Console.ReadLine();

                Console.Write("Digite a sua senha: ");
                string senha = Console.ReadLine();

                var staff = StaffRepository.ObterStaffPorEmail(email);
                if (staff != null && staff.Password == senha)
                {
                    Console.WriteLine($"Bem-vindo, {staff.Nome}! Cargo: {staff.Cargo}");
                    MenuStaff();
                }
                else
                {
                    Console.WriteLine("Credenciais de Staff incorretas.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante o login do staff: {ex.Message}");
            }
        }

        static void MenuCliente(Cliente cliente)
        {
            while (true)
            {
                Console.WriteLine($"\n=== Menu do Cliente: {cliente.Nome} ===");
                Console.WriteLine("1. Adicionar Produto ao Carrinho");
                Console.WriteLine("2. Remover Produto do Carrinho");
                Console.WriteLine("3. Exibir Carrinho");
                Console.WriteLine("4. Finalizar Compra");
                Console.WriteLine("0. Voltar");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int escolha))
                {
                    switch (escolha)
                    {
                        case 1:
                            AdicionarProdutoCarrinho();
                            break;
                        case 2:
                            RemoverProdutoCarrinho();
                            break;
                        case 3:
                            carrinho.ExibirCarrinho();
                            break;
                        case 4:
                            FinalizarCompra(cliente);
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número válido.");
                }
            }
        }

        static void MenuStaff()
        {
            while (true)
            {
                Console.WriteLine("\n=== Menu Staff ===");
                Console.WriteLine("1. Exibir Produtos no Sistema");
                Console.WriteLine("2. Adicionar Produto");
                Console.WriteLine("3. Remover Produto");
                Console.WriteLine("4. Atualizar Produto");
                Console.WriteLine("0. Voltar");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int escolha))
                {
                    switch (escolha)
                    {
                        case 1:
                            ExibirProdutos();
                            break;
                        case 2:
                            AdicionarProdutoSistema();
                            break;
                        case 3:
                            RemoverProdutoSistema();
                            break;
                        case 4:
                            AtualizarProdutoSistema();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número válido.");
                }
            }
        }

        static void AdicionarProdutoCarrinho()
        {
            ExibirProdutos();
            Console.Write("Digite o ID do produto que deseja adicionar ao carrinho: ");

            string input = Console.ReadLine();
            if (int.TryParse(input, out int id))
            {
                try
                {
                    var produto = ProdutoRepository.ObterProdutoPorId(id);
                    carrinho.AdicionarProduto(produto);
                    Console.WriteLine($"Produto '{produto.Nome}' adicionado ao carrinho.");
                }
                catch (ProdutoNaoEncontradoException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao adicionar produto ao carrinho: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }

        static void RemoverProdutoCarrinho()
        {
            try
            {
                carrinho.ExibirCarrinho();
                Console.Write("Digite o ID do produto que deseja remover: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int id))
                {
                    carrinho.RemoverProduto(id);
                    Console.WriteLine("Produto removido do carrinho.");
                }
                else
                {
                    Console.WriteLine("ID inválido.");
                }
            }
            catch (ProdutoNaoEncontradoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover produto do carrinho: {ex.Message}");
            }
        }

        static void FinalizarCompra(Cliente cliente)
        {
            try
            {
                carrinho.ExibirCarrinho();
                if (carrinho.ObterQuantidadeProdutos() > 0)
                {
                    decimal total = carrinho.CalcularTotal();
                    Console.WriteLine($"Compra finalizada. Total: {total:C}");
                    carrinho.LimparCarrinho();
                }
                else
                {
                    Console.WriteLine("Carrinho vazio. Não é possível finalizar a compra.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao finalizar compra: {ex.Message}");
            }
        }

        static void ExibirProdutos()
        {
            Console.WriteLine("\n=== Lista de Produtos ===");
            var produtos = ProdutoRepository.ObterTodosProdutos();
            if (produtos.Count > 0)
            {
                foreach (var produto in produtos)
                {
                    Console.WriteLine(produto.ToString());
                }
            }
            else
            {
                Console.WriteLine("Nenhum produto disponível.");
            }
        }

        static void AdicionarProdutoSistema()
        {
            try
            {
                Console.Write("Digite o ID do produto: ");
                string idInput = Console.ReadLine();
                if (!int.TryParse(idInput, out int id))
                {
                    Console.WriteLine("ID inválido.");
                    return;
                }

                Console.Write("Digite o nome do produto: ");
                string nome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("Nome inválido.");
                    return;
                }

                Console.Write("Digite o preço do produto: ");
                string precoInput = Console.ReadLine();
                if (!decimal.TryParse(precoInput, out decimal preco))
                {
                    Console.WriteLine("Preço inválido.");
                    return;
                }

                Console.Write("Digite o ID da categoria do produto: ");
                string categoriaInput = Console.ReadLine();
                if (!int.TryParse(categoriaInput, out int categoriaId))
                {
                    Console.WriteLine("ID de categoria inválido.");
                    return;
                }

                var categoria = CategoriaRepository.ObterCategoriaPorId(categoriaId);
                if (categoria == null)
                {
                    Console.WriteLine("Categoria não encontrada.");
                    return;
                }

                var novoProduto = new Produto(id, nome, preco, categoria);
                ProdutoRepository.AdicionarProduto(novoProduto);
                Console.WriteLine("Produto adicionado com sucesso.");
            }
            catch (CategoriaNaoEncontradaException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao adicionar produto: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar produto: {ex.Message}");
            }
        }

        static void RemoverProdutoSistema()
        {
            try
            {
                ExibirProdutos();
                Console.Write("Digite o ID do produto que deseja remover: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int id))
                {
                    ProdutoRepository.RemoverProduto(id);
                }
                else
                {
                    Console.WriteLine("ID inválido.");
                }
            }
            catch (ProdutoNaoEncontradoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover produto: {ex.Message}");
            }
        }

        static void AtualizarProdutoSistema()
        {
            try
            {
                ExibirProdutos();
                Console.Write("Digite o ID do produto que deseja atualizar: ");
                string idInput = Console.ReadLine();

                if (!int.TryParse(idInput, out int id))
                {
                    Console.WriteLine("ID inválido.");
                    return;
                }

                var produtoExistente = ProdutoRepository.ObterProdutoPorId(id);

                Console.Write("Digite o novo nome do produto (deixe vazio para não alterar): ");
                string novoNome = Console.ReadLine();

                Console.Write("Digite o novo preço do produto (deixe vazio para não alterar): ");
                string precoInput = Console.ReadLine();

                Console.Write("Digite o novo ID da categoria (deixe vazio para não alterar): ");
                string categoriaInput = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(novoNome))
                {
                    produtoExistente.AtualizarNome(novoNome);
                }

                if (!string.IsNullOrWhiteSpace(precoInput))
                {
                    if (decimal.TryParse(precoInput, out decimal novoPreco))
                    {
                        produtoExistente.AtualizarPreco(novoPreco);
                    }
                    else
                    {
                        Console.WriteLine("Preço inválido. Não foi possível atualizar o preço.");
                    }
                }

                if (!string.IsNullOrWhiteSpace(categoriaInput))
                {
                    if (int.TryParse(categoriaInput, out int novaCategoriaId))
                    {
                        var novaCategoria = CategoriaRepository.ObterCategoriaPorId(novaCategoriaId);
                        if (novaCategoria != null)
                        {
                            produtoExistente.AtualizarCategoria(novaCategoria);
                        }
                        else
                        {
                            Console.WriteLine("Categoria não encontrada. Não foi possível atualizar a categoria.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID de categoria inválido. Não foi possível atualizar a categoria.");
                    }
                }

                Console.WriteLine("Produto atualizado com sucesso.");
            }
            catch (ProdutoNaoEncontradoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao atualizar produto: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar produto: {ex.Message}");
            }
        }
    }
}
