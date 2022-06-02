using BarracaDonaMaria.Domain.Entities;
using BarracaDonaMaria.Domain.Repositories;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarracaDonaMaria.Infrastructure.Repositories;

public class ItemPedidoRepository : Repository<ItemPedido>, IItemPedidoRepository
{
}
