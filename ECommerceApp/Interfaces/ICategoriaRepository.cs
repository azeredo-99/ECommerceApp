using System.Collections.Generic;
using ECommerceApp.classes;

namespace ECommerceApp.Interfaces
{
    public interface ICategoriaRepository
    {
        void AdicionarCategoria(Categoria categoria);
        Categoria ObterCategoriaPorId(int id);
        List<Categoria> ObterTodasCategorias();
        void RemoverCategoria(int id);
    }
}
