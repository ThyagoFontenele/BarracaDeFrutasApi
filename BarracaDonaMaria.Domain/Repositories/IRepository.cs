namespace BarracaDonaMaria.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<IList<T>> FindAll();
        Task<T> FindById(int id);
        Task Add(T item);
        Task Remove(T item);
        Task Update(T item);
    }
}
