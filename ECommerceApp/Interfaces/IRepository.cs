namespace ECommerceApp.Interfaces
{
    public interface IRepository<T>
    {
        void Adicionar(T item);
        T ObterPorId(int id);
        List<T> ObterTodos();
        void Atualizar(int id, T item);
        void Remover(int id);
    }
}
