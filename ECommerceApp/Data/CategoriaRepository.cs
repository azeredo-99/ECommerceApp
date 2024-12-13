using ECommerceApp.classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.Data
{
    public static class CategoriaRepository
    {
        // Lista estática que armazena todas as categorias
        private static List<Categoria> categorias = new List<Categoria>();

        // Adiciona uma nova categoria
        public static void AdicionarCategoria(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria), "Categoria não pode ser nula.");
            }

            // Verificar duplicação de categorias com o mesmo ID
            if (categorias.Any(c => c.Id == categoria.Id))
            {
                throw new ArgumentException($"Categoria com ID {categoria.Id} já existe.");
            }

            categorias.Add(categoria);
            Console.WriteLine($"Categoria {categoria.Nome} adicionada com sucesso.");
        }

        // Obtém uma categoria por ID
        public static Categoria ObterCategoriaPorId(int id)
        {
            var categoria = categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
            {
                throw new Exception($"Categoria com ID {id} não encontrada.");
            }
            return categoria;
        }

        // Retorna todas as categorias
        public static List<Categoria> ObterTodasCategorias()
        {
            return categorias;
        }

        // Remove uma categoria por ID
        public static void RemoverCategoria(int id)
        {
            var categoria = categorias.FirstOrDefault(c => c.Id == id);
            if (categoria != null)
            {
                categorias.Remove(categoria);
                Console.WriteLine($"Categoria {categoria.Nome} removida com sucesso.");
            }
            else
            {
                Console.WriteLine("Categoria não encontrada.");
            }
        }
    }
}
