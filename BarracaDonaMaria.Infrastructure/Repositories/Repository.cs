using BarracaDonaMaria.Domain.Entities;
using BarracaDonaMaria.Domain.Repositories;
using BarracaDonaMaria.Infrastructure.Services;
using NHibernate;
using NHibernate.Linq;

namespace BarracaDonaMaria.Infrastructure.Repositories;

public abstract class Repository<T> : IRepository<T> where T : IEntity
{
    protected ISession Session => NHibernateHelper.GetCurrentSession();

    public async Task<IList<T>> FindAll() =>
        await Session.Query<T>().ToListAsync();
       
    public async Task<T> FindById(int id) =>
        await Session.GetAsync<T>(id);
    
    public async Task Add(T item) =>
        await Session.SaveAsync(item);
        
    public async Task Remove(T item) =>
        await Session.DeleteAsync(item);

    public async Task Update(T item) => 
        await Session.UpdateAsync(item);
}
