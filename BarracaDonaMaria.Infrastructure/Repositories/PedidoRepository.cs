using BarracaDonaMaria.Domain.Entities;
using BarracaDonaMaria.Domain.Repositories;
using NHibernate.Linq;

namespace BarracaDonaMaria.Infrastructure.Repositories;

public class PedidoRepository : Repository<Pedido>, IPedidoRepository
{
    public async Task<IList<Pedido>> GetCustomerOrders(int id) =>
        await Session.Query<Pedido>().Where(p => p.Cliente.Id == id).ToListAsync();

    public async Task<Pedido> GetCustomerOrderOpen(int id) =>
        await Session.Query<Pedido>().FirstAsync(p => p.Cliente.Id == id && p.Finalizado == false);
}
