using BarracaDonaMaria.Domain.Entities;

namespace BarracaDonaMaria.Domain.Repositories
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IList<Pedido>> GetCustomerOrders(int id);
        Task<Pedido> GetCustomerOrderOpen(int id);
    }
}
