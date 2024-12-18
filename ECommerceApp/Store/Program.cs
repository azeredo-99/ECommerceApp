using System;
using ECommerceApp.classes;
using ECommerceApp.Data;
using ECommerceApp.RegrasNegocio;
using ECommerceApp.Excecoes;
using ECommerceApp.Interfaces;
using ECommerceApp.Utility.ECommerceApp.Utility;

namespace ECommerceApp.Store
{
    public class Program
    {
        static CarrinhoDeCompras carrinho = new CarrinhoDeCompras();

        static void Main()
        {
            try
            {
                IniciarDados();
                LoginMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro a iniciar: {ex.Message}");
            }
        }

        static void IniciarDados()
        {
            
            CategoriaRepository.AdicionarCategoria(new Categoria(1, "Eletronicos"));
            CategoriaRepository.AdicionarCategoria(new Categoria(2, "Roupas"));

            ProdutoRepository.AdicionarProduto(new Produto(1, "Smartphone", 499m, CategoriaRepository.ObterCategoriaPorId(1)));
            ProdutoRepository.AdicionarProduto(new Produto(2, "Camisola Nike", 19m, CategoriaRepository.ObterCategoriaPorId(2)));

            ClienteRepository.AdicionarCliente(new Cliente("joao@example.com", "João", "1234", 911111111));
            ClienteRepository.AdicionarCliente(new Cliente("tiago@example.com", "Tiago", "5678", 912222222));

            StaffRepository.AdicionarStaff(new Staff("staff@example.com", "Staff", "abcd", 922222222, "Administrador"));

           
            StockRepository.AdicionarProdutoAoStock(ProdutoRepository.ObterProdutoPorId(1), 10);
            StockRepository.AdicionarProdutoAoStock(ProdutoRepository.ObterProdutoPorId(2), 5);
        }

        static void LoginMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== Sistema de Login ===");
                Console.WriteLine("1. Login como Cliente");
                Console.WriteLine("2. Login como Staff");
                Console.WriteLine("3. Criar Conta Cliente");
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
                        case 3:
                            CriarContaCliente();
                            break;
                        case 0:
                            Console.WriteLine("A encerrar o sistema...");
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

        static void CriarContaCliente()
        {
            Console.WriteLine("\n=== Criar Conta de Cliente ===");
            Console.Write("Digite o email: ");
            string email = Console.ReadLine();

            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a palavra passe" +
                ": ");
            string passe = Console.ReadLine();

            Console.Write("Digite o número de telemóvel: ");
            string numeroInput = Console.ReadLine();
            if (!int.TryParse(numeroInput, out int numeroTelemovel) || numeroTelemovel <= 0)
            {
                Console.WriteLine("Número de telemóvel inválido.");
                return;
            }

            try
            {
                var novoCliente = new Cliente(email, nome, passe, numeroTelemovel);
                ClienteRepository.AdicionarCliente(novoCliente);
                Console.WriteLine($"Conta criada com sucesso! Agora pode fazer login com o email '{email}'.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao criar conta: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar conta: {ex.Message}");
            }
        }

        static void LoginCliente()
        {
            try
            {
                Console.WriteLine("\n=== Login Cliente ===");
                Console.Write("Digite o seu email: ");
                string email = Console.ReadLine();

                Console.Write("Digite a sua palavra passe: ");
                string passe = Console.ReadLine();

                var cliente = ClienteRepository.ObterClientePorEmail(email);
                if (cliente.Password == passe)
                {
                    Console.WriteLine($"Bem-vindo, {cliente.Nome}!");
                    MenuCliente(cliente);
                }
                else
                {
                    Console.WriteLine("Palavra passe incorreta.");
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

                Console.Write("Digite a sua palavra passe: ");
                string passe = Console.ReadLine();

                var staff = StaffRepository.ObterStaffPorEmail(email);
                if (staff != null && staff.Password == passe)
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
                Console.WriteLine("5. Avaliar Produto");
                Console.WriteLine("6. Histórico de Compras");
                Console.WriteLine("7. Aplicar Codigo de Desconto");
                Console.WriteLine("0. Voltar");

                if (int.TryParse(Console.ReadLine(), out int escolha))
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
                        case 5:
                            AvaliarProduto(cliente);
                            break;
                        case 6:
                            ExibirHistoricoDeCompras(cliente);
                            break;
                        case 7:
                            AplicarDescontoCarrinho(carrinho);
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
                Console.WriteLine($"\n=== Menu Staff ===");
                Console.WriteLine("1. Exibir Produtos no Sistema");
                Console.WriteLine("2. Adicionar Produto");
                Console.WriteLine("3. Remover Produto");
                Console.WriteLine("4. Atualizar Produto");
                Console.WriteLine("5. Gerir Stock");
                Console.WriteLine("6. Adicionar código de desconto");
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
                        case 5:
                            GerenciarStock();
                            break;
                        case 6:
                            AdicionarDescontoSistema();
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

        static void GerenciarStock()
        {
            while (true)
            {
                Console.WriteLine("\n=== Gerenciar Stock ===");
                Console.WriteLine("1. Adicionar stock a um Produto");
                Console.WriteLine("2. Remover stock de um Produto");
                Console.WriteLine("3. Exibir Stock Atual");
                Console.WriteLine("0. Voltar");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int escolha))
                {
                    switch (escolha)
                    {
                        case 1:
                            AdicionarStockProduto();
                            break;
                        case 2:
                            RemoverStockProduto();
                            break;
                        case 3:
                            StockRepository.ExibirStock();
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

        static void AdicionarStockProduto()
        {
            ExibirProdutos();
            Console.Write("Digite o ID do produto para adicionar stock: ");
            string idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var produto = ProdutoRepository.ObterProdutoPorId(id);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            Console.Write("Digite a quantidade a adicionar: ");
            string qtdInput = Console.ReadLine();
            if (!int.TryParse(qtdInput, out int quantidade) || quantidade <= 0)
            {
                Console.WriteLine("Quantidade inválida.");
                return;
            }

            StockRepository.AdicionarProdutoAoStock(produto, quantidade);
        }

        static void RemoverStockProduto()
        {
            StockRepository.ExibirStock();
            Console.Write("Digite o ID do produto para remover stock: ");
            string idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var produto = ProdutoRepository.ObterProdutoPorId(id);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            Console.Write("Digite a quantidade a remover: ");
            string qtdInput = Console.ReadLine();
            if (!int.TryParse(qtdInput, out int quantidade) || quantidade <= 0)
            {
                Console.WriteLine("Quantidade inválida.");
                return;
            }

            try
            {
                StockRepository.RemoverDoStock(produto, quantidade);
            }
            catch (StockInsuficienteException ex)
            {
                Console.WriteLine(ex.Message);
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
                    Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco:C}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum produto disponível.");
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
                    Console.Write("Digite a quantidade desejada: ");
                    string quantidadeInput = Console.ReadLine();
                    if (int.TryParse(quantidadeInput, out int quantidade) && quantidade > 0)
                    {
                        // Validar stock antes de adicionar
                        if (StockRepository.VerificarStockDisponivel(produto, quantidade))
                        {
                            StockRepository.RemoverDoStock(produto, quantidade); // Atualizar stock
                            for (int i = 0; i < quantidade; i++)
                            {
                                carrinho.AdicionarProduto(produto);
                            }
                            Console.WriteLine($"Produto '{produto.Nome}' adicionado ao carrinho.");
                        }
                        else
                        {
                            Console.WriteLine("Quantidade solicitada não disponível em stock.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Quantidade inválida.");
                    }
                }
                catch (ProdutoNaoEncontradoException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (StockInsuficienteException ex)
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
                Console.Write("Digite o ID do produto que deseja remover do carrinho: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int id))
                {
                    var produto = ProdutoRepository.ObterProdutoPorId(id);
                    carrinho.RemoverProduto(id);
                    StockRepository.AdicionarProdutoAoStock(produto, 1); // Repor stock
                    Console.WriteLine("Produto removido do carrinho e stock atualizado.");
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
                var pedido = new Pedido(PedidoRepository.ObterTodosPedidos().Count + 1, cliente);

                foreach (var produto in carrinho.ObterProdutos())
                {
                    pedido.AdicionarItem(produto, 1); // Adiciona cada produto como um item com quantidade 1
                }

                PedidoRepository.AdicionarPedido(pedido);
                cliente.AdicionarPedido(pedido);

                Console.WriteLine("Compra finalizada com sucesso!");
                carrinho.LimparCarrinho();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao finalizar a compra: {ex.Message}");
            }
        }



        static void AdicionarProdutoSistema()
        {
            try
            {
                Console.WriteLine("\n=== Adicionar Produto ===");
                Console.Write("Digite o nome do produto: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o preço do produto: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal preco) || preco <= 0)
                {
                    Console.WriteLine("Preço inválido. O valor deve ser um número positivo.");
                    return;
                }

                Console.Write("Digite o ID da categoria do produto: ");
                if (!int.TryParse(Console.ReadLine(), out int categoriaId))
                {
                    Console.WriteLine("ID de categoria inválido.");
                    return;
                }

                var categoria = CategoriaRepository.ObterCategoriaPorId(categoriaId);
                if (categoria == null)
                {
                    Console.WriteLine($"Categoria com ID {categoriaId} não encontrada.");
                    return;
                }

                int novoId = ProdutoRepository.ObterTodosProdutos().Count + 1;
                var produto = new Produto(novoId, nome, preco, categoria);

                ProdutoRepository.AdicionarProduto(produto);
                Console.WriteLine($"Produto '{produto.Nome}' adicionado com sucesso ao sistema.");
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
                Console.WriteLine("\n=== Remover Produto ===");
                Console.Write("Digite o ID do produto que deseja remover: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("ID inválido. Por favor, insira um número válido.");
                    return;
                }

                var produto = ProdutoRepository.ObterProdutoPorId(id);
                if (produto == null)
                {
                    Console.WriteLine($"Produto com ID {id} não encontrado.");
                    return;
                }

                ProdutoRepository.RemoverProduto(id);
                Console.WriteLine($"Produto '{produto.Nome}' removido com sucesso.");
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

        static void AvaliarProduto(Cliente cliente)
        {
            try
            {
                Console.WriteLine("\n=== Avaliar Produto ===");
                ExibirProdutos();

                Console.Write("Digite o ID do produto que deseja avaliar: ");
                if (!int.TryParse(Console.ReadLine(), out int produtoId))
                {
                    Console.WriteLine("ID inválido.");
                    return;
                }

                var produto = ProdutoRepository.ObterProdutoPorId(produtoId);
                if (produto == null)
                {
                    Console.WriteLine("Produto não encontrado.");
                    return;
                }

                Console.Write("Digite a classificação (1 a 5): ");
                if (!int.TryParse(Console.ReadLine(), out int classificacao) || classificacao < 1 || classificacao > 5)
                {
                    Console.WriteLine("Classificação inválida. Insira um valor entre 1 e 5.");
                    return;
                }

                Console.Write("Digite o seu comentário: ");
                string comentario = Console.ReadLine();

                IAvaliacaoRepository avaliacaoRepository = new AvaliacaoRepository(); 
                var avaliacao = new Avaliacao(avaliacaoRepository.ObterTodasAvaliacoes().Count + 1, produto, cliente, classificacao, comentario);
                avaliacaoRepository.AdicionarAvaliacao(avaliacao);


                Console.WriteLine("Avaliação registrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao avaliar o produto: {ex.Message}");
            }
        }

        static void ExibirHistoricoDeCompras(Cliente cliente)
        {
            Console.WriteLine("\n=== Histórico de Compras ===");

            var historico = cliente.ObterPedidos();
            if (historico.Count == 0)
            {
                Console.WriteLine("Nenhuma compra realizada.");
                return;
            }

            foreach (var pedido in historico)
            {
                Console.WriteLine($"Pedido ID: {pedido.Id}, Data: {pedido.DataPedido}, Total: {pedido.ValorTotal:C}, Status: {pedido.Status}");
                Console.WriteLine("Produtos:");
                foreach (var item in pedido.ItensPedido)
                {
                    Console.WriteLine($"- {item.Produto.Nome} (Quantidade: {item.Quantidade}, Preço: {item.Produto.Preco:C})");
                }
                Console.WriteLine("---------------------------------------------------");
            }
        }

        static void AplicarDescontoCarrinho(CarrinhoDeCompras carrinho)
        {
            Console.Write("Digite o código do desconto: ");
            string codigo = Console.ReadLine();

            var desconto = DescontoRepository.ObterDescontoPorCodigo(codigo);
            if (desconto != null)
            {
                carrinho.AplicarDesconto(desconto);
            }
            else
            {
                Console.WriteLine("Código de desconto inválido ou inexistente.");
            }
        }

        static void AdicionarDescontoSistema()
        {
            Console.Write("Digite o código do desconto: ");
            string codigo = Console.ReadLine();

            Console.Write("Digite o valor do desconto: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal valor) && valor > 0)
            {
                var desconto = new Desconto(codigo, valor);
                DescontoRepository.AdicionarDesconto(desconto);
                Console.WriteLine("Desconto adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
        }


        static void AtualizarProdutoSistema()
        {
            try
            {
                Console.WriteLine("\n=== Atualizar Produto ===");
                Console.Write("Digite o ID do produto que deseja atualizar: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("ID inválido. Por favor, insira um número válido.");
                    return;
                }

                var produto = ProdutoRepository.ObterProdutoPorId(id);
                if (produto == null)
                {
                    Console.WriteLine($"Produto com ID {id} não encontrado.");
                    return;
                }

                Console.WriteLine($"Produto atual: {produto}");

                Console.Write("Digite o novo nome do produto (ou pressione Enter para manter o nome atual): ");
                string novoNome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoNome))
                {
                    produto.AtualizarNome(novoNome);
                }

                Console.Write("Digite o novo preço do produto (ou pressione Enter para manter o preço atual): ");
                string novoPrecoInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoPrecoInput))
                {
                    if (decimal.TryParse(novoPrecoInput, out decimal novoPreco) && novoPreco > 0)
                    {
                        produto.AtualizarPreco(novoPreco);
                    }
                    else
                    {
                        Console.WriteLine("Preço inválido. Alteração ignorada.");
                    }
                }

                Console.Write("Digite o novo ID da categoria (ou pressione Enter para manter a categoria atual): ");
                string novaCategoriaInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novaCategoriaInput))
                {
                    if (int.TryParse(novaCategoriaInput, out int novaCategoriaId))
                    {
                        var novaCategoria = CategoriaRepository.ObterCategoriaPorId(novaCategoriaId);
                        if (novaCategoria != null)
                        {
                            produto.AtualizarCategoria(novaCategoria);
                        }
                        else
                        {
                            Console.WriteLine("Categoria inválida. Alteração ignorada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID de categoria inválido. Alteração ignorada.");
                    }
                }

                Console.WriteLine("Produto atualizado com sucesso!");
            }
            catch (ProdutoNaoEncontradoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar produto: {ex.Message}");
            }
        }

        static void AplicarDescontoCarrinho(CarrinhoDeCompras carrinho, decimal valorDesconto)
        {
            decimal valorFinal = DescontoHelper.AplicarDesconto(carrinho.CalcularTotal(), valorDesconto);
            Console.WriteLine($"Novo valor total com desconto: {valorFinal:C}");
        }

    }
}

